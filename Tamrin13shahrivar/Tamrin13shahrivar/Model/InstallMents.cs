namespace Tamrin13shahrivar.Model
{
    public class InstallMents
    {
        public int Id { get; set; }
        public DateTime DateLottery { get; set; }

        public  int LotteryMemberId { get; set; }
        public virtual LotteryMember LotteryMember { get; set; }

        public long Mount { get; set; }

        public int Code { get; set; }

    }
}
