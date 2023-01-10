
namespace StudentAccounting.Common.ModelsDto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int StudentCard { get; set; }
        public string Group { get; set; } = string.Empty;
        public int CourseNumber { get; set; }
        public string University { get; set; } = string.Empty;
    }
}
