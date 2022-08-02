using System.Diagnostics;

namespace ThreadTesting;

public class NonThreadingExample
{
    private readonly List<string> _files;

    public NonThreadingExample()
    {
        _files = FileProcessoratorHandler.GetAllFiles();
    }

    public void DoWork()
    {
        var watch = Stopwatch.StartNew();
        foreach (var fileName in _files) ProcessFile(fileName);
        watch.Stop();
        Console.WriteLine($"SINGLE-THREADED: The whole enchilada just took: {watch.ElapsedMilliseconds} milliseconds");
    }

    //This method can be made multi threaded
    private void ProcessFile(string fileName)
    {
        FileProcessoratorHandler.ProcessFile(fileName);
    }
}