using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlavorFusion.Models;
using FlavorFusion.Data;

namespace FlavorFusion.ViewModels
{
    public class CategoriesViewModel
    {
        private readonly FlavorFusionDatabase _database;

        public ObservableCollection<Category> Categories { get; set; } // Lista categoriilor
        public ICommand NavigateToCreateCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }

        public CategoriesViewModel()
        {
            // Inițializează baza de date
            _database = App.Database;

            // Inițializează colecția
            Categories = new ObservableCollection<Category>();

            // Încarcă categoriile din baza de date
            LoadCategoriesAsync();

            // Command pentru navigare la pagina CreateCategory
            NavigateToCreateCategoryCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///CreateCategory");
            });

            // Command pentru ștergerea unei categorii
            DeleteCategoryCommand = new Command<Category>(async (category) =>
            {
                if (category != null)
                {
                    await _database.DeleteCategoryAsync(category);
                    await LoadCategoriesAsync();
                }
            });
        }

        private async Task LoadCategoriesAsync()
        {
            // Golește colecția curentă
            Categories.Clear();

            // Încarcă categoriile din baza de date
            var categories = await _database.GetCategoriesAsync();

            // Adaugă categoriile în ObservableCollection
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }
    }
}