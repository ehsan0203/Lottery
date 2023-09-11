namespace Tamrin13shahrivar.Model
{
    public class Winner
    {
        public int Id { get; set; }
        public int lotteryId { get; set; }

        public virtual Lottery Lottery { get; set; }
    }
}
