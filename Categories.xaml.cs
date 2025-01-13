namespace FlavorFusion;
using FlavorFusion.ViewModels;
using FlavorFusion.Models;

public partial class Categories : ContentPage
{
	public Categories()
	{
		InitializeComponent();
        BindingContext = new CategoriesViewModel();
    }

    private async void EditCategory_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var category = button?.BindingContext as Category;
        if (category != null)
        {
            await Shell.Current.GoToAsync($"EditCategory?categoryId={category.Id}");
        }
    }
}