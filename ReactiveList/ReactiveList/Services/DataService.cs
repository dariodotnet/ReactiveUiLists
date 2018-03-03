using ReactiveList.Models;
using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace ReactiveList.Services
{
    public class DataService
    {
        private int _numberOfLoadedItems;

        private readonly Subject<ToDoItem> _itemObservable = new Subject<ToDoItem>();

        public IObservable<ToDoItem> Listen() => _itemObservable;

        public void Load(int numberOfItems)
        {
            Task.Run(() =>
            {
                var rand = new Random();
                var toLoad = _numberOfLoadedItems + numberOfItems;
                for (var i = _numberOfLoadedItems; i < toLoad; i++)
                {
                    _itemObservable.OnNext(new ToDoItem
                    {
                        Title = $"Item {i}",
                        Date = DateTime.Now.AddMinutes(rand.Next(0, 1000)),
                        Done = rand.Next(0, 100) % 3 == 0
                    });
                    _numberOfLoadedItems++;
                }
            });
        }
    }
}