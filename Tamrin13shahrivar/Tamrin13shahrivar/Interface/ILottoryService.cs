using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Interface
{
    public interface ILottoryService
    {
        Lottery Create(Lottery lottery);
        Lottery Update(int id, Lottery lottery);
        Lottery Delete(int id);

        LotteryMember FindWinner(int lotteryId);
    }
}
