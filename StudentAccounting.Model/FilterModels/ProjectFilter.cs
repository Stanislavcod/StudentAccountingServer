
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Common.FilterModels
{
    public class ProjectFilter
    {
        public string Position { get; set; } = string.Empty;
        public int DateYaer { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
