using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Profiles
{
    public static class MapperServiceExtensions
    {
        public static void AddMapperService(this IServiceCollection services, ILoggerFactory loggerFactory)
        {
            var configExpression = new MapperConfigurationExpression();
            configExpression.AddProfile<Mapper>(); // Add your profile

            var mapperConfig = new MapperConfiguration(configExpression, loggerFactory); // No lambda

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
