using System;
using Microsoft.Maui.Controls;
using FlavorFusion.ViewModels;
namespace FlavorFusion
{
    public partial class CreateCategory : ContentPage
    {
        public CreateCategory()
        {
            InitializeComponent();
            BindingContext = new CreateCategoryViewModel();
        }
        private async void BackToCategories_Clicked(object sender, EventArgs e)
        {
            // Navigheaz? înapoi la pagina Categories
            await Shell.Current.GoToAsync("//Categories");
        }
    }
}