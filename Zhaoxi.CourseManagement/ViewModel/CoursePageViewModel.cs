using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zhaoxi.CourseManagement.Common;
using Zhaoxi.CourseManagement.DataAccess;
using Zhaoxi.CourseManagement.Model;

namespace Zhaoxi.CourseManagement.ViewModel
{
    public class CoursePageViewModel
    {
        public ObservableCollection<CategoryItemModel> CategoryCourses { get; set; }
        public ObservableCollection<CategoryItemModel> CategoryTechnology { get; set; }
        public ObservableCollection<CategoryItemModel> CategoryTeacher { get; set; }
        public ObservableCollection<CourseModel> CourseList { get; set; } = new ObservableCollection<CourseModel>();
        private List<CourseModel> courseAll;


        public CommandBase OpenCourseUrlCommand { get; set; }
        public CommandBase TeacherFilerCommand { get; set; }

        public CoursePageViewModel()
        {
            this.OpenCourseUrlCommand = new CommandBase();
            this.OpenCourseUrlCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
            this.OpenCourseUrlCommand.DoExecute = new Action<object>((o) =>
            {
                if (o is string url)
                {
                    System.Diagnostics.Process.Start(url);
                }
            });

            this.TeacherFilerCommand = new CommandBase();
            this.TeacherFilerCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
            this.TeacherFilerCommand.DoExecute = new Action<object>(DoFilter);

            this.InitCategory();

            this.InitCourseList();
        }

        private void DoFilter(object obj)
        {
            string teacher = obj.ToString();
            List<CourseModel> temp = courseAll;
            if(teacher != "全部")
            {
                temp = courseAll.Where(c => c.Teachers.Exists(e => e == teacher)).ToList();
            }
            CourseList.Clear();
            foreach (var item in temp)
            {
                CourseList.Add(item);
            }
        }

        private void InitCategory()
        {
            this.CategoryCourses = new ObservableCollection<CategoryItemModel>();
            this.CategoryCourses.Add(new CategoryItemModel("全部", true));
            this.CategoryCourses.Add(new CategoryItemModel("公开课"));
            this.CategoryCourses.Add(new CategoryItemModel("VIP课程"));

            this.CategoryTechnology = new ObservableCollection<CategoryItemModel>();
            this.CategoryTechnology.Add(new CategoryItemModel("全部", true));
            this.CategoryTechnology.Add(new CategoryItemModel("C#"));
            this.CategoryTechnology.Add(new CategoryItemModel("ASP.NET"));
            this.CategoryTechnology.Add(new CategoryItemModel("微服务"));
            this.CategoryTechnology.Add(new CategoryItemModel("Java"));
            this.CategoryTechnology.Add(new CategoryItemModel("Vue"));
            this.CategoryTechnology.Add(new CategoryItemModel("微信小程序"));
            this.CategoryTechnology.Add(new CategoryItemModel("Winform"));
            this.CategoryTechnology.Add(new CategoryItemModel("WPF"));
            this.CategoryTechnology.Add(new CategoryItemModel("上位机"));

            this.CategoryTeacher = new ObservableCollection<CategoryItemModel>();
            this.CategoryTeacher.Add(new CategoryItemModel("全部", true));
            foreach (var item in LocalDataAccess.GetInstance().GetTeachers())
            {
                this.CategoryTeacher.Add(new CategoryItemModel(item));
            }
        }
        private void InitCourseList()
        {
            for (int i = 0; i < 10; i++)
            {
                CourseList.Add(new CourseModel { IsShowSkeleton = true });
            }
            Task.Run(new Action(async () =>
            {
                courseAll = LocalDataAccess.GetInstance().GetCourses();
                await Task.Delay(3000);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    CourseList.Clear();
                    foreach (var item in courseAll)
                    {
                        this.CourseList.Add(item);
                    }
                }));
            }));
        }
    }
}
