﻿using Panuon.WPF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OldHome.DesktopApp.Views.Windows
{
    /// <summary>
    /// CustomDialogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustomDialogWindow : WindowX, IDialogWindow
    {
        public CustomDialogWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, CloseEvent));
        }

        public IDialogResult Result { get; set; }
        private void CloseEvent(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
