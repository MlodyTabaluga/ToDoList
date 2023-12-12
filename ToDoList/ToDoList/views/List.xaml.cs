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
    public partial class List : ContentPage
    {
        List<ListTask> tasks = Main.tasks;
        public List()
        {
            InitializeComponent();
            DisplayList();
        }

        public List(List<ListTask> tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
        }

        public void DisplayList()
        {
            TasksContainerStack.Children.Clear();
            foreach (var task in tasks)
            {
                Grid grid = new Grid();
                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = new GridLength(4,GridUnitType.Star);
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(40);
                grid.ColumnDefinitions.Add(cd);
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.RowDefinitions.Add(rd);
                Label label = new Label
                {
                    Text = task.Name,
                    TextColor = Color.White,
                    VerticalTextAlignment = TextAlignment.Center,
                    FontSize = 20,
                    Margin = new Thickness(5,0,0,0)
                };
                Button btn = new Button
                {
                    BackgroundColor = Color.Transparent,
                    BindingContext = task.Id
                };
                btn.Clicked += FullTaskInfo;
                ImageButton btn1 = new ImageButton
                {
                    Source = "edit_icon.png",
                    BackgroundColor = Color.Transparent,
                    BindingContext = task.Id
                };
                ImageButton btn2 = new ImageButton
                {
                    Source = "delete_icon.png",
                    BackgroundColor = Color.Transparent,
                    BindingContext = task.Id
                };
                btn1.Clicked += Edit;
                btn2.Clicked += Delete;
                grid.Children.Add(label, 0, 0);
                grid.Children.Add(btn, 0, 0);
                grid.Children.Add(btn1, 1, 0);
                grid.Children.Add(btn2, 2, 0);
                TasksContainerStack.Children.Add(grid);
            }
        }

        private void Edit(object sender, EventArgs e)
        {
            int id = (int)((ImageButton)sender).BindingContext;
            Navigation.PushAsync(new AddTaskPage(id));
        }

        private void Delete (object sender, EventArgs e)
        {
            int id = (int)((ImageButton)sender).BindingContext;
            Main.tasks.RemoveAll(x => x.Id == id);
            DisplayList();
        }

        private void FullTaskInfo(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).BindingContext;
            Navigation.PushAsync(new TaskInfo(id));
        }

        private void Btn_Add_Task(object sender, EventArgs e)
        {
            AddTask();
        }

        private void AddTask()
        {
            Navigation.PushAsync(new AddTaskPage());
        }
        protected override void OnAppearing()
        {
            DisplayList();
            base.OnAppearing();
        }
    }
}