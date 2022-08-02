// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Threading.Channels;
using ThreadTesting;

FileProcessoratorHandler.CreateTestFiles(10, 1000);
var nonThreadingExample = new NonThreadingExample();
nonThreadingExample.DoWork();
Console.WriteLine();
Console.WriteLine("===================================================");
Console.WriteLine("=================BEGIN THREADING===================");
Console.WriteLine("===================================================");
Console.WriteLine();
var threadingExample = new ThreadingExample();
threadingExample.DoWork();
FileProcessoratorHandler.DeleteTestFiles();


var simpleThreadExample = new SimpleThreadExample();
simpleThreadExample.RunTest();


// var watch1 = new Stopwatch();
// watch1.Start();
// watch1.Stop();
//
// var watch2 = new Stopwatch();
// watch2.Start();
// var i = 1;
// var myList = Enumerable.Range(1, 1_000_011).ToList();
// myList.ForEach(i1 => i++);
// watch2.Stop();
// Console.WriteLine($"The total time was : {watch1.ElapsedMilliseconds}");
// Console.WriteLine($"The total time was : {watch2.ElapsedMilliseconds}");
