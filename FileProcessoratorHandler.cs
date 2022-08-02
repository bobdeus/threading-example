using System.Diagnostics;

namespace ThreadTesting;

public class FileProcessoratorHandler
{
    private const string TestFileLocation = "test/TestFiles";

    internal static void ProcessFile(string fileName)
    {
        var lines = File.ReadAllLines(fileName).ToList();
        var totalLinesCount = lines.Count * lines[0].Split(",").Length;
        var theData = new string[totalLinesCount];
        var dataIndex = 0;
        foreach (var item in lines)
        {
            var data = item.Split(",");
            foreach (var line in data) theData[dataIndex++] = line;
        }

        ComputeSomeData(theData, fileName);
    }

    private static void ComputeSomeData(string[] theData, string fileName)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        Console.WriteLine($"The file {fileName} has {theData.Length} items in it.");
        for (var i = 0; i < theData.Length; i++)
            //This shows writing file out put which is not a huge improvment since we are write I/O bound
            //File.AppendAllText($"D:/{fileName.Replace(TestFileLocation, "")}.txt", $"{theData[i]}\n");

            //This simulates pure processing
            DoSomeSillyMathStuffForSimulationPurposes();
        stopWatch.Stop();
        Console.WriteLine($"That file took this many {stopWatch.ElapsedMilliseconds}");
    }

    private static void DoSomeSillyMathStuffForSimulationPurposes()
    {
        var random = new Random(42);

        var eachs = 0.0;
        foreach (var each in Enumerable.Range(0, 2100)) eachs += Math.Cbrt(Math.Cos(Math.Pow(42, random.NextDouble())));
    }

    internal static List<string> GetAllFiles()
    {
        return Directory.GetFiles(TestFileLocation).ToList();
    }

    internal static void CreateTestFiles(int filesToCreate, int rowsPerFile)
    {
        if (!Directory.Exists(TestFileLocation)) Directory.CreateDirectory(TestFileLocation);
        foreach (var file in Enumerable.Range(1, filesToCreate))
        {
            var lines = Enumerable.Range(1, rowsPerFile)
                .Select(item => $"column1:{item},column2:{item},column3:{item}").ToList();
            File.WriteAllLines($"{TestFileLocation}/Test{file}.csv", lines);
        }
    }

    internal static void DeleteTestFiles()
    {
        foreach (var fileName in Directory.GetFiles(TestFileLocation)) File.Delete(fileName);

        if (Directory.Exists(TestFileLocation)) Directory.Delete(TestFileLocation);
    }
}