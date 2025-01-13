using FlavorFusion.ViewModels;
namespace FlavorFusion;
using FlavorFusion.Models;

public partial class Users : ContentPage
{
	public Users()
	{
		InitializeComponent();
        BindingContext = new UsersViewModel();
    }
    private async void CreateUser_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///CreateUser");
    }

    private async void EditUser_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var user = button?.BindingContext as User;
        if (user != null)
        {
            await Shell.Current.GoToAsync($"EditUser?userId={user.Id}");
        }
    }

}