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
<<<<<<< HEAD
        private readonly WinnerDbContext _context;


        public LotteryService(WinnerDbContext db)
        {
            repo = new LotteryRepository(db);
          
=======
        public LotteryService(WinnerDbContext db)
        {
            repo = new LotteryRepository(db);
>>>>>>> parent of 10d5bf5 (Create Rendom But error)
        }
 

        public LotteryMember FindWinner(int lotteryId)
        {
<<<<<<< HEAD
            List<LotteryMember> candid = new List<LotteryMember>();
            var lotteryMember = _context.LotteryMembers.Where(x => x.LotteryId == lotteryId).ToList();
            var winnerMember = _context.Winners.Where(x => x.lotteryId == lotteryId).Select(x => x.lotteryId).ToList();

            candid.RemoveAll(x => winnerMember.Contains(lotteryId));

            foreach (var item in lotteryMember)
            {
                for (int j = 1; j <= item.NumberMemberShares; j++)
                {
                    candid.Add(item);
                }
            }

            int random = Randomscode(candid.Count);
            return candid[random];
=======
            
>>>>>>> parent of 10d5bf5 (Create Rendom But error)
        }

        Lottery ILottoryService.Create(Lottery lottery)
        {
            return repo.Create(lottery);
        }
    }
}
