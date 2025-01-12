using FlavorFusion.ViewModels;
namespace FlavorFusion;

public partial class MealPlans : ContentPage
{
	public MealPlans()
	{
		InitializeComponent();
        BindingContext = new MealPlansViewModel();
    }
}