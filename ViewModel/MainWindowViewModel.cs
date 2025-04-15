using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFTODO.Model;

namespace WPFTODO.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _newTaskName;
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public string NewTaskName
        {
            get => _newTaskName;
            set
            {
                _newTaskName = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// 添加命令
        /// </summary>
        public RelayCommand AddTaskCommand { get; }

        /// <summary>
        /// 删除命令
        /// </summary>
        public RelayCommand<TaskItem> RemoveTaskCommand { get; }

        public MainWindowViewModel()
        {
            Tasks  = new ObservableCollection<TaskItem>();
            AddTaskCommand = new RelayCommand(AddTask);
            RemoveTaskCommand = new RelayCommand<TaskItem>(RemoveTask);
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskName))
            {
                Tasks.Add(new TaskItem { TaskName = NewTaskName });
                NewTaskName = "";
            }
        }

        private void RemoveTask(TaskItem task)
        {
           
            Tasks.Remove(task);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
