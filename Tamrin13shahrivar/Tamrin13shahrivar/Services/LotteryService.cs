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
        private readonly LotteryMemberRepository repomem;

        public LotteryService(WinnerDbContext db)
        {
            repo = new LotteryRepository(db);
            repomem = new LotteryMemberRepository(db);

        }



        Lottery ILottoryService.Create(Lottery lottery)
        {
            return repo.Create(lottery);
        }

        public Lottery Update(int id, Lottery lottery)
        {
            return repo.Update(id, lottery);
        }

        public Lottery Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
