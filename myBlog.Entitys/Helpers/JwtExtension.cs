using Microsoft.AspNetCore.Http;

namespace myBlog.Helpers
{
    public static class JwtExtension
    {
         public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message); //Kullanıcı bir sıkıntı olduğunda bunu görecek.
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");
        }
    }
}