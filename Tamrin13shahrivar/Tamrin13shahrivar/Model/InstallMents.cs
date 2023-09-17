namespace Tamrin13shahrivar.Model
{
    public class InstallMents
    {
        public int Id { get; set; }
        public DateTime DateLottery { get; set; }

        public int NumLottery { get; set; }
        public int LotteryMemberId { get; set; }
        public virtual LotteryMember LotteryMember { get; set; } // نقشه (navigation property) برای ارتباط با مدل LotteryMember

        public long Mount { get; set; }
        public int Code { get; set; }
    }

}
