using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CodingTest.LongestRisingSequence
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static IServiceCollection Configure(IServiceCollection services = null)
        {
            services ??= new ServiceCollection();

            services.AddSingleton<ILongestRisingSequenceFinder, LongestRisingSequenceFinder>();
            services.AddSingleton<ISequenceFinderHelper, SequenceFinderHelper>();
            services.AddSingleton<IValidationHelper, ValidationHelper>();
            return services;
        }
    }
}