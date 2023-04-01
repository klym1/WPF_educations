using DAL;
using Domain;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.Contacts.ContactDetails;
using MoviesServiceClient.WPF.Contacts.ContactList;
using MoviesServiceClient.WPF.ContainerConfiguration.NavigatorImplementations;
using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF.ContainerConfiguration.EntitiesRegistrations
{
    public class ContactsContainerRegistrations : IContainerRegistrations
    {
        public IUnityContainer AddRegistrations(IUnityContainer container)
        {
            return container
                .AddRegistrations(RegisterList)
                .AddRegistrations(AddContact)
                .AddRegistrations(EditContact);
        }

        private static IUnityContainer RegisterList(IUnityContainer container)
        {
            return container
                .RegisterViewNavigator<ListViewNavigator<ContactListView>>(ViewName.Contacts.ContactList);
        }

        private static IUnityContainer AddContact(IUnityContainer container)
        {
            return container
                .RegisterViewNavigator<AddViewNavigator<ContactDetailsView>>(ViewName.Contacts.AddContact)
                .RegisterType<IDetailsStrategy, AddDetailsStrategy>("Add")
                .RegisterType<ContactDetailsView>(
                    "Add",
                    new InjectionConstructor(
                        new ResolvedParameter<ContactDetailsViewModel>("Add")))
                .RegisterType<ContactDetailsViewModel>(
                    "Add",
                    new InjectionConstructor(
                        new ResolvedParameter<IGenericRepository<Contact>>(),
                        new ResolvedParameter<IDetailsStrategy>("Add")));

        }

        private static IUnityContainer EditContact(IUnityContainer container)
        {
            return container
                .RegisterViewNavigator<EditViewNavigator<ContactDetailsView>>(ViewName.Contacts.EditDetails)
                .RegisterType<IDetailsStrategy, EditDetailsStrategy>("Edit")
                 .RegisterType<ContactDetailsView>(
                    "Edit",
                    new InjectionConstructor(
                        new ResolvedParameter<ContactDetailsViewModel>("Edit")))
                .RegisterType<ContactDetailsViewModel>(
                    "Edit",
                    new InjectionConstructor(
                        new ResolvedParameter<IGenericRepository<Contact>>(),
                        new ResolvedParameter<IDetailsStrategy>("Edit")), 
                        
                        new InjectionProperty("NavigationContext"));
        }
    }
}
