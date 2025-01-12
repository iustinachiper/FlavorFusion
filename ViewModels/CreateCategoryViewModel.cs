using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlavorFusion.ViewModels
{
    public class CreateCategoryViewModel : INotifyPropertyChanged
    {
        private string categoryName;

        public string CategoryName
        {
            get => categoryName;
            set
            {
                if (categoryName != value)
                {
                    categoryName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCategoryCommand { get; }

        public CreateCategoryViewModel()
        {
            SaveCategoryCommand = new Command(async () =>
            {
                if (!string.IsNullOrWhiteSpace(CategoryName))
                {
                    // TODO: Logica pentru salvarea categoriei
                    await Shell.Current.GoToAsync("..");
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
