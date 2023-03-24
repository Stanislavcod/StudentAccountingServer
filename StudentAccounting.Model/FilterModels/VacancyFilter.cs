
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Common.FilterModels
{
    public class VacancyFilter
    {  
        public string Vacancy { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public int DateYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Status { get; set; }
    }
}
