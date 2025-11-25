using System.CodeDom;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;

namespace ModelViewViewModelPattern.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action<object>? execute;
        private Func<object, bool>? canExecute;

        public event EventHandler? CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object>? execute, Func<object, bool>? canExecute = null) 
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parametr) 
        {
            return this.canExecute == null || this.canExecute(parametr);
        }
        public void Execute(object? parametr) 
        {
            if (this.execute != null)
                this.execute(parametr);
        }
    }
}
