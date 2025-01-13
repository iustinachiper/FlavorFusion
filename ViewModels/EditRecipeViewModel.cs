using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlavorFusion.Models;

namespace FlavorFusion.ViewModels
{
    public class EditRecipeViewModel : INotifyPropertyChanged
    {
        private Recipe _recipe;

        public string Name { get => _recipe.Name; set { _recipe.Name = value; OnPropertyChanged(); } }
        public string Instructions { get => _recipe.Instructions; set { _recipe.Instructions = value; OnPropertyChanged(); } }
        public Category SelectedCategory { get; set; }
        public User SelectedUser { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<User> Users { get; set; }

        public ICommand SaveRecipeCommand { get; }
        public ICommand CancelCommand { get; }

        public EditRecipeViewModel(int recipeId)
        {
            Categories = new ObservableCollection<Category>();
            Users = new ObservableCollection<User>();

            LoadData(recipeId);

            SaveRecipeCommand = new Command(async () => await SaveChanges());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        private async void LoadData(int recipeId)
        {
            _recipe = await App.Database.GetRecipeAsync(recipeId);
            var categories = await App.Database.GetCategoriesAsync();
            var users = await App.Database.GetUsersAsync();

            foreach (var category in categories)
                Categories.Add(category);

            foreach (var user in users)
                Users.Add(user);

            SelectedCategory = Categories.FirstOrDefault(c => c.Id == _recipe.CategoryId);
            SelectedUser = Users.FirstOrDefault(u => u.Id == _recipe.UserId);
        }

        private async Task SaveChanges()
        {
            _recipe.CategoryId = SelectedCategory.Id;
            _recipe.UserId = SelectedUser.Id;

            await App.Database.SaveRecipeAsync(_recipe);
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

