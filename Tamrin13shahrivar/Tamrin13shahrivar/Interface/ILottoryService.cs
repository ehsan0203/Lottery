using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Interface
{
    public interface ILottoryService
    {
        Lottery Create(Lottery lottery);
        LotteryMember FindWinner(int lotteryId);
    }
}
