using System.ComponentModel.DataAnnotations.Schema;

namespace Tamrin13shahrivar.Model
{
    public class LotteryMember
    {
        public int Id { get; set; }

        public string MemberFullName { get; set; }

        public int NumberMemberShares { get; set; }


        public int lotteryId { get; set; }
        
        public virtual Lottery Lottery { get; set; }    


    }
}
