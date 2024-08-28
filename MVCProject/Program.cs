namespace MVCProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseRouting();
            app.UseStaticFiles();
            #region MyRegion
            app.Use(async (context, next) =>
                {
                    Endpoint endpoint = context.GetEndpoint();
                    if (endpoint is null)
                    {
                        await context.Response.WriteAsync("Your Requested Page Not Found");
                    }
                    await next();
                });
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/Home", async context =>
                    {
                        await context.Response.WriteAsync("You Are At Home Page!");
                    });
                    //endpoints.MapGet("/Products", async context =>
                    //{
                    //    await context.Response.WriteAsync("You Are At Products Page!");
                    //});
                    endpoints.MapGet("/Products/{id?}", async context =>
                    {
                        var id = context.Request.RouteValues["id"];
                        if (id is not null)
                            await context.Response.WriteAsync($"You Are At Products Page With Id => {id} !");
                        else
                            await context.Response.WriteAsync("You Are At Products Page!");
                    });
                    endpoints.MapGet("/Books/{id}/{author}", async context =>
                    {
                        //int id = Convert.ToInt32(context.Request.RouteValues["id"]);
                        var id = context.Request.RouteValues["id"];
                        string author = context.Request.RouteValues["author"].ToString();
                        await context.Response.WriteAsync($"You Are At Books Page With Id => {id} And Author name =? {author} !");
                    });
                });
            #endregion

            app.MapControllerRoute(
                name : "default",
                pattern : "/{Controller=Home}/{Action=Index}",
                defaults:new {Controller = "Home" , Action = "Index"}
                );

            app.Run();
        }
    }
}
