using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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


            if (string.IsNullOrWhiteSpace(newValue))
                return;


            var target = obj as FrameworkElement;
            if (target.Name == newValue)
                target.Focus();
        }




        /// <summary>
        /// 从指定元素获取 FocusElement 依赖项属性的值。
        /// </summary>
        /// <param name="obj">从中读取属性值的元素。</param>
        /// <returns>从属性存储获取的属性值。</returns>
        public static string GetFocusElement(DependencyObject obj) => (string)obj.GetValue(FocusElementProperty);

        /// <summary>
        /// 将 FocusElement 依赖项属性的值设置为指定元素。
        /// </summary>
        /// <param name="obj">对其设置属性值的元素。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetFocusElement(DependencyObject obj, string value) => obj.SetValue(FocusElementProperty, value);

        /// <summary>
        /// 标识 FocusElement 依赖项属性。
        /// </summary>
        public static readonly DependencyProperty FocusElementProperty =
            DependencyProperty.RegisterAttached("FocusElement", typeof(string), typeof(FocusService), new PropertyMetadata(default(string), OnFocusElementChanged));


        private static void OnFocusElementChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (string)args.OldValue;
            var newValue = (string)args.NewValue;
            if (oldValue == newValue)
                return;

            if (string.IsNullOrWhiteSpace(newValue))
                return;

            var target = obj as FrameworkElement;
            var focueElement = target.GetVisualDescendants().OfType<FrameworkElement>().FirstOrDefault(d => d.Name == newValue);
            if (focueElement != null)
                focueElement.Focus();
        }


        /// <summary>
        /// 从指定元素获取 IsFocused 依赖项属性的值。
        /// </summary>
        /// <param name="obj">从中读取属性值的元素。</param>
        /// <returns>从属性存储获取的属性值。</returns>
        public static bool GetIsFocused(DependencyObject obj) => (bool)obj.GetValue(IsFocusedProperty);

        /// <summary>
        /// 将 IsFocused 依赖项属性的值设置为指定元素。
        /// </summary>
        /// <param name="obj">对其设置属性值的元素。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsFocused(DependencyObject obj, bool value) => obj.SetValue(IsFocusedProperty, value);

        /// <summary>
        /// 标识 IsFocused 依赖项属性。
        /// </summary>
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached("IsFocused", typeof(bool), typeof(FocusService), new PropertyMetadata(default(bool), OnIsFocusedChanged));


        private static void OnIsFocusedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var newValue = (bool)args.NewValue;
            if (newValue == false)
                return;

            var target = obj as FrameworkElement;
            target.Focus();
        }


        /// <summary>
        /// 从指定元素获取 AutoFocusWhenValidationError 依赖项属性的值。
        /// </summary>
        /// <param name="obj">从中读取属性值的元素。</param>
        /// <returns>从属性存储获取的属性值。</returns>
        public static bool GetAutoFocusWhenValidationError(DependencyObject obj) => (bool)obj.GetValue(AutoFocusWhenValidationErrorProperty);

        /// <summary>
        /// 将 AutoFocusWhenValidationError 依赖项属性的值设置为指定元素。
        /// </summary>
        /// <param name="obj">对其设置属性值的元素。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetAutoFocusWhenValidationError(DependencyObject obj, bool value) => obj.SetValue(AutoFocusWhenValidationErrorProperty, value);

        /// <summary>
        /// 标识 AutoFocusWhenValidationError 依赖项属性。
        /// </summary>
        public static readonly DependencyProperty AutoFocusWhenValidationErrorProperty =
            DependencyProperty.RegisterAttached("AutoFocusWhenValidationError", typeof(bool), typeof(FocusService), new PropertyMetadata(default(bool), OnAutoFocusWhenValidationErrorChanged));


        private static void OnAutoFocusWhenValidationErrorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (bool)args.OldValue;
            var newValue = (bool)args.NewValue;
            if (newValue == oldValue || newValue == false)
                return;

            var target = obj as FrameworkElement;
            Validation.AddErrorHandler(target, (s, e) =>
             {
                 target.Focus();
             });
        }


    }
}
