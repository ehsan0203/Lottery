namespace Tamrin13shahrivar.CustomeMiddleware
{
    public class BadWorlds
    {

        private readonly RequestDelegate _next;

        public BadWorlds(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // بررسی اطلاعات درخواست
            if (context.Request.Method == "POST" && context.Request.Path == "/api/Lottery/Create")
            {
                string requestBody;
                using (var reader = new StreamReader(context.Request.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                // اینجا می‌توانید اطلاعات را بررسی کنید
                if (ContainsBadWords(requestBody))
                {
                    
                    await context.Response.WriteAsync("متن حاوی کلمات نامناسب است.");
                    return;
                }
            }

            await _next(context);
        }

        private bool ContainsBadWords(string text)
        {
 if (text.Contains("khar") || text.Contains("gav"))
 {
     return true;
 }

            return false;
        }
    }
}
