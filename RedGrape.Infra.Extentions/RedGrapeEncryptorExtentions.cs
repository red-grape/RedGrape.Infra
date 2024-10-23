using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedGrape.Infra.Core.Exceptions;
using RedGrape.Infra.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGrape.Infra.Extentions
{
    public static class RedGrapeEncryptorExtentions
    {
        public static IServiceCollection AddRedGrapeEncryptor(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddSingleton(sp =>
            {
                var configName = "RedGrape.Encryptor";

               
                var configSection = configuration.GetSection(key: configName);
                ThrowHelper.ThrowIf(() => configSection.Exists(), 
                    $"could not found '{configName}' in config file." , 
                    RedGrapeErrorCode.not_found_encryptor_config);
                RedGrapeEncryptorConfig redGrapeEncryptorConfig = new RedGrapeEncryptorConfig();
                configuration.GetSection(key: configName).Bind(redGrapeEncryptorConfig);

                
                ThrowHelper.ThrowIfSmallThan(nameof(redGrapeEncryptorConfig.Key) , redGrapeEncryptorConfig.Key , 16);
                ThrowHelper.ThrowIfSmallThan(nameof(redGrapeEncryptorConfig.IV), redGrapeEncryptorConfig.IV, 16);

                if (redGrapeEncryptorConfig == null)
                    throw new Exception($"for use redGrapeEncryptor must set {configName} section in appsettings.json");

                IRedGrapeEncryptor redGrapeEncryptor = new RedGrapeEncryptor(redGrapeEncryptorConfig.Key, redGrapeEncryptorConfig.IV);
                return redGrapeEncryptor;
            });

            return services;
        }


    }
}
