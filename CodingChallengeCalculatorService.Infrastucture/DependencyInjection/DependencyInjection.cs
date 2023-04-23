using CodingChallengeCalculatorService.Application.Service.Implementation;
using CodingChallengeCalculatorService.Application.Service.Interface;
using CodingChallengeCalculatorService.Domain.Repository;
using CodingChallengeCalculatorService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallengeCalculatorService.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorService, CalculatorService>();
            services.AddScoped<IJournalService, JournalService>();
            services.AddSingleton<IRecordOperationRepository, RecordOperationRepository>();

            return services;
        }

    }
}
