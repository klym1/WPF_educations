using System.Windows.Input;

namespace MoviesServiceClient.WPF.Contacts.ContactList
{
    public partial class ContactListView
    {
        private readonly ContactListViewModel _contactListViewModel;

        public ContactListView()
        {
            InitializeComponent();
        }

        public ContactListView(ContactListViewModel contactListViewModel) : this()
        {
            _contactListViewModel = contactListViewModel;

            DataContext = contactListViewModel;

            Loaded += async (sender, args) =>
            {
                await contactListViewModel.Load();
            };
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (_contactListViewModel != null)
                {
                    e.Handled = true;
                   _contactListViewModel.EditDetailsCommand.Execute(null);
                }
            }
        }
    }
}
