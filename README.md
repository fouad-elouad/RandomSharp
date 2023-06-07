# RandomSharp

RandomSharp is a lightweight random data generator for .NET.
It is designed to be easy to use, flexible and support different algorithms, allowing you to generate random data for testing, simulations, 
or any other scenario where you need randomized values. It provides a range of methods to generate different types of random data,
making it suitable for a wide range of use cases.

## Description

RandomSharp is a .NET class library that provides a `Randomizer` class, which is responsible for generating random data. 
The `Randomizer` class offers methods for generating random values of different types, such as booleans, integers, dates, and strings.
It also allows developers to implement their own generation algorithms if needed, includes options for generating nullable values,
generating random values from an enum, and generating random values within specific ranges.

## Features
- [x] Target .NET Standard 2.0
- [x] Generate random values for any .NET type.
- [x] Support weighted distribution.
- [x] Support for nullable values.
- [x] Extensibility (Implement your own generation algorithm)
- [x] Unit Test Project

## Overview

### Easy-to-use Interface
RandomSharp offers a straightforward and intuitive interface, making it easy for developers to generate random data without extensive configuration or complex setup.

### Extensibility
RandomSharp is designed to be extensible, allowing developers to implement their own generation algorithms if needed.
This feature enables customization and adaptation to specific requirements by implementing a custom randomization algorithm.

### DefaultRandomizer
RandomSharp implements a `DefaultRandomizer` class that uses the System.Random class as the underlying generation algorithm.
The System.Random class generates pseudorandom numbers based on a seed value, making it suitable for scenarios where statistical randomness is sufficient.

### RNGRandomizer
The library also includes an `RNGRandomizer` class that uses the System.Security.Cryptography.RNGCryptoServiceProvider class as the generation algorithm.
The RNGCryptoServiceProvider class utilizes a cryptographic random number generator that provides a higher level of randomness suitable for applications with stricter security requirements.

### XorShiftRandomizer
The library also includes an `XorShiftRandomizer` class.
The XorShift algorithm is a pseudorandom number generator that uses bitwise exclusive OR (XOR) and shift operations to generate random numbers. It is known for its fast execution.

### Weighted distribution
It allows you to generate random values based on a specific distribution with varying probabilities.
It enables you to assign different weights or probabilities to each possible outcome, influencing the likelihood of generating certain values.
This is useful in scenarios where you want to simulate real-world scenarios or emulate specific probability distributions.

### Support for Nullable Values
The library includes support for generating nullable values.
This is particularly useful when dealing with data types that can have null values, 
allowing developers to simulate various scenarios and test the behavior of their applications accordingly.

## Usage

 1- Clone or download the repository: To get started, clone or download the repository to your local machine.
 
 2- Open the solution file in Visual Studio 2022: The solution file is located in the root directory of the project. Open this file in Visual Studio to start working with the project.
 
 3- Build the project in release mode
 
 4- Reference the class library dll in your application.

### Random booleans

```csharp
	IRandomizer randomizer = new DefaultRandomizer();
	bool randomBoolean = randomizer.Boolean();
	bool? nullableRandomBoolean = randomizer.NullableBoolean();
```

### Random numbers

```csharp
	IRandomizer randomizer = new XorShiftRandomizer();
	int randomInt = randomizer.Int(10, 100);
	int? nullableRandomInt = randomizer.NullableInt(10, 100);

	double randomDouble = randomizer.Double(10.0, 100.0);
	double? nullableRandomDouble = randomizer.NullableDouble(10, 100);

	decimal randomDecimal = randomizer.Decimal(10.0M, 100.0M);
	decimal? nullableRandomDecimal = randomizer.NullableDecimal(10.0M, 100.0M);
```

### Random dates

```csharp
	IRandomizer randomizer = new RNGRandomizer();
	DateTime startDate = new DateTime(2010, 1, 1);
	DateTime endDate = new DateTime(2022, 12, 31);
	DateTime randomDate = randomizer.Date(startDate, endDate);
	DateTime? nullableRandomDate = randomizer.NullableDate(startDate, endDate);
```

### Random datetimes

```csharp
	IRandomizer randomizer = new XorShiftRandomizer();
	DateTime startDatetime = new DateTime(2010, 1, 1,0,0,0);
	DateTime endDatetime = new DateTime(2022, 12, 31,12,30,40);
	DateTime randomDatetime = randomizer.DateTime(startDatetime, endDatetime);
	DateTime? nullableRandomDatetime = randomizer.NullableDateTime(startDatetime, endDatetime);
```

### Random enums

```csharp
	enum DaysOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

	IRandomizer randomizer = new RNGRandomizer();
	DaysOfWeek randomEnumValue = randomizer.Enumeration<DaysOfWeek>();
	DaysOfWeek? nullableRandomEnumValue = randomizer.NullableEnumeration<DaysOfWeek>();
```

### Random strings

```csharp
	IRandomizer randomizer = new DefaultRandomizer();
	string randomString = randomizer.String(10);
	string randomStringWithCustomChars = randomizer.String(10, "ABC123");
	string? nullableRandomString = randomizer.NullableString(5, 10);
```

### Random strings using StringCharacterType

```csharp
	IRandomizer randomizer = new XorShiftRandomizer();
	int lenght = 30;
	string numeric = randomizer.String(lenght, StringCharacterType.Numeric);
	string uppercaseAlpha = randomizer.String(lenght, StringCharacterType.UppercaseAlpha);
```

### Random nullable values

```csharp
	public int CalculateSquare(int number)
	{
		return number * number;
	}

	IRandomizer randomizer = new RNGRandomizer();

	int inputNumber = randomizer.Int(1, 10);

	int? nullableSquare = randomizer.Nullable(inputNumber, CalculateSquare);
```

### Weighted distribution

