using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF.Contacts.ContactDetails
{
    public interface IViewModelWithNavigationContext
    {
        NavigationContext NavigationContext { get; }
    }
}