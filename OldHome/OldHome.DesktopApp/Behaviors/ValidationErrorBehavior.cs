using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace OldHome.DesktopApp.Behaviors
{
    public class ValidationErrorBehavior : Behavior<FrameworkElement>
    {
        private static ControlTemplate _defaultErrorTemplate;
        private Grid? _parentGrid;
        private int _rowIndex;
        private GridLength? _originalHeight;

        static ValidationErrorBehavior()
        {
            _defaultErrorTemplate = CreateDefaultTemplate();
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            if (AssociatedObject is Control control)
            {
                control.SetValue(Validation.ErrorTemplateProperty, _defaultErrorTemplate);
            }

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }



        /// <summary>
        /// 生成默认错误模板（带红色文本）
        /// </summary>
        private static ControlTemplate CreateDefaultTemplate()
        {
            var panel = new FrameworkElementFactory(typeof(StackPanel));
            panel.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);

            var placeholder = new FrameworkElementFactory(typeof(AdornedElementPlaceholder));
            panel.AppendChild(placeholder);

            var errorPanel = new FrameworkElementFactory(typeof(StackPanel));
            errorPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            var icon = new FrameworkElementFactory(typeof(TextBlock));
            icon.SetValue(TextBlock.TextProperty, "❗");
            icon.SetValue(TextBlock.ForegroundProperty, Brushes.Red);
            icon.SetValue(TextBlock.MarginProperty, new Thickness(0, 2, 2, 0));
            errorPanel.AppendChild(icon);


            var errorTextBlock = new FrameworkElementFactory(typeof(TextBlock));
            errorTextBlock.SetValue(TextBlock.MarginProperty, new Thickness(0, 2, 0, 0));
            errorTextBlock.SetBinding(TextBlock.TextProperty, new Binding("[0].ErrorContent"));
            errorTextBlock.SetValue(TextBlock.ForegroundProperty, Brushes.Red);
            errorPanel.AppendChild(errorTextBlock);

            panel.AppendChild(errorPanel);

            return new ControlTemplate
            {
                VisualTree = panel
            };
        }
    }

}
