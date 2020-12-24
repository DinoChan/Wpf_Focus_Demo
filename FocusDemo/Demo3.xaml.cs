using Microsoft.Xaml.Behaviors;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FocusDemo
{
    /// <summary>
    /// Demo3.xaml 的交互逻辑
    /// </summary>
    public partial class Demo3 : UserControl
    {
        public Demo3()
        {
            InitializeComponent();
        }
    }

    public class Demo3ViewModel : ModelBase
    {
        public string Name { get; set; }

        public ICommand SubmitCommand { get; }


        public Demo3ViewModel()
        {
            SubmitCommand = new DelegateCommand<string>(Submit);
        }


        private string _focusElement;

        public string FocusElement
        {
            get => _focusElement;
            set => SetProperty(ref _focusElement, value);
        }

        protected virtual void Submit(string parameter)
        {
            FocusElement = null;
            FocusElement = parameter;
        }
    }
}
