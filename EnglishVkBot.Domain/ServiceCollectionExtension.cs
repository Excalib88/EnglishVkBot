using AutoMapper;
using EnglishVkBot.Domain.Commands;
using EnglishVkBot.Domain.Queries.LanguageDirections;
using Microsoft.Extensions.DependencyInjection;
using Zarnitza.CQRS;

namespace EnglishVkBot.Domain
{
    public static class ServiceCollectionExtension
    	{
    		public static void AddDomain(this IServiceCollection serviceCollection)
    		{
    			serviceCollection.BindMapper();
    			serviceCollection.AddCqrs(typeof(CreateLanguageDirectionCommand));
    		}
    
    		private static void BindMapper(this IServiceCollection serviceCollection)
    		{
    			Mapper.Initialize(cfg => { cfg.AddProfiles(typeof(GetLanguageByIdQuery).Assembly); });
    			serviceCollection.AddScoped<IMapper>(p => new Mapper(Mapper.Configuration));
    		}
    	}
}