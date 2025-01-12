using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlavorFusion.ViewModels
{
    public class CategoriesViewModel
    {
        public ICommand NavigateToCreateCategoryCommand { get; }

        public CategoriesViewModel()
        {
            NavigateToCreateCategoryCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///CreateCategory");
            });
        }
    }
}