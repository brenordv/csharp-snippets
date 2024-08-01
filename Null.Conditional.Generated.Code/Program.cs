using Null.Conditional.Generated.Code;

Console.WriteLine("Hello, World!");

var child1 = new ExampleClass { Name = "Child1" };
var child2 = new ExampleClass { Name = "Child2" };

var parent = new ExampleClass
{
    Name = "Parent",
    Children = new List<ExampleClass> { child1, child2 }
};

child1.Parent = parent;
child2.Parent = parent;

parent.DisplayInfo();