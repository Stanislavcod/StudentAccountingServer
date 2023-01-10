
namespace StudentAccounting.Common.ModelsDto
{
    public class ParticipantsDto
    {
        public int Id { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime DateExit { get; set; }
        public string Status { get; set; } = string.Empty;
        public string GitHub { get; set; } = string.Empty;
    }
}
