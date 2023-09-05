using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Interface;
using Tamrin13shahrivar.Model;
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
        public async Task<IActionResult> Create([FromBody]LotteryMember lottery)
        {
            var result =  memberService.Create(lottery);
            return Ok(result);
        }
    }
}
