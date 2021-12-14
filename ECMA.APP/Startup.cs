using ECMA.APP.Mapper;
using ECMA.APP.Models;
using ECMA.APP.Repository;
using ECMA.APP.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(ECMA.APP.Startup))]

namespace ECMA.APP
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IECMARepo, ECMARepo>();
            builder.Services.AddScoped<IECMAService, ECMAService>();
            builder.Services.AddScoped<IContractMapper, ContractMapper>();

            string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            builder.Services.AddDbContext<EcmaContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
}
