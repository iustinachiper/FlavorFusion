using FlavorFusion.ViewModels;
namespace FlavorFusion;

public partial class Create : ContentPage
{
	public Create()
    {
        InitializeComponent();
    }

    private async void BackToList_Clicked(object sender, EventArgs e)
    {
        // Navigare relativ? pentru a reveni la pagina anterioar?
        await Shell.Current.GoToAsync("///Recipes");
    }
}
