var queue = new Queue();
queue.Enqueue(10);
queue.Enqueue(20);
queue.Enqueue(30);
var dequeued = queue.Dequeue();
dequeued = queue.Dequeue();
dequeued = queue.Dequeue();
dequeued = queue.Dequeue();
Console.WriteLine($"Last dequeued value: {dequeued?.Data}");
Console.WriteLine($"Is Queue Empty? {queue.IsEmpty()}");
Console.WriteLine($"The first item in the queue is: {queue.Peek()?.Data}");
Console.WriteLine($"First: {queue.First?.Data}\Last: {queue.Last?.Data}\tLength: {queue.Length}");
queue.PrintAsArray();

public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }

    public Node(int value)
    {
        this.Data = value;
        this.Next = null;
    }
}

class Queue
{
    public Node? First { get; set; }
    public Node? Last { get; set; }
    public int Length { get; set; }

    public Queue()
    {
        this.First = null;
        this.Last = null;
        this.Length = 0;
    }

    public Queue(int value)
    {
        var newNode = new Node(value);
        this.First = newNode;
        this.Last = newNode;
        this.Length = 1;
    }

    // Peek
    public Node? Peek()
    {
        return this.First;
    }

    public void Enqueue(int value)
    {
        var newNode = new Node(value)!;
        this.Length++;

        // If this is the first node, set it has the top
        if (this.Length == 1 || this.Last == null || this.First == null)
        {
            this.First = newNode;
            this.Last = newNode;
            return;
        }

        this.Last.Next = newNode;
        this.Last = newNode;
    }

    // Dequeue
    public Node? Dequeue()
    {
        // check if queue is empty
        if (this.Length == 0)
        {
            return null;
        }

        // Handle case where queue has just one element
        if (this.Length == 1)
        {
            this.Last = null;
        }

        var top = this.First!;
        this.First = top.Next;
        top.Next = null;
        this.Length--;
        return top;
    }

    public bool IsEmpty()
    {
        return this.Length == 0;
    }

    public void PrintAsArray()
    {
        var current = this.First;
        Console.Write("[");
        while (current != null)
        {
            Console.Write(current.Data);
            current = current.Next;
            if (current != null) Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}