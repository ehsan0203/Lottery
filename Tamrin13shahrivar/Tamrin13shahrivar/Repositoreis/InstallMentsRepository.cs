using Microsoft.AspNetCore.Mvc;
using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Repositoreis
{
    public class InstallMentsRepository
    {
        private readonly WinnerDbContext db;
        public InstallMentsRepository(WinnerDbContext _db)
        {
            db = _db;
        }
        public InstallMents Create(InstallMents item)
        {
            try
            {
                db.InstallMents.Add(item);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return item;
        }

        public InstallMents Delete(int id)
        {
            var result =db.InstallMents.FirstOrDefault(x => x.LotteryMemberId == id);
            db.InstallMents.Remove(result);
            db.SaveChanges() ;
            return result;
        }
        //[HttpGet]
        //public IHttpActionResult GetRandomNumber()
        //{
        //    // ایجاد یک نمونه از کلاس Random
        //    Random random = new Random();

        //    // تولید یک عدد رندم 7 رقمی
        //    int randomNumber = random.Next(1000000, 9999999);

        //    return Ok(randomNumber);
        //}
        public InstallMents Pay(int code)
        {
            var result = db.LotteryMembers.FirstOrDefault(x => x.CodeMelli == code);
            if (result != null)
            {
                var find = db.InstallMents.FirstOrDefault(x => x.Code == 0 && x.LotteryMemberId==result.Id);

                if (find != null)
                {
                    Random random = new Random();
                    int randomTrackingCode = random.Next(10000000, 99999999);
                    find.Code = randomTrackingCode;

                    var domain = new InstallMents
                    {
                        DateLottery = find.DateLottery,
                        LotteryMemberId = find.LotteryMemberId,
                        Mount = find.Mount,
                        NumLottery = find.NumLottery,
                        Code = find.Code
                    };
                    domain.Code = find.Code;
                    // ذخیره اطلاعات در دیتابیس
                    db.SaveChanges();

                    return domain;
                }
            }

            return null;
        }
        public List<InstallMents> GetNoPay(int code)
        {
            var result = db.LotteryMembers.FirstOrDefault(x => x.CodeMelli == code);
            if (result != null)
            {
                var noPayInstallments = db.InstallMents.Where(x => x.Code == 0 && x.LotteryMemberId == result.Id).ToList();

                return noPayInstallments;
            }
            return null; // در صورتی که هیچ کاربری با کد ملی مورد نظر پیدا نشود.
        }
        public List<InstallMents> GetPay(int code)
        {
            var result = db.LotteryMembers.FirstOrDefault(x => x.CodeMelli == code);
            if (result != null)
            {
                var YesPayInstallments = db.InstallMents.Where(x => x.Code > 0 && x.LotteryMemberId == result.Id).ToList();

                return YesPayInstallments;
            }
            return null; // در صورتی که هیچ کاربری با کد ملی مورد نظر پیدا نشود.
        }


    }
}
