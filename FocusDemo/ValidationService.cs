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
    public class ValidationService
    {
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
            DependencyProperty.RegisterAttached("AutoFocusWhenValidationError", typeof(bool), typeof(ValidationService), new PropertyMetadata(default(bool), OnAutoFocusWhenValidationErrorChanged));


        private static void OnAutoFocusWhenValidationErrorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (bool)args.OldValue;
            var newValue = (bool)args.NewValue;
            if (newValue == oldValue || newValue == false)
                return;

            var target = obj as UIElement;
            Validation.AddErrorHandler(target, (s, e) =>
            {
                var validationScope = target.GetVisualAncestors().OfType<UIElement>().FirstOrDefault(d => GetIsValidationScope(d));
                if (validationScope == null)
                    validationScope = Window.GetWindow(target).Content as UIElement;

                var errorElement = validationScope.GetVisualDescendants().OfType<UIElement>().FirstOrDefault(u => Validation.GetHasError(u));
                if (errorElement != null && errorElement.IsKeyboardFocused == false)
                    errorElement.Focus();
            });
        }



        /// <summary>
        /// 从指定元素获取 IsValidationScope 依赖项属性的值。
        /// </summary>
        /// <param name="obj">从中读取属性值的元素。</param>
        /// <returns>从属性存储获取的属性值。</returns>
        public static bool GetIsValidationScope(DependencyObject obj) => (bool)obj.GetValue(IsValidationScopeProperty);

        /// <summary>
        /// 将 IsValidationScope 依赖项属性的值设置为指定元素。
        /// </summary>
        /// <param name="obj">对其设置属性值的元素。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsValidationScope(DependencyObject obj, bool value) => obj.SetValue(IsValidationScopeProperty, value);

        /// <summary>
        /// 标识 IsValidationScope 依赖项属性。
        /// </summary>
        public static readonly DependencyProperty IsValidationScopeProperty =
            DependencyProperty.RegisterAttached("IsValidationScope", typeof(bool), typeof(ValidationService), new PropertyMetadata(default(bool)));

    }
}
