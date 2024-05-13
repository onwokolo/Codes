var dll = new DoublyLinkedList(10);
dll.Append(15);
dll.Prepend(20);
dll.Insert(1, 100);
dll.PrintAsArray();
dll.Print();
// dll.Remove(1);
dll.Reverse();
dll.PrintAsArray();
dll.Print();
Console.WriteLine($"Head: {dll?.Head?.Data},\tTail: {dll?.Tail?.Data}\tLength: {dll.Length}");

// Console.WriteLine("Traversing Front Head: {0}", dll.TraverseToIndex(1)?.Data);
// Console.WriteLine("Traversing Front Tail: {0}", dll.TraverseToIndex(1, false)?.Data);

class Node
{
    public int Data { get; set; }
    public Node? Previous { get; set; }
    public Node? Next { get; set; }

    public Node(int value)
    {
        this.Data = value;
        this.Previous = null;
        this.Next = null;
    }
}

class DoublyLinkedList
{
    public Node? Head { get; set; }
    public Node? Tail { get; set; }
    public int Length { get; set; }
    public DoublyLinkedList(int value)
    {
        Node node = new Node(value);
        this.Head = node;
        this.Tail = node;
        this.Length = 1;
    }

    public void Append(int value)
    {
        var newNode = new Node(value);
        newNode.Previous = this.Tail;
        this.Tail.Next = newNode!;
        this.Tail = newNode!;
        this.Length++;
    }

    public void Prepend(int value)
    {
        var newNode = new Node(value);
        newNode.Next = this.Head;
        this.Head.Previous = newNode!;
        this.Head = newNode!;
        this.Length++;
    }

    public Node? TraverseToIndex(int index)
    {
        // Handle special cases
        if (index < 0 || index >= this.Length)
            return null;

        var current = this.Head;
        int counter = 0;
        while (current != null && counter < index)
        {
            counter++;
            current = current.Next;
        }
        return current;
    }

    public Node? TraverseToIndex(int index, bool fromHead)
    {
        if (fromHead)
            return this.TraverseToIndex(index);

        // Handle special cases
        if (index < 0 || index >= this.Length)
            return null;

        var current = this.Tail;
        var counter = 0;
        while (current != null && counter < index)
        {
            counter++;
            current = current.Previous;
        }
        return current;
    }

    public void Insert(int index, int value)
    {
        // Handle special cases
        if (index < 1)
        {
            this.Prepend(value);
            return;
        }

        if (index >= this.Length)
        {
            this.Append(value);
            return;
        }


        // Identify the nodes involves
        Node newNode = new Node(value);
        var previousNode = this.TraverseToIndex(index - 1)!;
        var nextNode = previousNode.Next;

        previousNode.Next = newNode!;
        newNode.Previous = previousNode;
        newNode.Next = nextNode;
        nextNode.Previous = newNode!;
        this.Length++;
    }

    public void Remove(int index)
    {
        // Handle special cases
        if (index < 0 || index >= this.Length || this.Length == 0)
        {
            return;
        }

        var previousNode = this.TraverseToIndex(index - 1)!;

        if (previousNode == null)
        {
            previousNode = this.Head;
            this.Head = previousNode.Next;
        }

        var unwantedNode = previousNode.Next;
        previousNode.Next = unwantedNode.Next;
        this.Length--;
        if (this.Length == index)
            this.Tail = previousNode;
        else
        {
            var nextNode = unwantedNode.Next;
            nextNode.Previous = previousNode;
        }
    }

    public void Reverse()
    {
        var current = this.Head;
        this.Head = this.Tail;
        this.Tail = current;
        Node? next = null;
        Node? previous = null;
        while (current != null)
        {
            next = current.Next;
            previous = current.Previous;
            current.Previous = next;
            current.Next = previous;
            current = next;
        }
    }

    public void PrintAsArray()
    {
        var current = this.Head;
        Console.Write("[");
        while (current != null)
        {
            Console.Write(current.Data);
            current = current.Next;
            if (current != null) Console.Write(", ");
        }
        Console.WriteLine("]");
    }

    public void Print()
    {
        var current = this.Head;
        Console.Write("From Head to Tail: ");
        while (current != null)
        {
            Console.Write($"{current.Data} -> ");
            current = current.Next;
        }
        Console.WriteLine("nil");

        current = this.Tail;
        Console.Write("From Tail to Head: ");
        while (current != null)
        {
            Console.Write($"{current.Data} <- ");
            current = current.Previous;
        }
        Console.WriteLine("nil");
    }
}