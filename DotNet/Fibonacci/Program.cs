int num = 20;
Console.WriteLine($"The Fibonacci index value of {num} is {Fibonacci(num)}.");
Console.WriteLine($"The Fibonacci2 index value of {num} is {Fibonacci2(num)}.");

// Using recursion
int Fibonacci(int num)
{
    // if (num < 2) return num; // This handles the base case as well
    if (num < 0) return 0;
    if (num == 1) return 1;
    return Fibonacci(num - 2) + Fibonacci(num - 1);
}

// Using Iteration
int Fibonacci2(int num)
{
    // Handle special cases
    if (num <= 0) return 0;
    if (num == 1) return 1;

    int a = 0;
    int b = 1;
    int temp;

    for (int i = 2; i <= num; i++)
    {
        // Using temp to store the previous value
        temp = b;
        b = a + b;
        a = temp;
    }
    return b;
}