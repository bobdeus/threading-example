using System.Diagnostics;

namespace ThreadTesting;

public class ThreadingExample
{
    private readonly List<string> _files;

    public ThreadingExample()
    {
        _files = FileProcessoratorHandler.GetAllFiles();
    }

    public void DoWork()
    {
        var watch = Stopwatch.StartNew();
        var threads = new List<Thread>();
        var mainThread = Thread.CurrentThread;
        mainThread.Name = "mainThread";
        foreach (var fileName in _files)
        {
            ThreadStart threadStart = delegate { ProcessFile(fileName); };
            var thread = new Thread(threadStart)
            {
                IsBackground = true
            };
            threads.Add(thread);
        }

        foreach (var thread in threads) thread.Start();

        foreach (var thread in threads) thread.Join();

        watch.Stop();
        Console.WriteLine($"MULTI-THREADED: The whole enchilada just took: {watch.ElapsedMilliseconds} milliseconds");
    }

    //This method is called in a multi threaded way
    private void ProcessFile(string fileName)
    {
        FileProcessoratorHandler.ProcessFile(fileName);
    }
}