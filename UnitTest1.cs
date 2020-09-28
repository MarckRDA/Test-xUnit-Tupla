using System;
using System.Collections.Generic;
using Xunit;

namespace Test_tupla_theory
{
    public class UnitTest1
    {
        /*Para aceitar coleções do tipo tupla, há a necessidade de transformá-las em tipos IEnumerable
         Porém, o tipo TheoryData já nos facilita há implementar essa técnica.
         Abaixo está implementada um método onde irá retornar tuplas do tipo TheoryData, onde o meu decorator [Theory]
         irá aceitar esse tipo de dado e assim se comportar como um "InlineData"
         
        */
        // Aqui apenas é definido que meu método genérico será do tipo (int, int, int) <= uma tupla, certo?
        public static TheoryData<(int n1, int n2, int expectedResult)> MeuTestTupla()
        {
            /*
                Aqui eu apenas irei retornar a quantidade de tuplas que serão meus cenários no teste mais Abaixo
                Perceba que a definição do "return new T.....<(int, int, int)>" é a mais definição da assinatura do meu método.
            */
            return new TheoryData<(int n1, int n2, int expectedResult)>
            {
                /*
                Defino aqui meus possíveis cenários para o teste. Note que é a mesma definição do inlineData, porém aqui será 
                o retorno do meu metodo. Lembre-se => [InlineData( 1, 1, 2)] seria a mesma coisa se pudesse passar a tupla como parametro desse tipo.
                */
                (1,1,2),
                (3,4,7),
                (5,5,10),
                (43,5,48)
            };
        }

        public static TheoryData<(List<int>, int expectedResult)> MeuTestLista()
        {
            return new TheoryData<(List<int>, int expectedResult)>
            {
                (new List<int> {1, 2, 3, 4, 5, 6, 7}, 28),
                (new List<int> {10, 20, 30, 11}, 71)
            };
        }
        [Theory]
        // Usamos o MemberData pois ele nos permite enviar objetos que necessitam de instancias onde o InlineData não nos permitiria
        // O nameof é onde passaremos o nome do método que criamos para serem executadas nossos cenários definidos no método acima.
        [MemberData(nameof(MeuTestTupla))]
        public void Should_Return_A_Sum_Between_Two_Numbers((int n1, int n2, int expectedResult) numbers)
        {
            // Daqui em diante é o mesmo de sempre.
            var instancia = new TuplaTest();

            var result = instancia.soma((numbers.n1, numbers.n2));

            Assert.Equal(numbers.expectedResult, result);
        }

        
        [Theory]
        [MemberData(nameof(MeuTestLista))]
        public void Should_Return_A_Sum((List<int>, int expectedResult) numbers)
        {
            // Daqui em diante é o mesmo de sempre.
            var instancia = new TuplaTest();

            var result = instancia.soma(numbers.Item1);

            Assert.Equal(numbers.expectedResult, result);
        }
    }
}
