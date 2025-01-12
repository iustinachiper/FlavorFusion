using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlavorFusion.ViewModels
{
    public class RecipesViewModel
    {
        // Comandă pentru navigarea către pagina Create
        public ICommand NavigateToCreateCommand { get; }

        public RecipesViewModel()
        {
            // Inițializare comandă
            NavigateToCreateCommand = new Command(async () =>
            {
                // Navighează către pagina Create
                await Shell.Current.GoToAsync("///Create");
            });
        }
    }
}

