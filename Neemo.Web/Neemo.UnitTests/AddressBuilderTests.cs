using Neemo.Providers;
using NUnit.Framework;

namespace Neemo.UnitTests
{
    [TestFixture]
    public class AddressBuilderTests
    {
        [Test]
        public void Unit()
        {
            AddressBuilder builder = new AddressBuilder();

            var results = builder.WithUnit("10").ToString();
            
            Assert.That(results, Is.EqualTo("Unit 10"));
        }

        [Test]
        public void Unit_AndStreet()
        {
            AddressBuilder builder = new AddressBuilder();

            var results = builder.WithUnit("10").WithStreet("100", "Melbourne Road").ToString();

            Assert.That(results, Is.EqualTo("Unit 10, 100 Melbourne Road"));
        }

        [Test]
        public void Unit_AndStreet_AndCity()
        {
            AddressBuilder builder = new AddressBuilder();

            var results = builder.WithUnit("10")
                .WithStreet("100", "Melbourne Road")
                .WithCity("Melbourne CBD").ToString();

            Assert.That(results, Is.EqualTo("Unit 10, 100 Melbourne Road, Melbourne CBD"));
        }

        [Test]
        public void Unit_AndStreet_AndCity_AndState()
        {
            AddressBuilder builder = new AddressBuilder();

            var results = builder.WithUnit("10")
                .WithStreet("100", "Melbourne Road")
                .WithCity("Melbourne CBD")
                .WithState("VIC")
                .ToString();

            Assert.That(results, Is.EqualTo("Unit 10, 100 Melbourne Road, Melbourne CBD, VIC"));
        }

        [Test]
        public void Unit_AndStreet_AndCity_AndState_AndPostCode()
        {
            AddressBuilder builder = new AddressBuilder();

            var results = builder.WithUnit("10")
                .WithStreet("100", "Melbourne Road")
                .WithCity("Melbourne CBD")
                .WithState("VIC")
                .WithPostCode("3000")
                .ToString();

            Assert.That(results, Is.EqualTo("Unit 10, 100 Melbourne Road, Melbourne CBD, VIC, 3000"));
        }

        [Test]
        public void Unit_AndStreet_AndCity_AndState_AndPostCode_AndCountry()
        {
            AddressBuilder builder = new AddressBuilder();

            var results = builder.WithUnit("10")
                .WithStreet("100", "Melbourne Road")
                .WithCity("Melbourne CBD")
                .WithState("VIC")
                .WithPostCode("3000")
                .WithCountry("Australia")
                .ToString();

            Assert.That(results, Is.EqualTo("Unit 10, 100 Melbourne Road, Melbourne CBD, VIC, 3000, Australia"));
        }
    }
}
