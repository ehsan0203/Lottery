namespace Tamrin13shahrivar.Model
{
    public class Winner
    {
        public int Id { get; set; }

        public DateTime MonthWin { get; set; }

        public string MemberWinner { get; set; }

        public int NumLottery { get; set; }

        public int LotteryMemberid { get; set; }
        public LotteryMember LotteryMember { get; set; }

    }
}
