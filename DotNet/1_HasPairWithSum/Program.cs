Console.WriteLine(hasPairWithSum([6, 4, 3, 2, 1, 7], 9));
Console.WriteLine(hasPairWithSum2([0, 4, 3, 3, 1, 7], 9));

// Naive Solution
static bool hasPairWithSum(int[] arr, int sum)
{
    var len = arr.Length;
    for (int i = 0; i < len; i++)
    {
        for (int j = i + 1; j < len; j++)
        {
            if (arr[i] + arr[j] == sum)
            {
                return true;
            }
        }
    }

    return false;
}

// Better Solution
static bool hasPairWithSum2(int[] arr, int sum)
{
    var len = arr.Length;
    HashSet<int> mySet = new();

    for (int i = 0; i < len; i++)
    {
        if (mySet.Contains(arr[i]))
        {
            return true;
        }

        mySet.Add(sum - arr[i]);
    }

    return false;
}