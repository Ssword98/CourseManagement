using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Zhaoxi.CourseManagement.Common
{
    public class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
                typeof(string),
                typeof(PasswordHelper),
                new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));

        public static string GetPassword(DependencyObject dp)
        {
            return dp.GetValue(PasswordProperty) as string;
        }
        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
                typeof(bool),
                typeof(PasswordHelper),
                new FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttached)));

        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }
        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        static bool _isUpdating = false;
        public static void OnPropertyChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = dp as PasswordBox;
            password.PasswordChanged -= Password_PasswordChanged;
            if (!_isUpdating)
            {
                password.Password = e.NewValue as string;
            }
            password.PasswordChanged += Password_PasswordChanged;
        }

        public static void OnAttached(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = dp as PasswordBox;
            password.PasswordChanged += Password_PasswordChanged;
        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            _isUpdating = true;
            SetPassword(passwordBox, passwordBox.Password);
            _isUpdating = false;
        }
    }
}
