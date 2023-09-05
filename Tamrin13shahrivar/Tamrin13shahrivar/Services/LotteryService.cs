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
        public LotteryService(WinnerDbContext db)
        {
            repo = new LotteryRepository(db);
        }
 

        public LotteryMember FindWinner(int lotteryId)
        {
            
        }

        Lottery ILottoryService.Create(Lottery lottery)
        {
            return repo.Create(lottery);
        }
    }
}
