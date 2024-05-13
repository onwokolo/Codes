Console.WriteLine(FirstRecurringCharacter([2, 5, 1, 2, 3, 5, 1, 2, 4]));  // Should return 2
Console.WriteLine(FirstRecurringCharacter([2, 1, 1, 2, 3, 5, 1, 2, 4]));  // Should return 1
Console.WriteLine(FirstRecurringCharacter([2, 3, 4, 5]));  // Should return -1 (meaning not exist)

static int FirstRecurringCharacter(int[] arr)
{
    HashSet<int> chars = new();

    foreach (int num in arr)
    {
        if (chars.Contains(num))
        {
            return num;
        }
        chars.Add(num);
    }
    return -1;
}