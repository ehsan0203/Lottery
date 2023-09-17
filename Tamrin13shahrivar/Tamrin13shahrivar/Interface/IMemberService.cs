using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Interface
{
    public interface IMemberService
    {
        LotteryMember Create(LotteryMember item);

        LotteryMember Delete(int id);
    }
}
