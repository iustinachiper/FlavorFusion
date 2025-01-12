namespace FlavorFusion;

public partial class Recipes : ContentPage
{
	public Recipes()
	{
		InitializeComponent();
        BindingContext = new ViewModels.RecipesViewModel();
    }
}