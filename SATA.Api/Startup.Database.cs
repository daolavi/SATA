using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SATA.Repository;
using System;

namespace SATA.Api
{
    public partial class Startup
    {
        public void InitializeDb(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SATADbContext>();
                    SATADbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
