using MasterPassword.Hash;
using MasterPassword.UseCase.MetaData;
using System.Windows;

namespace MasterPassword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMetaDataBuilder metaDataBuilder;

        public MainWindow(IMetaDataBuilder metaDataBuilder)
        {
            InitializeComponent();
            this.metaDataBuilder = metaDataBuilder;
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {            
            this.GeneratedPasswordTb.Text = this.metaDataBuilder.Build(PasswordBox.Password, DomainTb.Text, UserNameTb.Text, (int)PassworSizeSl.Value);
        }
    }
}
