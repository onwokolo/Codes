var stack = new Stack();
stack.Push(10);
stack.Push(20);
stack.Push(30);
var lastPopped = stack.Pop();
lastPopped = stack.Pop();
lastPopped = stack.Pop();
// lastPopped = stack.Pop();
Console.WriteLine($"Last Popped: {lastPopped?.Data}");
stack.PrintAsArray();
Console.WriteLine($"Top: {stack.Top?.Data}\tBottom: {stack.Bottom?.Data}\tLength: {stack.Length}");
var peekedValue = stack.Peek();
Console.WriteLine($"Peek value is: {peekedValue?.Data}");


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

public class Stack
{
    public Node? Top { get; set; }
    public Node? Bottom { get; set; }
    public int Length { get; set; }

    public Stack()
    {
        this.Top = null;
        this.Bottom = null;
        this.Length = 0;
    }

    public Stack(int value)
    {
        var newNode = new Node(value);
        this.Top = newNode;
        this.Bottom = newNode;
        this.Length = 1;
    }

    // Peek
    public Node? Peek()
    {
        return this.Top;
    }

    // Push
    public void Push(int value)
    {
        var newNode = new Node(value);
        this.Length++;

        // Check if this pushed value will be the first element in the stack
        if (this.Length == 1)
        {
            this.Top = newNode;
            this.Bottom = newNode;
            return;
        }

        newNode.Next = this.Top;
        this.Top = newNode;
    }

    // Pop
    public Node? Pop()
    {
        // Handle empty Stack
        if (this.Length == 0)
        {
            return null;
        }

        // Handle cases where there's only one item in the stack.
        if (this.Length == 1)
        {
            this.Bottom = null;
        }

        var top = this.Top!;
        this.Top = top?.Next;
        top.Next = null;
        this.Length--;
        return top;
    }

    // IsEmpty
    public bool IsEmpty()
    {
        return this.Length == 0;
    }

    public void PrintAsArray()
    {
        var current = this.Top;
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