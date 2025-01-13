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
    public class RecipesViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; } // Listă pentru a afișa rețetele

        // Comandă pentru navigarea către pagina Create
        public ICommand NavigateToCreateCommand { get; }

        // Comandă pentru ștergerea unei rețete
        public ICommand DeleteRecipeCommand { get; }

        public RecipesViewModel()
        {
            // Inițializează lista de rețete
            Recipes = new ObservableCollection<Recipe>();

            // Comandă pentru a naviga către pagina Create
            NavigateToCreateCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///Create");
            });

            // Comandă pentru ștergerea unei rețete
            DeleteRecipeCommand = new Command<Recipe>(async (recipe) => await DeleteRecipe(recipe));

            // Încarcă rețetele existente din baza de date
            LoadRecipes();
        }

        private async void LoadRecipes()
        {
            try
            {
                var recipesFromDb = await App.Database.GetRecipesAsync(); // Încarcă din baza de date
                Recipes.Clear();
                foreach (var recipe in recipesFromDb)
                {
                    Recipes.Add(recipe); // Adaugă fiecare rețetă în listă
                }
            }
            catch (Exception ex)
            {
                // Loghează eroarea (opțional)
                Console.WriteLine($"Error loading recipes: {ex.Message}");
            }
        }

        private async Task DeleteRecipe(Recipe recipe)
        {
            if (recipe != null)
            {
                try
                {
                    // Șterge rețeta din baza de date
                    await App.Database.DeleteRecipeAsync(recipe);

                    // Actualizează lista de rețete
                    Recipes.Remove(recipe);
                }
                catch (Exception ex)
                {
                    // Loghează eroarea (opțional)
                    Console.WriteLine($"Error deleting recipe: {ex.Message}");
                }
            }
        }
    }
}