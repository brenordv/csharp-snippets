# Null Conditional Generated Code
This is a simple example of the low-level code that is generated when we use the null conditional operator in C#.
Its use is pretty common and there's nothing wrong with it, but it's always good to know what's happening under 
the hood.

# How to see the low-level code
To see the low-level code, you can use the [SharpLab](https://sharplab.io/) website. Just copy the code from the
High-level code section and paste it into the website. Then, click on the "Compile" button.

Or, if you use the best C# IDE in the world, Jetbrains Rider, you can click the menu `Tools`, then `IL Viewer`, and 
from the dropdown, select `Low-Level C#`.

I don't know how to do it in Visual Studio, or VS Code, but I'm sure it's possible. :)

## High-level code
```csharp
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
```

## Low-level code
```csharp
public void DisplayInfo()
{
  string name1 = this.Name;
  string str1;
  if (name1 == null)
    str1 = (string) null;
  else
    str1 = name1.ToUpper();
  if (str1 == null)
    str1 = "No Name";
  Console.WriteLine(str1);
  ExampleClass parent = this.Parent;
  string str2;
  if (parent == null)
  {
    str2 = (string) null;
  }
  else
  {
    string name2 = parent.Name;
    if (name2 == null)
      str2 = (string) null;
    else
      str2 = name2.ToUpper();
  }
  if (str2 == null)
    str2 = "No Parent";
  Console.WriteLine(str2);
  List<ExampleClass> children = this.Children;
  if (children == null)
    return;
  children.ForEach(ExampleClass.<>c.<>9__12_0 ?? (ExampleClass.<>c.<>9__12_0 = new Action<ExampleClass>((object) ExampleClass.<>c.<>9, __methodptr(<DisplayInfo>b__12_0))));
}
```
