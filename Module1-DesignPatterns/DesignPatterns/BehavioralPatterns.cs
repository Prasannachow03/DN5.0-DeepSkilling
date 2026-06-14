namespace DesignPatterns
{
    // Observer
    public interface IObserver { void Update(string event_); }
    public class EventManager
    {
        private List<IObserver> _observers = new();
        public void Subscribe(IObserver o) => _observers.Add(o);
        public void Notify(string event_) => _observers.ForEach(o => o.Update(event_));
    }
    public class EmailNotifier : IObserver
    {
        public void Update(string e) => Console.WriteLine($"Email alert: {e}");
    }

    // Strategy
    public interface ISortStrategy { void Sort(int[] data); }
    public class BubbleSort : ISortStrategy
    {
        public void Sort(int[] data)
        {
            Array.Sort(data);
            Console.WriteLine("Sorted: " + string.Join(", ", data));
        }
    }
    public class Sorter
    {
        private ISortStrategy _strategy;
        public Sorter(ISortStrategy s) => _strategy = s;
        public void Sort(int[] data) => _strategy.Sort(data);
    }
}