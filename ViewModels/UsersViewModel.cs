using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlavorFusion.Models;

namespace FlavorFusion.ViewModels
{
    public class UsersViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ICommand NavigateToCreateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand EditUserCommand { get; }// Adăugăm comanda pentru Delete


        public UsersViewModel()
        {
            // Inițializează lista de utilizatori
            Users = new ObservableCollection<User>();

            // Comanda pentru a naviga la pagina de creare utilizator
            NavigateToCreateUserCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///CreateUser");
            });

            // Comanda pentru ștergerea utilizatorului
            DeleteUserCommand = new Command<User>(async (user) => await DeleteUser(user));

            // Încarcă utilizatorii
            LoadUsers();
        }

        private async void LoadUsers()
        {
            // Încarcă utilizatorii din baza de date
            var usersFromDb = await App.Database.GetUsersAsync();
            foreach (var user in usersFromDb)
            {
                Users.Add(user);
            }
        }

        private async Task DeleteUser(User user)
        {
            if (user != null)
            {
                await App.Database.DeleteUserAsync(user); // Șterge utilizatorul din baza de date
                Users.Remove(user); // Actualizează interfața
            }
        }

 
    }
}