// See https://aka.ms/new-console-template for more information

using ThreadTesting;

FileProcessoratorHandler.CreateTestFiles(10, 1000);
var nonThreadingExample = new NonThreadingExample();
nonThreadingExample.DoWork();
Console.WriteLine("===================================================");
Console.WriteLine("=================BEGIN THREADING===================");
Console.WriteLine("===================================================");
var threadingExample = new ThreadingExample();
threadingExample.DoWork();
FileProcessoratorHandler.DeleteTestFiles();