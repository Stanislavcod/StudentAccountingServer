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
                List<Project> result = new List<Project>();
                var projects = _context.Projects.ToList();
                foreach (var project in projects)
                {
                    if (project.StagesOfProjects != null)
                    {
                        foreach (var stage in _context.StagesOfProjects.Where(x => x.ProjectId == project.Id).ToList())
                        {
                            if (stage.Vacancy != null)
                            {
                                foreach (var vacancy in stage.Vacancy)
                                {
                                    if (vacancy.ApplicationsInTheProjects != null)
                                    {
                                        foreach (var application in vacancy.ApplicationsInTheProjects)
                                        {
                                            if (application.Participants != null && application.Participants.Id == participantId)
                                            {
                                                result.Add(project);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return result;
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
        public IEnumerable<Project> GetFiltredApplicationInTheProject(ProjectFilter filter)
        {
            var quary = _context.Projects.AsQueryable();

            //фильтр по отделам не готов
            //if (!string.IsNullOrEmpty(filter.Position))
            //{
            //    quary = quary.Where(app => app.StagesOfProjects));
            //}
            if (filter.DateYear != new DateTime().Year)
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
