using RandomSharp.Impl;

namespace RandomSharp.UnitTest
{
    [TestClass]
    public class UnitTestDefaultRandomizer : UnitTestBase
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            _randomizer = new DefaultRandomizer();
        }

        [TestMethod]
        public override void Enumeration_ReturnsRandomEnumValue()
        {
            base.Enumeration_ReturnsRandomEnumValue();
        }

        [TestMethod]
        public override void NullableEnumeration_ReturnsRandomEnumValueOrNull()
        {
            base.NullableEnumeration_ReturnsRandomEnumValueOrNull();
        }

        [TestMethod]
        public override void Date_ReturnsRandomDateBetweenMinAndMax()
        {
            base.Date_ReturnsRandomDateBetweenMinAndMax();
        }

        [TestMethod]
        public override void NullableDate_ReturnsRandomDateBetweenMinAndMaxOrNull()
        {
            base.NullableDate_ReturnsRandomDateBetweenMinAndMaxOrNull();
        }

        [TestMethod]
        public override void DateTime_ShouldReturnRandomDateTimeBetweenTwoDateTimes()
        {
            base.DateTime_ShouldReturnRandomDateTimeBetweenTwoDateTimes();
        }

        [TestMethod]
        public override void NullableDateTime_ShouldReturnRandomDateTimeBetweenTwoDateTimesOrNull()
        {
            base.NullableDateTime_ShouldReturnRandomDateTimeBetweenTwoDateTimesOrNull();
        }

        [TestMethod]
        public override void Boolean_ShouldReturnRandomBoolean()
        {
            base.Boolean_ShouldReturnRandomBoolean();
        }

        [TestMethod]
        public override void NullableBoolean_ShouldReturnRandomBooleanOrNull()
        {
            base.NullableBoolean_ShouldReturnRandomBooleanOrNull();
        }

        [TestMethod]
        public override void Int_ReturnsRandomIntBetweenMinAndMax()
        {
            base.Int_ReturnsRandomIntBetweenMinAndMax();
        }

        [TestMethod]
        public override void NullableInt_ReturnsRandomIntBetweenMinAndMaxOrNull()
        {
            base.NullableInt_ReturnsRandomIntBetweenMinAndMaxOrNull();
        }

        [TestMethod]
        public override void Double_ReturnsRandomDoubleBetweenMinAndMax()
        {
            base.Double_ReturnsRandomDoubleBetweenMinAndMax();
        }

        [TestMethod]
        public override void NullableDouble_ReturnsRandomDoubleBetweenMinAndMaxOrNull()
        {
            base.NullableDouble_ReturnsRandomDoubleBetweenMinAndMaxOrNull();
        }

        [TestMethod]
        public override void Decimal_ReturnsRandomDecimalBetweenMinAndMax()
        {
            base.Decimal_ReturnsRandomDecimalBetweenMinAndMax();
        }

        [TestMethod]
        public override void NullableDecimal_ReturnsRandomDecimalBetweenMinAndMaxOrNull()
        {
            base.NullableDecimal_ReturnsRandomDecimalBetweenMinAndMaxOrNull();
        }

        [TestMethod]
        public override void List_ReturnsRandomElementFromList()
        {
            base.List_ReturnsRandomElementFromList();
        }

        [TestMethod]
        public override void Parameters_ReturnsRandomElementFromParams()
        {
            base.Parameters_ReturnsRandomElementFromParams();
        }

        [TestMethod]
        public override void String_ReturnsRandomNumericString()
        {
            base.String_ReturnsRandomNumericString();
        }

        [TestMethod]
        public override void String_ReturnsRandomMixedAlphaString()
        {
            base.String_ReturnsRandomMixedAlphaString();
        }


        public override void String_ReturnsRandomMixedAlphaNumericString()
        {
            base.String_ReturnsRandomMixedAlphaNumericString();
        }

        [TestMethod]
        public override void String_ReturnsRandomLowercaseAlphaString()
        {
            base.String_ReturnsRandomLowercaseAlphaString();
        }

        [TestMethod]
        public override void String_ReturnsRandomUppercaseAlphaString()
        {
            base.String_ReturnsRandomUppercaseAlphaString();
        }

        [TestMethod]
        public override void String_ReturnsRandomLowercaseAlphaNumericString()
        {
            base.String_ReturnsRandomLowercaseAlphaNumericString();
        }

        [TestMethod]
        public override void String_ReturnsRandomUppercaseAlphaNumericString()
        {
            base.String_ReturnsRandomUppercaseAlphaNumericString();
        }

        [TestMethod]
        public override void String_ReturnsRandomStringfromChars()
        {
            base.String_ReturnsRandomStringfromChars();
        }

        [TestMethod]
        public override void List_ReturnsRandomElementFromListWithWeigth()
        {
            base.List_ReturnsRandomElementFromListWithWeigth();
        }

        [TestMethod]
        public override void Boolean_ReturnsRandomBooleanWithWeigth()
        {
            base.Boolean_ReturnsRandomBooleanWithWeigth();
        }
    }
}