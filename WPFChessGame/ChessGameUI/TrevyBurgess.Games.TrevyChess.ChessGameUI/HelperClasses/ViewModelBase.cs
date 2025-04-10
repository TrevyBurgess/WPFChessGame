﻿//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI
{
    using System.ComponentModel;

    /// <summary>
    /// Provides common functionality for ViewModel classes
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

namespace WpfDataBindingToICommand
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// This RelayCommand object is used to encapsulate function logic into an oject that inherits ICommand.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Member Variables
        readonly Action<object> _ActionToExecute;
        readonly Predicate<object> _ActionCanExecute;
        #endregion

        #region Constructors
        /// <summary>
        /// This creates a new RelayCommand.
        /// </summary>
        /// <param name="inActionToExecute">
        /// This is the logic of the actin to execute.
        /// This objects is usually a method that returns void.
        /// </param>
        public RelayCommand(Action<object> inActionToExecute) : this(inActionToExecute, null) { }

        /// <summary>
        /// This creates a new RelayCommand.
        /// </summary>
        /// <param name="inActionToExecute">
        /// This is the logic of the actin to execute.
        /// This objects is usually a method that returns void.
        /// </param>

        /// <param name="inActionCanExecute">This is the logic for whether the action can execute.</param>
        public RelayCommand(Action<object> inActionToExecute, Predicate<object> inActionCanExecute)
        {
            if (inActionToExecute == null)
                throw new ArgumentNullException("execute");

            _ActionToExecute = inActionToExecute;
            _ActionCanExecute = inActionCanExecute;
        }
        #endregion

        #region ICommand Members
        public bool CanExecute(object parameter)
        {
            return _ActionCanExecute == null ? true : _ActionCanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _ActionToExecute(parameter);
        }
        #endregion
    }
}


















