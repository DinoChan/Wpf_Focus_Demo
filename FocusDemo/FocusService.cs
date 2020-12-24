using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FocusDemo
{
    public class FocusService
    {

        /// <summary>
        /// 从指定元素获取 FocusableElement 依赖项属性的值。
        /// </summary>
        /// <param name="obj">从中读取属性值的元素。</param>
        /// <returns>从属性存储获取的属性值。</returns>
        public static string GetFocusableElement(DependencyObject obj) => (string)obj.GetValue(FocusableElementProperty);

        /// <summary>
        /// 将 FocusableElement 依赖项属性的值设置为指定元素。
        /// </summary>
        /// <param name="obj">对其设置属性值的元素。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetFocusableElement(DependencyObject obj, string value) => obj.SetValue(FocusableElementProperty, value);

        /// <summary>
        /// 标识 FocusableElement 依赖项属性。
        /// </summary>
        public static readonly DependencyProperty FocusableElementProperty =
            DependencyProperty.RegisterAttached("FocusableElement", typeof(string), typeof(FocusService), new PropertyMetadata(default(string), OnFocusableElementChanged));


        private static void OnFocusableElementChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (string)args.OldValue;
            var newValue = (string)args.NewValue;
            if (oldValue == newValue)
                return;


            if (newValue == null)
                return;

           
            var target = obj as FrameworkElement;
            if (target.Name == newValue)
                target.Focus();
        }
    }
}
