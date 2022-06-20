using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace CodeGeneration.DynamicClass
{
    public class Example
    {
        public void Start()
        {
            var fields = new List<Field>()
            {
                new Field("EmployeeID", typeof(int)),
                new Field("EmployeeName", typeof(string)),
                new Field("Designation", typeof(string))
            };

            dynamic obj = new DynamicClass(fields);

//set

            obj.EmployeeID = 123456;
            obj.EmployeeName = "John";
            obj.Designation = "Tech Lead";

            obj.Age = 25; //Exception: DynamicClass does not contain a definition for 'Age'
            obj.EmployeeName = 666; //Exception: Value 666 is not of type String

//get
            Console.WriteLine(obj.EmployeeID); //123456
            Console.WriteLine(obj.EmployeeName); //John
            Console.WriteLine(obj.Designation); //Tech Lead
        }
        
        public void Start2()
        {
            var fields2 = new List<Field>()
            {
                new Field("Print", typeof(Action<object>)),
                new Field("EmployeeName", typeof(string)),
                new Field("Designation", typeof(string))
            };

            dynamic obj2 = new DynamicClass(fields2);

            Action<object> action = o => Console.WriteLine(o); 
            obj2.Print = action;

            obj2.Print("Hello, world!");
        }
    }
}