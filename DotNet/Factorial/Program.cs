int num = 3;
Console.WriteLine($"The factorial of {num} is: {factorial(num)}.");
Console.WriteLine($"The factorial2 of {num} is: {factorial2(num)}.");

int factorial(int num)
{
    if (num <= 1) return 1;
    return num * factorial(num - 1);
}

int factorial2(int num)
{
    int result = 1;
    while (num >= 2)
    {
        result *= num;
        num--;
    }
    return result;
}