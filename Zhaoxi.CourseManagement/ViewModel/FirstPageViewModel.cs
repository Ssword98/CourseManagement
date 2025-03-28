﻿using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.Common;
using Zhaoxi.CourseManagement.DataAccess;
using Zhaoxi.CourseManagement.Model;

namespace Zhaoxi.CourseManagement.ViewModel
{
    public class FirstPageViewModel : NotifyBase
    {
        private int _instrumentValue;

        public int InstrumentValue
        {
            get { return _instrumentValue; }
            set { _instrumentValue = value; this.DoNotify(); }
        }

        private int _itemCount;

        public int ItemCount
        {
            get { return _itemCount; }
            set { _itemCount = value; this.DoNotify(); }
        }


        public ObservableCollection<CourseSeriesModel> CourseSeriesList { get; set; } = new ObservableCollection<CourseSeriesModel>();


        Random random = new Random();
        bool isRunning = true;
        List<Task> taskList = new List<Task>();

        public FirstPageViewModel()
        {
            this.RefreshInstrumentValue();

            this.InitCourseSeries();
        }
        private void InitCourseSeries()
        {
            var cList = LocalDataAccess.GetInstance().GetCoursePlanRecord();
            this.ItemCount = cList.Max(c => c.SeriesList.Count);
            foreach (var c in cList)
            {
                this.CourseSeriesList.Add(c);
            }
        }

        private void RefreshInstrumentValue()
        {
            var task = Task.Factory.StartNew(new Action(async () =>
            {
                while (true)
                {
                    this.InstrumentValue = random.Next(Math.Max(this.InstrumentValue - 5, -10), Math.Min(this.InstrumentValue + 5, 90));
                    await Task.Delay(1000);
                }
            }));
            taskList.Add(task);
        }

        public void Dispose()
        {
            try
            {
                isRunning = false;
                Task.WaitAll(taskList.ToArray());
            }
            catch
            {

            }
        }
    }
}
