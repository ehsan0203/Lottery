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
    public class LotteryController : ControllerBase
    {
        private readonly ILottoryService _lottoryService;

        public LotteryController(WinnerDbContext db )
        {
            _lottoryService = new LotteryService(db);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Creat(Lottery lottery)
        {
            var result = _lottoryService.Create(lottery);
                return Ok(result);
        }

    }
}
