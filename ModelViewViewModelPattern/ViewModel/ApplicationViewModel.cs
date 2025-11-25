using System.ComponentModel;
using System.Configuration;
using System.Windows.Input;
using ModelViewViewModelPattern.Models;

namespace ModelViewViewModelPattern.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private LinearFunction? function;
        private ICommand? AddCommand => new RelayCommand(execute: (Action<object>)Add);
        private double X_1;
        private double Y_1;
        private double X_2;
        private double Y_2;
        public double x_1 
        {
            get => X_1;
            set 
            {
                X_1 = value;
                OnPropertyChanged(nameof(X_1));
            }
        }
        public double y_1 
        {
            get => Y_1;
            set 
            {
                Y_1 = value;
                OnPropertyChanged(nameof(Y_1));
            }
        }
        public double x_2
        {
            get => X_2;
            set
            {
                X_2 = value;
                OnPropertyChanged(nameof(X_2));
            }
        }
        public double y_2
        {
            get => Y_2;
            set
            {
                Y_2 = value;
                OnPropertyChanged(nameof(Y_2));
            }
        }

        public ApplicationViewModel() 
        {
            function = new();
        }
        
        public void Add(object sender) 
        {
            
        }

    }
}
