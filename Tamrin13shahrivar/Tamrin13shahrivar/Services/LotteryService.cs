using Microsoft.EntityFrameworkCore;
using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Interface;
using Tamrin13shahrivar.Model;
using Tamrin13shahrivar.Repositoreis;

namespace Tamrin13shahrivar.Services
{
    public class LotteryService : ILottoryService
    {
        private readonly LotteryRepository repo;
        private readonly WinnerDbContext _context;
        public LotteryService(WinnerDbContext db, WinnerDbContext context = null)
        {
            repo = new LotteryRepository(db);
            _context = context;
        }
        public int RandomsCode(int selectmember)
        {
            return new Random().Next(0,(int)selectmember);
        }

        public LotteryMember FindWinner(int lotteryId)
        {
            List<LotteryMember> Candid = new List<LotteryMember>();
            var lotorymember = _context.LotteryMembers.Where(x=>x.lotteryId == lotteryId).ToList();
            var winnerMember = _context.Winners.Where(x=>x.lotteryId==lotteryId).ToList();
            foreach(var item in lotorymember)
            {
                for(int j = 1; j <= item.NumberMemberShares; j++)
                {
                    Candid.Add(item);
                }
            }
            foreach(var item in winnerMember)
            {
                var removeitem = Candid.FirstOrDefault(x => x.Id == item.Id);
                Candid.Remove(removeitem);
            }
            int random = RandomsCode(Candid.Count);
            return Candid[random];
        }

        Lottery ILottoryService.Create(Lottery lottery)
        {
            return repo.Create(lottery);
        }
    }
}
