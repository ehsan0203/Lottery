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
    public class LotteryController : ControllerBase
    {
        private readonly ILottoryService _lottoryService;

        public LotteryController(WinnerDbContext db )
        {
            _lottoryService = new LotteryService(db);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Creat(LotteryDto lotterydto)
        {
            var domain = new Lottery
            {
                AmountShares = lotterydto.AmountShares,
                NumberShares = lotterydto.NumberShares,
                TitleLottery = lotterydto.TitleLottery
        };
           _lottoryService.Create(domain);
                return Ok(lotterydto);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,LotteryRequestDto lotteryDto)
        {
            var domain = new Lottery
            {
                TitleLottery = lotteryDto.TitleLottery
            };
           var result= _lottoryService.Update(id,domain);
            var dto = new LotteryDto
            {
                AmountShares = result.AmountShares,
                NumberShares = result.NumberShares,
                TitleLottery = result.TitleLottery

            };
            return Ok(dto);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _lottoryService.Delete(id);
            if (result != null )
            {
                return Ok($"لاتاری {result.TitleLottery} حذف شد");
            }
            return NotFound("این لاتاری وجود خارجی ندارد یا عضو دارد");
        }



    }
}
