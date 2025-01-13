using FlavorFusion.ViewModels;
namespace FlavorFusion;

public partial class CreateUser : ContentPage
{
	public CreateUser()
	{
		InitializeComponent();
        BindingContext = new CreateUserViewModel();
    }
    private async void SaveUser_Clicked(object sender, EventArgs e)
    {
        // Adaug? logica de salvare a utilizatorului
        await Shell.Current.GoToAsync("..");
    }

    private async void BackToUsers_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Users");
    }
}