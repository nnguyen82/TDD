using System;
using Xunit;
using Moq;
using RedCycle.BL;
using Xunit.Abstractions;
using System.Collections.Generic;

namespace TestRedCycle
{
    /*Requirement: Create a ticket system that will sale movies tickets. Ticket cost is $5. Buyer will come with $5, $10, and $20 bill. 
     * If the cashier at the time has no change then ticket cannot be sale.
     * Example: {5,5,10,10}. All four buyer can buy the ticket. {10,5,20} Only the $5 buyer can buy the ticket
     * */

    public class TestRedCycle
    {
        private readonly ICashier _cashier;

        public TestRedCycle()
        {
            //Arrange
            _cashier = new Cashier();
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
    }
}
