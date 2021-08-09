using NUnit.Framework;

namespace Tests
{
    public class AClass
    {
        public int value { get; set; }

        public AClass(int value)
        {
            this.value = value;
        }
    }

    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class NunitNotThreadSafeTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        public void ShouldBeSameNumber0(int number)
        {
            var testable = new AClass(number);
            Assert.That(testable.value, Is.EqualTo(number));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        public void ShouldBeSameNumber1(int number)
        {
            var testable = new AClass(number);
            Assert.That(testable.value, Is.EqualTo(number));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        public void ShouldBeSameNumber2(int number)
        {
            var testable = new AClass(number);
            Assert.That(testable.value, Is.EqualTo(number));
        }
    }
}
