using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.Contacts.ContactDetails;
using MoviesServiceClient.WPF.ContainerConfiguration;
using MoviesServiceClient.WPF.Controls;
using MoviesServiceClient.WPF.Navigation;
using MoviesServiceClient.WPF.ViewModel;

namespace MoviesServiceClient.WPF.Contacts.ContactList
{
    public class ContactListViewModel : INotifyPropertyChanged
    {
        private readonly IGenericRepository<Contact> _contactRepository;
        private readonly INavigation _navigation;

        public ObservableCollection<ContactModel> ContactModels { get; private set; }

        public RelayCommand AddOrderCommand { get; private set; }
        public RelayCommand EditDetailsCommand { get; private set; }
        public RelayCommand AddContactCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }

        [Microsoft.Practices.Unity.Dependency]
        public IUnityContainer UnityContainer { get; set; }

        public ContactListViewModel(
            IGenericRepository<Contact> contactRepository,
            INavigation navigation

            )
        {
            Registry.ViewModelsRegistry["ContactList"] = this;

            _contactRepository = contactRepository;
            _navigation = navigation;

            ContactModels = new ObservableCollection<ContactModel>();

            EditDetailsCommand = new RelayCommand(EditDetailsAction, () => SelectedContactModel != null);
            AddContactCommand = new RelayCommand(AddContact);
            DeleteCommand = new RelayCommand(DeleteContact);
        }

        public ContactModel SelectedContactModel { get; set; }
        

        private void AddContact()
        {
            _navigation.NavigateTo(ViewName.Contacts.AddContact);
        }

        private async void DeleteContact()
        {
            await _contactRepository.HardDeleteEntity(SelectedContactModel.Id);
            await Load();
        }

        private void EditDetailsAction()
        {
            _navigation.NavigateTo(ViewName.Contacts.EditDetails, new NavigationContext
            {
                Parameters = new Dictionary<string, object>
                {
                    {"ContactId", SelectedContactModel.Id}
                }
            }, true);
        }   

        public async Task Load()
        {
            ContactModels.Clear();

            var entities = await _contactRepository.GetEntitiesAsync();

            ContactModels.Clear();

            foreach (var result in entities.Select(ContactConverters.ToModel).OrderBy(it => it.FullName))
            {
                ContactModels.Add(result);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
