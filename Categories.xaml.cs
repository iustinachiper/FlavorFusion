namespace FlavorFusion;
using FlavorFusion.ViewModels;

public partial class Categories : ContentPage
{
	public Categories()
	{
		InitializeComponent();
        BindingContext = new CategoriesViewModel();
    }
}