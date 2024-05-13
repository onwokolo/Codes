using System.Collections;

var stack = new Stack();
stack.Push(10);
stack.Push(20);
stack.Push(30);
var lastPopped = stack.Pop();
lastPopped = stack.Pop();
lastPopped = stack.Pop();
// lastPopped = stack.Pop();
Console.WriteLine($"Last Popped: {lastPopped}");
Console.WriteLine($"Top: {stack.Top}\tBottom: {stack.Bottom}\tLength: {stack.Items.Count}");
var peekedValue = stack.Peek();
Console.WriteLine($"Peek value is: {peekedValue}");
stack.Print();

public class Stack
{
    public ArrayList Items { get; set; }
    public int? Top { get; set; }
    public int? Bottom { get; set; }

    public Stack()
    {
        this.Items = new ArrayList();
        this.Top = null;
        this.Bottom = null;
    }

    public Stack(int value)
    {
        this.Items = new ArrayList() { value };
        this.Top = value;
        this.Bottom = value;
    }

    // Peek
    public int? Peek()
    {
        return this.Top;
    }

    // Push
    public void Push(int value)
    {
        this.Items.Add(value);

        // Check if this pushed value will be the first element in the stack
        if (this.Items.Count == 1)
        {
            this.Top = value;
            this.Bottom = value;
        }
        else
        {
            this.Top = value;
        }
    }

    // Pop
    public int? Pop()
    {
        // Handle empty Stack
        if (this.Items.Count == 0)
        {
            return null;
        }

        var top = (int?)this.Items[this.Items.Count - 1];
        this.Items.RemoveAt(this.Items.Count - 1);

        // Handle cases where there was only one item in the stack.
        if (this.Items.Count == 0)
        {
            this.Bottom = null;
            this.Top = null;
        }
        else
        {
            this.Top = (int?)this.Items[this.Items.Count - 1];
        }
        return top;
    }

    // IsEmpty
    public bool IsEmpty()
    {
        return this.Items.Count == 0;
    }

    public void Print()
    {
        Console.Write("[");
        for (int i = 0; i < this.Items.Count; i++)
        {
            Console.Write("{0}{1}", this.Items[i], i == this.Items.Count - 1 ? "" : ", ");
        }
        Console.WriteLine("]");
    }
}