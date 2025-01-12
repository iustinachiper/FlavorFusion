using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlavorFusion.ViewModels;

namespace FlavorFusion.ViewModels
{
    public class CreateViewModel
    {
        public ICommand BackToRecipesCommand { get; }

        public CreateViewModel()
        {
            BackToRecipesCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("..");
            });
        }
    }
}
