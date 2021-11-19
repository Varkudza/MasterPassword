using MasterPassword.Hash;
using MasterPassword.UseCase.MetaData;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using MasterPassword.Encryptor.Encrypt;

namespace MasterPassword
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IHashBuilder, HashBuilder>();
            services.AddSingleton<IMetaDataBuilder, MetaDataBuilder>();
            services.AddSingleton<IEncrypter, Encrypter>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
