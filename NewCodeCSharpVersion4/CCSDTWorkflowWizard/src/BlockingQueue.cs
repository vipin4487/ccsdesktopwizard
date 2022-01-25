using System;
using System.Collections;
using System.Threading;

public class BlockingQueue
{
    private readonly object lockObject = new object();
    private Queue myQueue = new Queue();
    private bool stopped = false;

    public object Dequeue()
    {
        object lockObject = this.lockObject;
        lock (lockObject)
        {
            while (!this.stopped & (this.myQueue.Count == 0))
            {
                Monitor.Wait(this.lockObject);
            }
            if (this.stopped)
            {
                return null;
            }
            return this.myQueue.Dequeue();
        }
    }

    public int Enqueue(object o)
    {
        object lockObject = this.lockObject;
        lock (lockObject)
        {
            this.myQueue.Enqueue(o);
            Monitor.Pulse(this.lockObject);
            return this.myQueue.Count;
        }
    }

    public void Restart()
    {
        object lockObject = this.lockObject;
        lock (lockObject)
        {
            while (this.myQueue.Count > 0)
            {
                this.myQueue.Dequeue();
            }
            this.stopped = false;
        }
    }

    public void StopBlocking()
    {
        object lockObject = this.lockObject;
        lock (lockObject)
        {
            this.stopped = true;
            Monitor.PulseAll(this.lockObject);
        }
    }

    public int Count
    {
        get
        {
            return this.myQueue.Count;
        }
    }
}

