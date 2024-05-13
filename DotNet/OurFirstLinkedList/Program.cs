LinkedList myLinkedList = new LinkedList(10);
myLinkedList.Append(5);
myLinkedList.Append(16);
myLinkedList.Prepend(1);
myLinkedList.Insert(3, 75);
myLinkedList.PrintAsArray();
Console.WriteLine($"Length: {myLinkedList.length}");
myLinkedList.Remove(0);
myLinkedList.PrintAsArray();
Console.WriteLine($"Length: {myLinkedList.length}");
Console.WriteLine($"Head: {myLinkedList?.head?.data}");
Console.WriteLine($"Tail: {myLinkedList?.tail?.data}");
// Console.WriteLine($"Traverse To Index: {myLinkedList.TraverseToIndex(3)}");
// myLinkedList.Print();

class Node
{
    public int data { get; set; }
    public Node? next { get; set; }

    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}

class LinkedList
{
    public Node head { get; set; }
    public Node tail { get; set; }
    public int length { get; set; }
    public LinkedList(int value)
    {
        this.head = new Node(value);
        this.tail = this.head;
        this.length = 1;
    }

    public void Append(int value)
    {
        Node newNode = new Node(value);
        this.tail.next = newNode;
        this.tail = newNode;
        this.length++;
    }

    public void Prepend(int value)
    {
        Node newNode = new Node(value);
        newNode.next = this.head;
        this.head = newNode;
        this.length++;
    }

    public Node? TraverseToIndex(int index)
    {
        int count = 0;
        Node? current = this.head;
        while (current != null && count != index)
        {
            count++;
            current = current.next;
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
        if (index >= this.length)
        {
            this.Append(value);
            return;
        }

        Node? newNode = new Node(value);
        Node? previous = this.TraverseToIndex(index - 1)!;
        Node? next = previous.next!;
        previous.next = newNode;
        newNode.next = next;
        this.length++;
    }

    public void Remove(int index)
    {
        // Handle special cases
        if (this.length == 0 || index < 0 || index >= this.length)
        {
            return;
        }


        Node? previous = this.TraverseToIndex(index - 1)!;
        Node? unwanted = null;
        if (previous != null)
        {
            unwanted = previous.next;
            previous.next = unwanted.next!;
        }
        else
        {
            unwanted = this.head;
        }
        this.length--;

        // When deleting head
        if (index == 0)
        {
            this.head = unwanted.next;
        }
        if (this.length == index)
        { // When deleting tail
            this.tail = previous!;
        }
    }

    public void PrintAsArray()
    {
        var current = this.head;
        Console.Write("[");
        while (current != null)
        {
            Console.Write(current.data);
            current = current.next;
            if (current != null) Console.Write(", ");
        }
        Console.WriteLine("]");
    }

    public void Print()
    {
        var current = this.head;
        while (current != null)
        {
            Console.Write($"{current.data} -> ");
            current = current.next;
        }
        Console.WriteLine("nil");
    }
}

