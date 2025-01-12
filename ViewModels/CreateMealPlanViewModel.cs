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
    public class CreateMealPlanViewModel : INotifyPropertyChanged
    {
        private string mealPlanName;
        private string description;

        public string MealPlanName
        {
            get => mealPlanName;
            set
            {
                if (mealPlanName != value)
                {
                    mealPlanName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveMealPlanCommand { get; }

        public CreateMealPlanViewModel()
        {
            SaveMealPlanCommand = new Command(async () =>
            {
                if (!string.IsNullOrWhiteSpace(MealPlanName))
                {
                    // TODO: Salvează Meal Plan-ul
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