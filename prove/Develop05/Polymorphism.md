# Meaning

The ability of the class to adapt to many other forms, using methods with different types of variables or different behaviors.

# Benefits

The principal benefit is the reuse of code, also increasing the compatibility of a class with different types of variables.

# Application

An application example is if I'm developing a car game, where there is the class "car" with a method of "GoForward." If I have different classes of cars like FF traction or FW traction or 4x4 traction, the math for the vector of movement is going to be different. So when each class or type of car is coding the method "GoDown," it is going to be overridden and changed for the application of each type of car.

# Code

```csharp
 abstract class Car
    {
        private string _model;
        private string _color;

        public abstract void GoFoward();
    }

    class FFCar : Car
    {
        public override void GoFoward()
        {
            // Function of only the front tires have the power
        }
    }
    class FWCar : Car
    {
        public override void GoFoward()
        {
            // Function of only the back tires have the power
        }
    }
    class FourByFourCar : Car
    {
        public override void GoFoward()
        {
            // Function of all tires have the power
        }
    }

```
