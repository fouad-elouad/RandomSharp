using RandomSharp.UnitTest.Utilities;

namespace RandomSharp.UnitTest
{
    public abstract class UnitTestBase
    {
        protected IRandomizer _randomizer = null!;

        public const string UppercaseAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LowercaseAlpha = "abcdefghijklmnopqrstuvwxyz";
        public const string Numeric = "0123456789";

        public abstract void TestInitialize();

        public virtual void Enumeration_ReturnsRandomEnumValue()
        {
            var result = _randomizer.Enumeration<TestEnum>();

            Assert.IsNotNull(result);
            Assert.IsTrue(Enum.IsDefined(typeof(TestEnum), result));
        }

        public virtual void NullableEnumeration_ReturnsRandomEnumValueOrNull()
        {
            var result = _randomizer.NullableEnumeration<TestEnum>();
            Assert.IsTrue((result != null && Enum.IsDefined(typeof(TestEnum), result)) || result == null);

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.NullableEnumeration<TestEnum>(), count);

            Assert.IsTrue(resultCounter.ListCount > 0 && resultCounter.ListCount < count);
            Assert.IsTrue(resultCounter.NullCount > 0 && resultCounter.NullCount < count);
        }

        public virtual void Date_ReturnsRandomDateBetweenMinAndMax()
        {
            var minDate = new DateTime(2020, 1, 1);
            var maxDate = new DateTime(2022, 1, 1);

            var result = _randomizer.Date(minDate, maxDate);

            Assert.IsNotNull(result);
            Assert.IsTrue(result >= minDate && result <= maxDate);
        }

        public virtual void NullableDate_ReturnsRandomDateBetweenMinAndMaxOrNull()
        {
            var minDate = new DateTime(2020, 1, 1);
            var maxDate = new DateTime(2022, 1, 1);

            var result = _randomizer.NullableDate(minDate, maxDate);

            Assert.IsTrue(result >= minDate && result <= maxDate || result == null);

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.NullableDate(minDate, maxDate), count);

