# RandomSharp

RandomSharp is a lightweight random data generator for .NET.
It is designed to be easy to use and flexible, allowing you to generate random data for testing, simulations, 
or any other scenario where you need randomized values. It provides a range of methods to generate different types of random data,
making it suitable for a wide range of use cases.

## Description

RandomSharp is a .NET class library that provides a `Randomizer` class, which is responsible for generating random data. 
The `Randomizer` class offers methods for generating random values of different types, such as booleans, integers, dates, and strings.
It also includes options for generating nullable values, generating random values from an enum, and generating random values within specific ranges.

## Features
- [x] Target .NET Standard 2.0
- [x] Generate random values for any .NET type.
- [x] Support for nullable values.
- [x] Unit Test Project

## Usage

 1- Clone or download the repository: To get started, clone or download the repository to your local machine.
 
 2- Open the solution file in Visual Studio 2022: The solution file is located in the root directory of the project. Open this file in Visual Studio to start working with the project.
 
 3- Build the project in release mode
 
 4- Reference the class library dll in your application.

### Random booleans

```csharp
	IRandomizer randomizer = new Randomizer();
	bool randomBoolean = randomizer.Boolean();
	bool? nullableRandomBoolean = randomizer.NullableBoolean();
```

### Random numbers

```csharp
	IRandomizer randomizer = new Randomizer();
	int randomInt = randomizer.Int(10, 100);
	int? nullableRandomInt = randomizer.NullableInt(10, 100);

	double randomDouble = randomizer.Double(10.0, 100.0);
	double? nullableRandomDouble = randomizer.NullableDouble(10, 100);

	decimal randomDecimal = randomizer.Decimal(10.0M, 100.0M);
	decimal? nullableRandomDecimal = randomizer.NullableDecimal(10.0M, 100.0M);
```

### Random dates

```csharp
	IRandomizer randomizer = new Randomizer();
	DateTime startDate = new DateTime(2010, 1, 1);
	DateTime endDate = new DateTime(2022, 12, 31);
	DateTime randomDate = randomizer.Date(startDate, endDate);
	DateTime? nullableRandomDate = randomizer.NullableDate(startDate, endDate);
```

### Random datetimes

```csharp
	IRandomizer randomizer = new Randomizer();
	DateTime startDatetime = new DateTime(2010, 1, 1,0,0,0);
	DateTime endDatetime = new DateTime(2022, 12, 31,12,30,40);
	DateTime randomDatetime = randomizer.DateTime(startDatetime, endDatetime);
	DateTime? nullableRandomDatetime = randomizer.NullableDateTime(startDatetime, endDatetime);
```

### Random enums

```csharp
	enum DaysOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

	IRandomizer randomizer = new Randomizer();
	DaysOfWeek randomEnumValue = randomizer.Enumeration<DaysOfWeek>();
	DaysOfWeek? nullableRandomEnumValue = randomizer.NullableEnumeration<DaysOfWeek>();
```

### Random nullable values

```csharp
	public int CalculateSquare(int number)
	{
		return number * number;
	}

	IRandomizer randomizer = new Randomizer();

	int inputNumber = randomizer.Int(1, 10);

	int? nullableSquare = randomizer.Nullable(inputNumber, CalculateSquare);
```

### Random strings

```csharp
	IRandomizer randomizer = new Randomizer();
	string randomString = randomizer.String(10);
	string randomStringWithCustomChars = randomizer.String(10, "ABC123");
	string? nullableRandomString = randomizer.NullableString(5, 10);
```

### Random strings using StringCharacterType

```csharp
	IRandomizer randomizer = new Randomizer();
	int lenght = 30;
	string numeric = _randomizer.String(lenght, StringCharacterType.Numeric);
	string uppercaseAlpha = _randomizer.String(lenght, StringCharacterType.UppercaseAlpha);
```

## Support
If you are having problems, please let us know by [raising a new issue](https://github.com/fouad-elouad/RandomSharp/issues/new/choose).

## License
This project is licensed with the [MIT license](LICENSE).