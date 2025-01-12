using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlavorFusion.ViewModels
{
    public class MealPlansViewModel
    {
        public ICommand NavigateToCreateMealPlanCommand { get; }

        public MealPlansViewModel()
        {
            NavigateToCreateMealPlanCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///CreateMealPlan");
            });
        }
    }
}