            Assert.IsTrue(resultCounter.ListCount > 0 && resultCounter.ListCount < count);
            Assert.IsTrue(resultCounter.NullCount > 0 && resultCounter.NullCount < count);
            Assert.IsTrue(resultCounter.List.All(d => d >= minDate && d <= maxDate));
            Assert.IsTrue(resultCounter.List.All(d => d.Value.TimeOfDay == TimeSpan.Zero));
        }

        public virtual void DateTime_ShouldReturnRandomDateTimeBetweenTwoDateTimes()
        {
            var minDateTime = new DateTime(2023, 1, 1, 12, 0, 0);
            var maxDateTime = new DateTime(2023, 5, 5, 18, 0, 0);

            var randomDateTime = _randomizer.DateTime(minDateTime, maxDateTime);

            Assert.IsTrue(randomDateTime >= minDateTime && randomDateTime <= maxDateTime);
        }

        public virtual void NullableDateTime_ShouldReturnRandomDateTimeBetweenTwoDateTimesOrNull()
        {
            var minDateTime = new DateTime(2023, 1, 1, 12, 0, 0);
            var maxDateTime = new DateTime(2023, 5, 5, 18, 0, 0);

            var randomDateTime = _randomizer.NullableDateTime(minDateTime, maxDateTime);

            Assert.IsTrue(randomDateTime >= minDateTime && randomDateTime <= maxDateTime || randomDateTime == null);

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.NullableDateTime(minDateTime, maxDateTime), count);

            Assert.IsTrue(resultCounter.ListCount > 0 && resultCounter.ListCount < count);
            Assert.IsTrue(resultCounter.NullCount > 0 && resultCounter.NullCount < count);
            Assert.IsTrue(resultCounter.List.All(d => d >= minDateTime && d <= maxDateTime));
            Assert.IsTrue(resultCounter.List.Any(d => d.Value.TimeOfDay != TimeSpan.Zero));
        }

        public virtual void Boolean_ShouldReturnRandomBoolean()
        {
            var randomBoolean = _randomizer.Boolean();

            Assert.IsTrue(randomBoolean || !randomBoolean);
        }

        public virtual void NullableBoolean_ShouldReturnRandomBooleanOrNull()
        {
            var randomBoolean = _randomizer.NullableBoolean();

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.NullableBoolean(), count);

            Assert.IsTrue(resultCounter.ListCount > 0 && resultCounter.ListCount < count);
            Assert.IsTrue(resultCounter.NullCount > 0 && resultCounter.NullCount < count);
            Assert.IsTrue(resultCounter.List.Any(b => b.Value));
            Assert.IsTrue(resultCounter.List.Any(b => !b.Value));
        }

        public virtual void Int_ReturnsRandomIntBetweenMinAndMax()
        {
            var minInt = 1;
            var maxInt = 20;

            var result = _randomizer.Int(minInt, maxInt);

            Assert.IsNotNull(result);
            Assert.IsTrue(result >= minInt && result <= maxInt);
        }

        public virtual void NullableInt_ReturnsRandomIntBetweenMinAndMaxOrNull()
        {
            var minInt = 1;
            var maxInt = 20;

            var result = _randomizer.NullableInt(minInt, maxInt);

            Assert.IsTrue(result >= minInt && result <= maxInt || result == null);

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.NullableInt(minInt, maxInt), count);

            Assert.IsTrue(resultCounter.ListCount > 0 && resultCounter.ListCount < count);
            Assert.IsTrue(resultCounter.NullCount > 0 && resultCounter.NullCount < count);
            Assert.IsTrue(resultCounter.List.All(d => d >= minInt && d <= maxInt));
        }

        public virtual void Double_ReturnsRandomDoubleBetweenMinAndMax()
        {
            var minDouble = 1;
            var maxDouble = 20;

            var result = _randomizer.Double(minDouble, maxDouble);

            Assert.IsNotNull(result);
            Assert.IsTrue(result >= minDouble && result <= maxDouble);
        }

        public virtual void NullableDouble_ReturnsRandomDoubleBetweenMinAndMaxOrNull()
        {
            var minDouble = 1;
            var maxDouble = 20;

            var result = _randomizer.NullableDouble(minDouble, maxDouble);

            Assert.IsTrue(result >= minDouble && result <= maxDouble || result == null);

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.NullableDouble(minDouble, maxDouble), count);

            Assert.IsTrue(resultCounter.ListCount > 0 && resultCounter.ListCount < count);
            Assert.IsTrue(resultCounter.NullCount > 0 && resultCounter.NullCount < count);
            Assert.IsTrue(resultCounter.List.All(d => d >= minDouble && d <= maxDouble));
        }

        public virtual void Decimal_ReturnsRandomDecimalBetweenMinAndMax()
        {
            var minDecimal = 1;
            var maxDecimal = 20;

            var result = _randomizer.Decimal(minDecimal, maxDecimal);

            Assert.IsNotNull(result);
            Assert.IsTrue(result >= minDecimal && result <= maxDecimal);
        }

        public virtual void NullableDecimal_ReturnsRandomDecimalBetweenMinAndMaxOrNull()
        {
            var minDecimal = 1;
            var maxDecimal = 20;

            var result = _randomizer.NullableDecimal(minDecimal, maxDecimal);

            Assert.IsTrue(result >= minDecimal && result <= maxDecimal || result == null);

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.NullableDecimal(minDecimal, maxDecimal), count);

            Assert.IsTrue(resultCounter.ListCount > 0 && resultCounter.ListCount < count);
            Assert.IsTrue(resultCounter.NullCount > 0 && resultCounter.NullCount < count);
            Assert.IsTrue(resultCounter.List.All(d => d >= minDecimal && d <= maxDecimal));
        }

        public virtual void List_ReturnsRandomElementFromList()
        {
            IList<string> list = new List<string>() { "dqdqdz", "qsljku", "eaobcf", "ncvtqkd", "kfgrpmq", "jhdlpmayb", "hgsnklk" };

            string result = _randomizer.Random(list);

            Assert.IsNotNull(result);
            Assert.IsTrue(list.Contains(result));

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.Random(list), count);
            Assert.IsTrue(resultCounter.ListCount == count);
            Assert.IsTrue(resultCounter.NullCount == 0);
            Assert.IsTrue(list.All(resultCounter.List.Contains));
        }

        public virtual void Parameters_ReturnsRandomElementFromParams()
        {
            var parameters = new int[9] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            int result = _randomizer.Random(parameters);

            Assert.IsNotNull(result);
            Assert.IsTrue(parameters.Contains(result));

            var count = 100;
            var resultCounter = Helper.Run(() => _randomizer.Random(parameters), count);
            Assert.IsTrue(resultCounter.ListCount == count);
            Assert.IsTrue(resultCounter.NullCount == 0);
            Assert.IsTrue(parameters.All(resultCounter.List.Contains));
        }

        public virtual void String_ReturnsRandomNumericString()
        {
            int lenght = 30;
            var numeric = _randomizer.String(lenght, StringCharacterType.Numeric);
            Assert.AreEqual(lenght, numeric.Length);
            Assert.IsTrue(numeric.All(Numeric.Contains));
            Assert.IsTrue(!numeric.Any(UppercaseAlpha.Contains));
            Assert.IsTrue(!numeric.Any(LowercaseAlpha.Contains));
        }

        public virtual void String_ReturnsRandomMixedAlphaString()
        {
            int lenght = 30;
            var mixedAlpha = _randomizer.String(lenght, StringCharacterType.MixedAlpha);
            Assert.AreEqual(lenght, mixedAlpha.Length);
            Assert.IsTrue(mixedAlpha.Any(LowercaseAlpha.Contains));
            Assert.IsTrue(mixedAlpha.Any(UppercaseAlpha.Contains));
            Assert.IsTrue(!mixedAlpha.Any(Numeric.Contains));
        }

        public virtual void String_ReturnsRandomMixedAlphaNumericString()
        {
            int lenght = 30;
            var mixedAlphaNumeric = _randomizer.String(lenght, StringCharacterType.MixedAlphaNumeric);
            Assert.AreEqual(lenght, mixedAlphaNumeric.Length);
            Assert.IsTrue(mixedAlphaNumeric.Any(LowercaseAlpha.Contains));
            Assert.IsTrue(mixedAlphaNumeric.Any(UppercaseAlpha.Contains));
            Assert.IsTrue(mixedAlphaNumeric.Any(Numeric.Contains));
        }

        public virtual void String_ReturnsRandomLowercaseAlphaString()
        {
            int lenght = 30;
            var lowercaseAlpha = _randomizer.String(lenght, StringCharacterType.LowercaseAlpha);
            Assert.AreEqual(lenght, lowercaseAlpha.Length);
            Assert.IsTrue(lowercaseAlpha.All(LowercaseAlpha.Contains));
            Assert.IsTrue(!lowercaseAlpha.Any(UppercaseAlpha.Contains));
            Assert.IsTrue(!lowercaseAlpha.Any(Numeric.Contains));
        }

        public virtual void String_ReturnsRandomUppercaseAlphaString()
        {
            int lenght = 30;
            var uppercaseAlpha = _randomizer.String(lenght, StringCharacterType.UppercaseAlpha);
            Assert.AreEqual(lenght, uppercaseAlpha.Length);
            Assert.IsTrue(uppercaseAlpha.All(UppercaseAlpha.Contains));
            Assert.IsTrue(!uppercaseAlpha.Any(LowercaseAlpha.Contains));
            Assert.IsTrue(!uppercaseAlpha.Any(Numeric.Contains));
        }

        public virtual void String_ReturnsRandomLowercaseAlphaNumericString()
        {
            int lenght = 30;
            var lowercaseAlphaNumeric = _randomizer.String(lenght, StringCharacterType.LowercaseAlphaNumeric);
            Assert.AreEqual(lenght, lowercaseAlphaNumeric.Length);
            Assert.IsTrue(!lowercaseAlphaNumeric.Any(UppercaseAlpha.Contains));
            Assert.IsTrue(lowercaseAlphaNumeric.Any(LowercaseAlpha.Contains));
            Assert.IsTrue(lowercaseAlphaNumeric.Any(Numeric.Contains));
        }

        public virtual void String_ReturnsRandomUppercaseAlphaNumericString()
        {
            int lenght = 30;
            var uppercaseAlphaNumeric = _randomizer.String(lenght, StringCharacterType.UppercaseAlphaNumeric);
            Assert.AreEqual(lenght, uppercaseAlphaNumeric.Length);
            Assert.IsTrue(uppercaseAlphaNumeric.Any(UppercaseAlpha.Contains));
            Assert.IsTrue(!uppercaseAlphaNumeric.Any(LowercaseAlpha.Contains));
            Assert.IsTrue(uppercaseAlphaNumeric.Any(Numeric.Contains));
        }

        public virtual void String_ReturnsRandomStringfromChars()
        {
            int lenght = 30;
            string fromChars = "AZERTYU123456azerty";
            var result = _randomizer.String(lenght, fromChars);
            Assert.AreEqual(lenght, result.Length);
            Assert.IsTrue(result.All(fromChars.Contains));
            Assert.IsTrue(!result.Any("QSDFGHJKLMWXCVBNqsdfghjklmwxcvbn789".Contains));
        }

        public virtual void List_ReturnsRandomElementFromListWithWeigth()
        {
            IList<double> weight = new List<double>() { 0.35, 0.60, 0.05 };
            IList<string> list = weight.Select(w => w.ToString()).ToList();

            IList<string> result = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                var rand = _randomizer.Random<string>(list, weight.ToArray());
                result.Add(rand);
            }

            var orderedWeight = weight.Order().ToList();

            var orderedList = result
            .GroupBy(str => str)
            .OrderBy(group => group.Count())
            .SelectMany(group => group).Distinct()
            .ToList();

            var group = result.GroupBy(x => x).ToDictionary(d => d.Key, v => v.Count());

            for (int i = 0; i < orderedList.Count; i++)
            {
                Assert.AreEqual(orderedWeight[i].ToString(), orderedList[i]);
            }
        }

        public virtual void Boolean_ReturnsRandomBooleanWithWeigth()
        {

            IList<bool> result = new List<bool>();
            double trueWeight = 0.7;
            int count = 100;
            for (int i = 0; i < count; i++)
            {
                var rand = _randomizer.Boolean(trueWeight);
                result.Add(rand);
            }

            var group = result.GroupBy(x => x).ToDictionary(d => d.Key, v => v.Count());

            var falseWeight = 1 - trueWeight;
            bool condition = group[true] > group[false]; // count of true > count of false
            if (trueWeight > falseWeight)
                Assert.IsTrue(condition);
            else
                Assert.IsFalse(condition);
        }
    }
}