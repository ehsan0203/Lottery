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
        private readonly WinnerRepository repoWinner;
        public MemberService(WinnerDbContext db)
        {
            repo = new LotteryMemberRepository(db);
            repoLottery = new LotteryRepository(db);
            repoInstallment = new InstallMentsRepository(db);
        }

        public LotteryMember Create(LotteryMember item)
        {
            Lottery lotteryItemtest = repoLottery.Get(item.lotteryId);
            var sumtest = repo.SumShares(item, item.lotteryId);
            int Average = sumtest.NumberMemberShares + item.NumberMemberShares;
            var result = new LotteryMember()
            {
                Id = item.Id,
                NumberMemberShares = lotteryItemtest.NumberShares - sumtest.NumberMemberShares
            };
            if (Average <= lotteryItemtest.NumberShares)
            {
                item = repo.Create(item);
            }
            else
            {
                return result;
            }
            DateTime data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Lottery lotteryItem = repoLottery.Get(item.lotteryId);

            var sum = repo.SumShares(item, item.lotteryId);
            var menha = lotteryItem.NumberShares - sum.NumberMemberShares;

            if (sum.NumberMemberShares <= lotteryItem.NumberShares)
            {
                for (int i = 0; i < lotteryItem.NumberShares; i++)
                {

                    data = data.AddMonths(1);
                    repoInstallment.Create(new InstallMents()
                    {
                        NumLottery=item.lotteryId,
                        DateLottery = data,
                        LotteryMemberId = item.Id,
                        Mount = item.NumberMemberShares * lotteryItem.AmountShares
                    });



                }
            }
            else
            {
                var result1 = new LotteryMember()
                {
                    Id = item.Id,
                    NumberMemberShares = menha
                };
                return result1;


            }



            return item;
        }

        public LotteryMember Delete(int id)
        {
            repoInstallment.Delete(id);

            return repo.Delete(id);
        }

        public List<InstallMents> GetNoPay(int code)
        {
            return repoInstallment.GetNoPay(code);
        }

        public List<InstallMents> GetPay(int code)
        {
           return repoInstallment.GetPay(code);
        }

        public InstallMents Pay(int code)
        {
            return repoInstallment.Pay(code);
        }

        List<Winner> IMemberService.FindWinner(int lotteryId)
        {
            return repo.RunMonthlyLottery(lotteryId);
        }


    }
}
