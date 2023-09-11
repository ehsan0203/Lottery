using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Repositoreis
{
    public class LotteryMemberRepository
    {
        private readonly WinnerDbContext db;
        public LotteryMemberRepository(WinnerDbContext _db)
        {
            db = _db;
        }
        public LotteryMember Create(LotteryMember item)
        {
            try
            {
               
                db.LotteryMembers.Add(item);
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {

            }
            return item;
        }

        public LotteryMember SumShares(LotteryMember item,int id)
        {

            var sumshares = db.LotteryMembers.Where(x=>x.lotteryId==id).Sum(x => x.NumberMemberShares);
            var result = new LotteryMember()
            {
                Id = item.Id,
                NumberMemberShares = sumshares
            };

            return result;
        }
    }
}
