using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        private int taskId;
        public AddTaskPage()
        {
            InitializeComponent();
            OperationButton.Clicked += AddNewTask;
            OperationButton.Text = "Add";
        }

        public AddTaskPage(int taskId)
        {
            InitializeComponent();
            int index = Main.tasks.FindIndex(x => x.Id == taskId);
            TaskName.Text = Main.tasks[index].Name;
            TaskDescription.Text = Main.tasks[index].Description;
            TaskDate.Date = Main.tasks[index].CreateDate;
            OperationButton.Clicked += EditTask;
            OperationButton.Text = "Edit";
            this.taskId = taskId;
        }

        private void AddNewTask(object sender, EventArgs e)
        {
            int ListCount = Main.tasks.Count + 1;
            Main.tasks.Add(new ListTask(ListCount++,TaskName.Text,TaskDate.Date,TaskDescription.Text));
            Navigation.PopAsync();
        }

        private void EditTask(object sender, EventArgs e)
        {
            int index = Main.tasks.FindIndex(x => x.Id == taskId);
            Main.tasks[index].Name = TaskName.Text;
            Main.tasks[index].Description = TaskDescription.Text;
            Main.tasks[index].CreateDate = TaskDate.Date;
            Navigation.PopAsync();
        }
    }
}