using ReactiveList.Models;
using ReactiveList.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;

namespace ReactiveList.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private readonly DataService _dataService;

        [Reactive] public ReactiveList<ToDoItem> ToDoItems { get; set; }
        [Reactive] public int Count { get; set; }

        public MainViewModel()
        {
            _dataService = new DataService();

            ToDoItems = new ReactiveList<ToDoItem>();

            ToDoItems.CountChanged.Subscribe(x => Count = x);

            _dataService.Listen()
                .Buffer(TimeSpan.FromSeconds(3), 500)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(items =>
                {
                    using (ToDoItems.SuppressChangeNotifications())
                    {
                        foreach (var item in items)
                        {
                            ToDoItems.Add(item);
                        }
                    }
                });

            _dataService.Load(10);
        }

        public void Load(int number)
        {
            _dataService.Load(number);
        }
    }
}