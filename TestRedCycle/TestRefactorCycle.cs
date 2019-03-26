using Xunit;
using RefactorCycle.BL;
using RefactorCycle.Data;
using Microsoft.Extensions.DependencyInjection;
using RefactorCycle.BL.Rules;
using System.Collections.Generic;

namespace TestTDD
{
    public class TestRefactorCycle
    {
        private readonly ICashier _cashier;

        public TestRefactorCycle()
        {
            //setup our DI scan using Scruptor
            var serviceCollection = new ServiceCollection()
                .Scan(scan => scan
                .FromAssemblyOf<ISaleRules>()
                .AddClasses(classes => classes.AssignableTo<ISaleRules>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime()
                .FromAssemblyOf<IRepository>()
                .AddClasses(classes => classes.AssignableTo<IRepository>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime()
                .FromAssemblyOf<ICashier>()
                .AddClasses(classes => classes.AssignableTo<ICashier>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime()
                );

            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Arrange
            _cashier = serviceProvider.GetService<ICashier>();

        }

        [Fact]
        public void BuyerWithFiveDollar()
        {
            //Arrange
            int amount = 5;

            //Act
            var actual = _cashier.SaleTicket(amount);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void BuyerWithTenDollar()
        {
            //Arrange
            int amount = 10;
            _cashier.SaleTicket(5); //Sale with $5 first

            //Act
            var actual = _cashier.SaleTicket(amount);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void BuyerWithTwentyDollar()
        {
            //Arrange
            int amount = 20;
            //Sale with $5, $5 & $10 first
            _cashier.SaleTicket(5);
            _cashier.SaleTicket(5);
            _cashier.SaleTicket(10); 

            //Act
            var actual = _cashier.SaleTicket(amount);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void BuyerWithTwentyDollarGiveChangeWithFive()
        {
            //Arrange
            int amount = 20;
            //Sale with $5, $5 & $5 first
            _cashier.SaleTicket(5);
            _cashier.SaleTicket(5);
            _cashier.SaleTicket(5);

            //Act
            var actual = _cashier.SaleTicket(amount);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void BuyerWithOtherAmount()
        {
            //Arrange
            int amount1 = 1;
            int amount2 = 50;
            int amount3 = 100;

            //Act
            var actual1 = _cashier.SaleTicket(amount1);
            var actual2 = _cashier.SaleTicket(amount2);
            var actual3 = _cashier.SaleTicket(amount3);

            //Assert
            Assert.False(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
        }

        [Fact]
        public void MultipleBuyersSuccess()
        {
            //Arrange
            int[] buyers = { 5, 5, 5, 10, 5, 20 };

            //Act
            bool actual = false;

            foreach (int b in buyers)
            {
                actual = _cashier.SaleTicket(b);
            }

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void FailWithTenDollar()
        {
            //Arrange
            int amount = 10;

            //Act
            var actual = _cashier.SaleTicket(amount);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void FailWithTwentyDollar()
        {
            //Arrange
            int amount = 20;

            //Act
            var actual = _cashier.SaleTicket(amount);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void MultipleBuyersSuccessAndFail()
        {
            //Arrange
            int[] buyers = { 10, 5, 5, 10, 5, 20 };
            List<bool> expected = new List<bool>();
            expected.Add(false);
            expected.Add(true);
            expected.Add(true);
            expected.Add(true);
            expected.Add(true);
            expected.Add(true);

            //Act
            List<bool> actual = new List<bool>();

            foreach (int b in buyers)
            {
                actual.Add(_cashier.SaleTicket(b));
            }

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
