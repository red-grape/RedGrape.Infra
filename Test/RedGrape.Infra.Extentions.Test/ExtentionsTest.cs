using Microsoft.Extensions.DependencyInjection;
using RedGrape.Infra.Core.Utils;
using RedGrape.Infra.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RedGrape.Infra.Core.Exceptions;


namespace Test.RedGrape.Infra.Extentions.Test
{
    public class ExtentionsTest
    {
        [Fact()]
        public void add_redGrapeEncryptor_except_get_from_serviceProvider()
        {
            //arrange
            var serviceCollection = new ServiceCollection();
            

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional: false , reloadOnChange: true);
            IConfigurationRoot configurationRoot = builder.Build();
            serviceCollection.AddRedGrapeEncryptor(configurationRoot);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            //act
            var redGrapeEncryptor = serviceProvider.GetService<IRedGrapeEncryptor>();            

            Assert.NotNull(redGrapeEncryptor);

        }


        [Fact]
        public void when_send_decrypt_data_except_get_intial_data()
        {
            //arrange
            var serviceCollection = new ServiceCollection();
            var configurationBinder = new ConfigurationBuilder();
            configurationBinder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configurationRoot = configurationBinder.Build();
            serviceCollection.AddRedGrapeEncryptor(configurationRoot);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var redGrapeEncryptor = serviceProvider.GetService<IRedGrapeEncryptor>();

            //act
            var sample = "sample text";
            var encValue = redGrapeEncryptor.EncryptString(sample);
            var value = redGrapeEncryptor.DecryptString(encValue);

            //assert
            Assert.True(value.Equals(sample));
        }

        [Fact()]
        public void set_invalid_setting_name_except_manage_Exception()
        {
            //arrange
            var serviceCollection = new ServiceCollection();


            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("wrong_appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configurationRoot = builder.Build();
            serviceCollection.AddRedGrapeEncryptor(configurationRoot);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var exp = Assert.Throws<RedGrapeException>(() => serviceProvider.GetService<IRedGrapeEncryptor>() );

            Assert.Equal(RedGrapeErrorCode.not_found_encryptor_config, exp.ErrorCode);

        }


    }
}
