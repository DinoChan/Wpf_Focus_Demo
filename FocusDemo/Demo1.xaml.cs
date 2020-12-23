using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FocusDemo
{
    /// <summary>
    /// Demo1.xaml 的交互逻辑
    /// </summary>
    public partial class Demo1 : UserControl
    {
        public Demo1()
        {
            InitializeComponent();
        }
    }


    public class Demo1ViewModel : ModelBase
    {
        public string Name { get; set; }

        public ICommand SubmitCommand { get; }


        public Demo1ViewModel()
        {
            SubmitCommand = new DelegateCommand(Submit);
        }


        private bool _isNameHasFocus;

        public bool IsNameHasFocus
        {
            get => _isNameHasFocus;
            set => SetProperty(ref _isNameHasFocus, value);
        }

        protected virtual void Submit()
        {
            ErrorsContainer.ClearErrors();
            if (string.IsNullOrEmpty(Name))
                ErrorsContainer.SetErrors(nameof(Name), new List<string> { "Please Input Username" });
        }
    }

}
