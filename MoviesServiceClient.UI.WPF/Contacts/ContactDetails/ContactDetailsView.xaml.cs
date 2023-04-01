using System.Linq;
using System.Windows;
using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF.Contacts.ContactDetails
{
    /// <summary>
    /// Interaction logic for ContactDetailsView.xaml
    /// </summary>
    public partial class ContactDetailsView
    {
        private ContactDetailsView()
        {
            InitializeComponent();
        }

        public ContactDetailsView(ContactDetailsViewModel contactDetailsViewModel) : this()
        {
            DataContext = contactDetailsViewModel;
            Loaded += async (sender, args) => await contactDetailsViewModel.Load();
            contactDetailsViewModel.SavingFinished += (sender, args) => Close();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close(bool result = false)
        {
            var flyout = Application.Current.MainWindow.GetVisualDescendents().FirstOrDefault(c => c is FlyoutControl) as FlyoutControl;
            if (flyout != null)
                flyout.Close(result);
        }
    }
}
