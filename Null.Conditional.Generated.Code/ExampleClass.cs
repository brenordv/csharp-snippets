namespace Null.Conditional.Generated.Code;

public class ExampleClass
{
    public string Name { get; set; }
    public ExampleClass Parent { get; set; }
    public List<ExampleClass> Children { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine(Name?.ToUpper() ?? "No Name");
        Console.WriteLine(Parent?.Name?.ToUpper() ?? "No Parent");

        Children?.ForEach(child =>
        {
            Console.WriteLine(child?.Name?.ToUpper() ?? "No Child Name");
            Console.WriteLine(child?.Parent?.Name?.ToUpper() ?? "No Grandparent Name");
        });
    }
}