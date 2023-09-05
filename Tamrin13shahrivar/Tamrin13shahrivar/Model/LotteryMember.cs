using DocumentFormat.OpenXml.CustomProperties;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.Azure.Amqp.Framing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamrin13shahrivar.Model
{
    public class LotteryMember
    {
        public int Id { get; set; }

        public string MemberFullName { get; set; }

        public int NumberMemberShares { get; set; }
        public int LotteryId { get; set; }
        public Lottery? Lottery { get; set; }

    }
}
