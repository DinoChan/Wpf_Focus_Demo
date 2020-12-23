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
    /// Demo2.xaml 的交互逻辑
    /// </summary>
    public partial class Demo2 : UserControl
    {
        public Demo2()
        {
            InitializeComponent();
        }
    }

    public class Demo2ViewModel : Demo1ViewModel
    {
        private bool _isNameHasFocus;

        public bool IsNameHasFocus
        {
            get => _isNameHasFocus;
            set => SetProperty(ref _isNameHasFocus, value);
        }

        protected override void Submit()
        {
            IsNameHasFocus = false;
            ErrorsContainer.ClearErrors();
            if (string.IsNullOrEmpty(Name))
            {
                ErrorsContainer.SetErrors(nameof(Name), new List<string> { "Please Input Username" });
                IsNameHasFocus = true;
            }
        }
    }
}
