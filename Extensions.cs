namespace ThreadTesting;

public static class Extensions
{
    public static string ToMyString(this List<int> theNums)
    {
        theNums.Sort();
        return theNums.Aggregate("", (s, theNumb) => $"{s}, {theNumb}");
    }
}