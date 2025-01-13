using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlavorFusion.Models;

namespace FlavorFusion.ViewModels
{
    public class CreateUserViewModel
    {
        private string _username;
        private string _email;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public ICommand SaveUserCommand { get; }

        public CreateUserViewModel()
        {
            // Comanda pentru a salva utilizatorul
            SaveUserCommand = new Command(async () => await SaveUser());
        }

        private async Task SaveUser()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Email))
            {
                var newUser = new User
                {
                    Username = Username,
                    Email = Email
                };

                // Salvează utilizatorul în baza de date
                await App.Database.SaveUserAsync(newUser);

                // Navighează înapoi la lista de utilizatori
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                // Afișează un mesaj de eroare (opțional)
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
        }

        // Notificarea UI pentru actualizări
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
