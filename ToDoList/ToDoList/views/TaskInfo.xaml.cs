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
    public partial class TaskInfo : ContentPage
    {
        public TaskInfo(int taskId)
        {
            InitializeComponent();
            ManageData(taskId);
        }

        private void ManageData(int taskId)
        {
            int index = Main.tasks.FindIndex(x => x.Id == taskId);
            ListTask task = Main.tasks[index];
            Name.Text = "Title: " + task.Name;
            Date.Text = "Date: " + task.CreateDate.ToString("dd/MM/yyyy");
            Description.Text = "Description:\n" + task.Description;
        }
    }
}