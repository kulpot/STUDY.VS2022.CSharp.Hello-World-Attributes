using System;
using System.Reflection;

//ref link:https://www.youtube.com/watch?v=VJX1G15GTng&list=PLRwVmtr-pp05brRDYXh-OTAIi-9kYcw3r
//Attribute -- special class in .NET

class TestAttribute : Attribute { }

[TestAttribute]
class MyTestSuite
{

}

[TestAttribute]
class YourTestSuite { }

class MainClass
{
    static void Main()
    {
        var testSuites = 
            from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
            select t;

        foreach(Type t in testSuites)
            Console.WriteLine(t.Name);
        //foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            //Console.WriteLine(t.Name);
            //foreach(Attribute a in t.GetCustomAttributes(false))
            //    if(a is TestAttribute)
            //        Console.WriteLine(t.Name + " is a test suite!");
    }
}