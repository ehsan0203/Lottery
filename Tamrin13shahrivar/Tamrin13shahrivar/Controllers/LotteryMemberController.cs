using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Interface;
using Tamrin13shahrivar.Model;
using Tamrin13shahrivar.Model.DTO;
using Tamrin13shahrivar.Services;

namespace Tamrin13shahrivar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotteryMemberController : ControllerBase
    {
        private readonly IMemberService memberService;

        public LotteryMemberController( WinnerDbContext db )
        {
           memberService = new MemberService(db);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LotteyMemberDTO lottery)
        {

            var domain = new LotteryMember { MemberFullName = lottery.MemberFullName , NumberMemberShares=lottery.NumberMemberShares
            ,lotteryId=lottery.lotteryId};
            var result =  memberService.Create(domain);
            if (result.NumberMemberShares<domain.NumberMemberShares)
            {
                return BadRequest($"شما بیش از اندازه انتخاب کردید مقدار باقی مانده : {result.NumberMemberShares}");
            }
            return Ok(result);
        }
    }
}
