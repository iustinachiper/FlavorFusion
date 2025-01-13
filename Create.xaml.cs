using FlavorFusion.ViewModels;
namespace FlavorFusion;

public partial class Create : ContentPage
{
	public Create()
    {
        InitializeComponent();
        BindingContext = new CreateViewModel();
    }

    private async void BackToList_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Recipes");
    }
}
