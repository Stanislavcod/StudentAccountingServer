
namespace StudentAccounting.Common.FilterModels
{
    public class TrainingCoursesFilter
    {
        public string Lector { get; set; } = string.Empty;
        public int DateYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string status { get; set; } = string.Empty;
    }
} 
