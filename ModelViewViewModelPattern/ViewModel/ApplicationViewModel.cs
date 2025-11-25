using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
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
        public ICommand? CalculateCommand { get; }
        
        private double X_1;
        private double Y_1;
        private double X_2;
        private double Y_2;
        private string Result;
        private LinearFunction CurrentFunction;
        public double x_1 
        {
            get => X_1;
            set 
            {
                X_1 = value;
                OnPropertyChanged(nameof(X_1));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public double y_1 
        {
            get => Y_1;
            set 
            {
                Y_1 = value;
                OnPropertyChanged(nameof(Y_1));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public double x_2
        {
            get => X_2;
            set
            {
                X_2 = value;
                OnPropertyChanged(nameof(X_2));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public double y_2
        {
            get => Y_2;
            set
            {
                Y_2 = value;
                OnPropertyChanged(nameof(Y_2));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public string result 
        {
            get => Result;
            set 
            {
                Result = value;
                OnPropertyChanged(nameof(Result));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public LinearFunction currentFunction 
        {
            get => CurrentFunction;
            set 
            {
                CurrentFunction = value;
                OnPropertyChanged(nameof(CurrentFunction));
                OnPropertyChanged(nameof(FormulaText));
            }
        }
        public string FormulaText => CurrentFunction?.FormualText ?? "y = ?";
        public ApplicationViewModel() 
        {
            System.Diagnostics.Debug.WriteLine("ApplicationViewModel создан");
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
            System.Diagnostics.Debug.WriteLine($"CalculateCommand создан: {CalculateCommand != null}");
        }

        public void Calculate(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Calculate ВЫЗВАН!");

            CurrentFunction = new(X_1, Y_1, X_2, Y_2);

            OnPropertyChanged(nameof(currentFunction));
            OnPropertyChanged(nameof(FormulaText));
        }

        private bool CanCalculate(object parameter) 
        {
            return true;
        }
    }
}
