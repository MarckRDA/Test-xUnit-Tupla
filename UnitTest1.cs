using System;
using Xunit;

namespace Test_tupla_theory
{
    public class UnitTest1
    {
        public static TheoryData<(int n1, int n2, int expectedResult)> MeuTestTupla()
        {
            return new TheoryData<(int n1, int n2, int expectedResult)>
            {
                (1,1,2),
                (3,4,7),
                (5,5,10),
                (43,5,48)
            };
        }

        [Theory]
        [MemberData(nameof(MeuTestTupla))]
        public void Should_Return_A_Sum_Between_Two_Numbers((int n1, int n2, int expectedResult) numbers)
        {
            var instancia = new TuplaTest();

            var result = instancia.soma((numbers.n1, numbers.n2));

            Assert.Equal(numbers.expectedResult, result);
        }
    }
}