```csharp
	public class Employee
    {
        public int yearsOfExperience { get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

    }

    public enum ExperienceLevel { Junior, Senior, Executive }
```

```csharp

    IRandomizer randomizer = new RNGRandomizer();
    var experienceLevels = Enum.GetValues<ExperienceLevel>();

    // 55% Junior, 35% Senior, 10% Executive
    double[] weights = new List<double>() { 0.55, 0.35, 0.1 }.ToArray(); 

    var oneEmployee = new Employee
    {
        yearsOfExperience = randomizer.Int(0, 25),
        ExperienceLevel = randomizer.Random(experienceLevels, weights)
    };

    IList<Employee> employees = new List<Employee>();
    for (int i = 0; i < 100; i++)
    {
            var employee = new Employee
        {
            yearsOfExperience = randomizer.Int(0, 25),
            ExperienceLevel = randomizer.Random(experienceLevels, weights)
        };
        employees.Add(employee);
    }

    // Count distribution
    var group = employees.GroupBy(e => e.ExperienceLevel).ToDictionary(e => e.Key, e => e.Select(a => a.yearsOfExperience).ToList());
```

Here's an example to illustrate a complex scenario of random weighted distribution.

In this example, we have the ExperienceLevel enumeration representing different levels of experience. We calculate the weights of each experience level based on the given `yearsOfExperience`.

```csharp

    IRandomizer randomizer = new RNGRandomizer();
    var experienceLevels = Enum.GetValues<ExperienceLevel>();
    var yearsOfExperience = randomizer.Int(0, 25);
    double[] weights = CalulateWeights(yearsOfExperience); // calculates ExperienceLevel weights based on yearsOfExperience
    var employee = new Employee
    {
        yearsOfExperience = yearsOfExperience,
        ExperienceLevel = randomizer.Random(experienceLevels, weights)
    };

    public static double[] CalulateWeights(int yearsOfExperience)
        {
            if (yearsOfExperience <= 2) //  years <= 2 : 100% Junior
            {
                return new List<double>() { 1, 0, 0 }.ToArray();
            }

            if (yearsOfExperience <= 5) // 2 < years <= 5  : 95% Junior, 5% Senior
            {
                return new List<double>() { 0.95, 0.05, 0 }.ToArray();
            }
            else if (yearsOfExperience <= 10) // 5 < years <= 10  : 10% Junior, 90% Senior
            {
                return new List<double>() { 0.1, 0.9, 0 }.ToArray();
            }
            else if (yearsOfExperience <= 15) // 10 < years <= 15  : 95% Senior, 5% Executive
            {
                return new List<double>() { 0, 0.95, 0.05 }.ToArray();
            }
            else if (yearsOfExperience <= 20) // 15 < years <= 20  : 10% Senior, 90% Executive
            {
                return new List<double>() { 0, 0.1, 0.9 }.ToArray();
            }
            else
            {
                // 20 < years : 100% Executive
                return new List<double>() { 0, 0, 1 }.ToArray();
            }
        }
```

## Implement your own generation algorithm

You can Implement your own custom generation algorithm within the library.
It provides flexibility and control over how the random values are generated for different types.
Instead of relying on the default algorithms provided by the library, you have the option to define and use your own logic for generating random values.
You can design an algorithm that aligns with your specific application or scenario, taking into account factors such as data distribution, range constraints, or any other specific requirements.
To implement your own generation algorithm, you can create a new class that implements the Randomizer class with your desired algorithm, 
and then use an instance of that class instead of other Randomizer implementations.

These abstract methods must be implemented 

```csharp

    protected abstract bool InternalBoolean();
```

```csharp

    protected abstract int InternalInt(int maxExclusive);
```

```csharp

    protected abstract int InternalInt(int minInclusive, int maxExclusive);
```

```csharp

    protected abstract double InternalDouble(double min, double max);
```

```csharp

    protected abstract double InternalDouble();
```

Here is an example of a custom implementation based on Lagged Fibonacci Generator

```csharp
	public class LFGRandomizer : Randomizer, IRandomizer
    {

        protected const int Lag1 = 23;
        protected const int Lag2 = 48;

        protected ulong[] state;
        protected int index;

        public LFGRandomizer()
        {
            // Initialize the state and index
            state = new ulong[Lag2];
            index = 0;

            // Seed the initial values
            InitSeed();
        }

        protected void InitSeed()
        {
            // You can modify this to use a different seed generation mechanism
            for (int i = 0; i < Lag2; i++)
            {
                state[i] = (ulong)System.DateTime.Now.Ticks;
            }
        }

        protected ulong LFGUInt64()
        {
            ulong next = state[index] + state[(index - Lag1 + Lag2) % Lag2];
            state[index] = next;
            index = (index + 1) % Lag2;
            return next;
        }

        protected override bool InternalBoolean()
        {
            return LFGUInt64() % 2 == 0;
        }

        protected override int InternalInt(int maxExclusive)
        {
            return InternalInt(0, maxExclusive);
        }

        protected override int InternalInt(int minInclusive, int maxExclusive)
        {
            checked
            {
                double scaleFactor = ScaleFactor();
                return (int)(minInclusive + (maxExclusive - minInclusive) * scaleFactor);
            }
        }

        protected override double InternalDouble(double min, double max)
        {
            return InternalDouble() * (max - min) + min;
        }

        protected override double InternalDouble()
        {
            return ScaleFactor();
        }

        protected double ScaleFactor()
        {
            const double scale = 1.0 / uint.MaxValue;
            return LFGUInt64() * scale;
        }
    }
```

## Support
If you are having problems, please let us know by [raising a new issue](https://github.com/fouad-elouad/RandomSharp/issues/new/choose).

## License
This project is licensed with the [MIT license](LICENSE).