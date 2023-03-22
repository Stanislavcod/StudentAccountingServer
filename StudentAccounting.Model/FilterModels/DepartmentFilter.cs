
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Model.FilterModels
{
    public class DepartmentFilter
    {
        public int DateYear { get; set; }
        public DateTime ВateOfCreation { get; set; }
        public string NumberOfPeople { get; set; } = string.Empty;
        public int NumberOfPeopleFrom { get; set; }
        public int NumberOfPeopleTo { get; set; }
        public string Participants { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
