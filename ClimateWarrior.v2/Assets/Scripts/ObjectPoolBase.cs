using System.Collections.Generic;

public abstract class ObjectPoolBase<T> where T : class
{
    private readonly Queue<T> _queue;
    
    public int Capacity { get; private set; }

    protected ObjectPoolBase(int capacity)
    {
        _queue = new Queue<T>(capacity);
        Capacity = capacity;
    }

    public virtual T Get()
    {
        return _queue.Count > 0 ? _queue.Dequeue() : Instantiate();
    }

    public void Collect(T item)
    {
        if (item == null)
            return;
        
        if (_queue.Count == Capacity)
            Destroy(item);
        else if (CanCollect(item))
        {
            _queue.Enqueue(item);
            OnCollect(item);
        }
    }
    
    
    
    protected abstract T Instantiate();

    protected abstract void Destroy(T item);

    protected virtual void OnCollect(T item){}

    protected virtual bool CanCollect(T item) => true;
}