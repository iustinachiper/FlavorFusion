using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlavorFusion.ViewModels;
using FlavorFusion.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace FlavorFusion.ViewModels
{
    public class CreateViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _instructions;
        private string _ingredients;
        private Category _selectedCategory;
        private User _selectedUser;

        public ObservableCollection<Category> Categories { get; private set; }
        public ObservableCollection<User> Users { get; private set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Instructions
        {
            get => _instructions;
            set
            {
                _instructions = value;
                OnPropertyChanged();
            }
        }

        public string Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged();
            }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveRecipeCommand { get; }

        public CreateViewModel()
        {
            Categories = new ObservableCollection<Category>();
            Users = new ObservableCollection<User>();

            // Load categories and users from the database
            LoadData();

            // Initialize SaveRecipeCommand
            SaveRecipeCommand = new Command(async () => await SaveRecipe());
        }

        private async void LoadData()
        {
            try
            {
                // Clear existing items
                Categories.Clear();
                Users.Clear();

                // Load categories from database
                var categories = await App.Database.GetCategoriesAsync();
                if (categories != null && categories.Any())
                {
                    foreach (var category in categories)
                    {
                        Categories.Add(category);
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Info", "No categories found.", "OK");
                }

                // Load users from database
                var users = await App.Database.GetUsersAsync();
                if (users != null && users.Any())
                {
                    foreach (var user in users)
                    {
                        Users.Add(user);
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Info", "No users found.", "OK");
                }

                OnPropertyChanged(nameof(Categories));
                OnPropertyChanged(nameof(Users));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to load data: {ex.Message}", "OK");
            }
        }

        private async Task SaveRecipe()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Name) &&
                    !string.IsNullOrWhiteSpace(Instructions) &&
                    SelectedCategory != null &&
                    SelectedUser != null)
                {
                    var newRecipe = new Recipe
                    {
                        Name = Name,
                        Instructions = Instructions,
                        CategoryId = SelectedCategory.Id,
                        UserId = SelectedUser.Id,
                    };

                    // Save the recipe to the database
                    await App.Database.SaveRecipeAsync(newRecipe);

                    // Navigate back to the recipes list
                    await Shell.Current.GoToAsync("//Recipes");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to save recipe: {ex.Message}", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}