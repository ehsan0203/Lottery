using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Interface;
using Tamrin13shahrivar.Model;
using Tamrin13shahrivar.Repositoreis;

namespace Tamrin13shahrivar.Services
{
    public class MemberService : IMemberService
    {
        private readonly LotteryMemberRepository repo;
        private readonly LotteryRepository repoLottery;
        private readonly InstallMentsRepository repoInstallment;
        public MemberService(WinnerDbContext db)
        {
            repo = new LotteryMemberRepository(db);
            repoLottery = new LotteryRepository(db);
            repoInstallment = new InstallMentsRepository(db);
        }

        public LotteryMember Create(LotteryMember item)
        {
            item = repo.Create(item);
            DateTime data = new DateTime(DateTime.Now.Year, DateTime.Now.Month,1);
            
           Lottery lotteryItem =  repoLottery.Get(item.Id);
            for (int i = 0; i < lotteryItem.NumberShares; i++)
            {
                data = data.AddMonths(1);
                repoInstallment.Create(new InstallMents()
                {
                    DateLottery = data,
                    LotteryMemberId = item.Id,
                    Mount = item.NumberMemberShares * lotteryItem.AmountShares
                }) ;
            }

            return item;
        }
    }
}
