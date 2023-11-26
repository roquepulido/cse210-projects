# Meaning

Inheritance is the way to share attributes and methods between classes.  The main class where we want to have the attributes and the methods known as "Parent" pass its methods and attribute to another class called "Child".

# Benefits

The principal benefit of inheritance is the reuse of code, avoiding the necessity of rewriting all the lines of code for a method or an attribute.

# Application

In the project of this week, the use of inheritance is to create a principal class that contains the principal functions of the other classes. in this way the new classes can inherit from the parent all the methods for his work.

# Code

```csharp

class Activity
{

    private string _name;

    private string _description;
    public void DisplayStartingMessage()
    {...}
    public void DisplayEndingMessage()
    {...}
    public void ShowSpinner(int seconds, int speed = 250)
    {...}
    public void ShowCountDown(int seconds)
    {...}
}

class BreathingActivity : Activity
{

}

```
