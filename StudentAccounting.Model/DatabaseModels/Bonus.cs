
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.Model.DataBaseModels
{
    public class Bonus
    {
        public int Id { get; set; }
        public string BonusName { get; set; } = string.Empty;
        public string BonusDescription { get; set; } = string.Empty;
        public List<Rank>? Ranks { get; set; } = new();
        public List<RankBonus> RankBonus { get; set; } = new();
    }
}
