namespace ThreadTesting;

public class SimpleThreadExample
{
    private static int _myInt = 1;
    private static readonly object ObjectLock = new();
    private static readonly List<int> NoThreadSafe = new ();

    public void RunTest()
    {
        Thread.CurrentThread.Name = "Main Thread";
        Console.WriteLine($"{Thread.CurrentThread.Name} Running and MyInt is: {_myInt} =======================");
        var threads = MakeAndStartThreads(10).ToList();
        threads.ForEach(thread => thread.Start());

        DoWork();
        

        threads.ForEach(thread => thread.Join());

        Console.WriteLine(NoThreadSafe.ToMyString());
        Console.WriteLine($"{Thread.CurrentThread.Name} Running and MyInt is: {_myInt} =======================");
    }

    private IEnumerable<Thread> MakeAndStartThreads(int numberOfThreads)
    {
        var threads = new List<Thread>();
        Enumerable.Range(1, numberOfThreads).ToList().ForEach(threadNum =>
        {
            var thread = new Thread(DoWork)
            {
                Name = $"Thread-{threadNum}"
            };
            threads.Add(thread);
        });
        return threads;
    }

    private void DoWork()
    {
        Enumerable.Range(0, 10).ToList().ForEach(operation =>
        {
            lock (ObjectLock)
            {
                _myInt++;
                NoThreadSafe.Add(_myInt);

                Console.WriteLine($"{Thread.CurrentThread.Name} just increased MyInt: {_myInt}.");
            }
        });
    }
}