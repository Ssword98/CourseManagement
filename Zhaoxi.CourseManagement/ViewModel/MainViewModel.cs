﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zhaoxi.CourseManagement.Common;
using Zhaoxi.CourseManagement.Model;

namespace Zhaoxi.CourseManagement.ViewModel
{
    public class MainViewModel : NotifyBase
    {
        public UserModel UserInfo { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                this.DoNotify();
            }
        }

        private FrameworkElement _mainContent;

        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set
            {
                _mainContent = value;
                this.DoNotify();
            }
        }

        public CommandBase NavChangedCommand { get; set; }

        public MainViewModel()
        {
            this.UserInfo = new UserModel();
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExecute = new Action<object>(NavChanged);
            this.NavChangedCommand.DoCanExecute = new Func<object, bool>((o)=>true);

            NavChanged("FirstPageView");
        }

        private void NavChanged(object obj)
        {
            Type type = Type.GetType("Zhaoxi.CourseManagement.View."+obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = cti.Invoke(null) as FrameworkElement;
        }
    }
}
