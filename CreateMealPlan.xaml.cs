using FlavorFusion.ViewModels;

namespace FlavorFusion
{
    public partial class CreateMealPlan : ContentPage
    {
        public CreateMealPlan()
        {
            InitializeComponent();
            BindingContext = new CreateMealPlanViewModel();
        }
        private async void BackToMealPlans_Clicked(object sender, EventArgs e)
        {
            // Navigheaz? înapoi la pagina Meal Plans
            await Shell.Current.GoToAsync("//MealPlans");
        }

    }
}
