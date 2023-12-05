namespace Adventoofcode2023.Day01
{
    public class UnitTest1
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            int s = part01.Sum();

            Assert.Equal(142, s);

        }
        [Fact]
        public void Test02()
        {
            Part02 part02 = new();

            int s = part02.Sum();

            Assert.Equal(281, s);
        }
    }
}