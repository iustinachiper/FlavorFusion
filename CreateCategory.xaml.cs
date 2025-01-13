using System;
using Microsoft.Maui.Controls;
using FlavorFusion.ViewModels;
using FlavorFusion.Models;
using System.Threading.Tasks;

namespace FlavorFusion
{
    public partial class CreateCategory : ContentPage
    {
        public CreateCategory()
        {
            InitializeComponent();
            BindingContext = new CreateCategoryViewModel();
        }

        private async void SaveCategory_Clicked(object sender, EventArgs e)
        {
            // Ob?ine numele categoriei din BindingContext (ViewModel)
            var viewModel = BindingContext as CreateCategoryViewModel;

            if (viewModel != null && !string.IsNullOrWhiteSpace(viewModel.CategoryName))
            {
                var category = new Category
                {
                    Name = viewModel.CategoryName
                };

                // Apeleaz? metoda SaveCategoryAsync din baza de date
                await App.Database.SaveCategoryAsync(category);

                // Navigheaz? înapoi la lista de categorii
                await Shell.Current.GoToAsync("//Categories");
            }
            else
            {
                // Afi?eaz? o alert? dac? numele categoriei este gol
                await DisplayAlert("Error", "Please enter a valid category name.", "OK");
            }
        }

        private async void BackToCategories_Clicked(object sender, EventArgs e)
        {
            // Navigheaz? înapoi la pagina Categories
            await Shell.Current.GoToAsync("//Categories");
        }
    }
}
