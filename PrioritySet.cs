public class PrioritySet<T, K>
{
    public PriorityQueue<T, K> Queue { get; set; } = new PriorityQueue<T, K>();
    public HashSet<T> Set { get; set; } = new HashSet<T>();

    public int Count => Queue.Count;
    public T Dequeue() => Queue.Dequeue();
    public bool Enqueue(T item, K prio)
    {
        if (!Set.Contains(item))
        {
            Queue.Enqueue(item, prio);
            Set.Add(item);
            return true;
        }
        return false;
    }
}

public class PrioritySetHashed<T, K>(Func<T, string> hashSelector)
{
    public PriorityQueue<T, K> Queue { get; set; } = new PriorityQueue<T, K>();
    public HashSet<string> Set { get; set; } = new HashSet<string>();

    public int Count => Queue.Count;
    public T Dequeue() => Queue.Dequeue();
    public bool Enqueue(T item, K prio)
    {
        var hash = hashSelector(item);
        if (!Set.Contains(hash))
        {
            Queue.Enqueue(item, prio);
            Set.Add(hash);
            return true;
        }
        return false;
    }
}