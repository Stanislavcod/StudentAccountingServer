using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Common.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDatabaseContext _context;
        public ProjectService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Project> Get()
        {
            try
            {
                return _context.Projects.Include(x => x.Customer).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Project Get(int id)
        {
            try
            {
                return _context.Projects.Include(x => x.Customer).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Project> GetForParticipantsId(int participantId)
        {
            try
            {
                var projects = _context.Projects
                    .Include(p => p.StagesOfProjects)
                        .ThenInclude(s => s.Vacancy)
                            .ThenInclude(v => v.ApplicationsInTheProjects)
                                .ThenInclude(a => a.Participants)
                                    .Where(p => p.Id == participantId)
                                    .ToList();
                //var projects = _context.Participants
                //    .Where(p => p.Id == participantId)
                //    .Join(_context.Projects, p => p.Id, r => r.Id, (p, r) => r)
                //    .ToList();

                if (projects != null)
                {
                    return projects;
                }
                else
                {
                    throw new Exception("project был null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Project project)
        {
            try
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var project = _context.Projects.FirstOrDefault(x => x.Id == id);
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Project> GetFiltredProject(ProjectFilter filter)
        {
            var quary = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Position))
            {
                quary = _context.Projects
                    .Join(_context.StagesOfProjects, p => p.Id, s => s.ProjectId, (p, s) => new { Project = p, Stage = s })
                    .Join(_context.Vacancies, ps => ps.Stage.Id, v => v.StagesOfProjectId, (ps, v) => new { ps.Project, ps.Stage, Vacancy = v })
                    .Join(_context.ApplicationsInTheProjects, pv => pv.Vacancy.Id, ap => ap.VacancyId, (pv, ap) => new { pv.Project, pv.Stage, pv.Vacancy, Application = ap })
                    .Join(_context.Participants, apv => apv.Application.ParticipantsId, pt => pt.Id, (apv, pt) => new { apv.Project, apv.Stage, apv.Vacancy, apv.Application, Participant = pt })
                    .Join(_context.Employments, ptp => ptp.Participant.Id, e => e.ParticipantsId, (ptp, e) => new { ptp.Project, ptp.Stage, ptp.Vacancy, ptp.Application, ptp.Participant, Employment = e })
                    .Join(_context.Positions, ept => ept.Employment.PositionId, pos => pos.Id, (ept, pos) => new { ept.Project, ept.Stage, ept.Vacancy, ept.Application, ept.Participant, ept.Employment, Position = pos })
                    .Where(pr => pr.Position.FullName == filter.Position)
                    .Select(pd => pd.Project)
                    .Distinct();
            }
            if (filter.DateYear is not 0)
            {
                quary = quary.Where(project => project.DateStart.Year == filter.DateYear);
            }
            if (filter.DateFrom != new DateTime() && filter.DateTo != new DateTime())
            {
                quary = quary.Where(project => project.DateStart >= filter.DateFrom && project.DateStart <= filter.DateTo);
            }
            if(!string.IsNullOrEmpty(filter.Status))
            {
                quary = quary.Where(project => project.Status.ToLower().Contains(filter.Status));
            }

            var applicationInTheProject = quary.ToList();

            return applicationInTheProject;
        }
    }
}
