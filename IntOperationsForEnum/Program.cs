Console.WriteLine("Using common int operations on enums!");

var a = Foo.A;
Console.WriteLine($"This should be A: {a}");
a++;
Console.WriteLine($"This should be B: {a}");
a--;
Console.WriteLine($"This should be A (again): {a}");
a += 2;
Console.WriteLine($"This should be C: {a}");

var b = Bar.A;
Console.WriteLine($"This should be A: {b}");
b++;
Console.WriteLine($"This should be B: {b}");
b--;
Console.WriteLine($"This should be A (again): {b}");
b += 2;
Console.WriteLine($"This should be C: {b}");

var c = ThisWillNotWork.A;
Console.WriteLine($"This should be A: {c}");
c++;
Console.WriteLine($"This will be 11, not an enum: {c}");
c--;
Console.WriteLine($"Back to the Enum, should be A: {c}");

public enum Foo {
    A,
    B,
    C
}

public enum Bar {
    A = 1,
    B = 2,
    C = 3
}

public enum ThisWillNotWork
{
    A = 10,
    B = 20,
    C = 30
}

/*
Output example:
Using common int operations on enums!
This should be A: A
This should be B: B
This should be A (again): A
This should be C: C
This should be A: A
This should be B: B
This should be A (again): A
This should be C: C
This should be A: A
This will be 11, not an enum: 11
Back to the Enum, should be A: A

Process finished with exit code 0.
*/