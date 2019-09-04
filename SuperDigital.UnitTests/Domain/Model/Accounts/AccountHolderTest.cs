using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperDigital.Domain.Model.Accounts;
using System;

namespace SuperDigital.UnitTests.Domain.Model.Accounts
{
    [TestClass]
    public class AccountHolderTest
    {
        [TestMethod]
        [TestCategory("Model UnitTests")]
        public void Constructor_WhenTryingToCreateAAccountHolder_ShouldHaveDefaultValue()
        {
            // Arrange
            var accountHolder = AccountHolder.Create("John Doe", "123456789-88", "0003325");

            // assert
            accountHolder.Name.Should().Be("John Doe");
            accountHolder.Document.Should().Be("123456789-88");
            accountHolder.Agency.Should().Be("0003325");
            accountHolder.Status.Should().Be(AccountStatus.Active);
            accountHolder.AccountBalance.Should().Be(0.00);
        }

        [TestMethod]
        [TestCategory("Model UnitTests")]
        public void Constructor_WhenTryingToCreateAAcountHolderWithCheckingAccount_ShouldByHaveDefaultValues()
        {
            // Arrange
            var accountHolder = AccountHolder
                .Create("John Doe", "123456789-88", "0003325", 150.00);
            accountHolder.ChangeAgency(new CheckingAccount("0058793", "085"));

            // assert
            accountHolder.Name.Should().Be("John Doe");
            accountHolder.Document.Should().Be("123456789-88");
            accountHolder.Agency.Should().Be("0003325");
            accountHolder.Status.Should().Be(AccountStatus.Active);
            accountHolder.AccountNumber.Should().Be("0058793");
            accountHolder.AccountDigit.Should().Be("085");
            accountHolder.AccountBalance.Should().Be(150.00);
        }

        [TestMethod]
        [TestCategory("Model UnitTests")]
        public void Constructor_WhenTryingToCreateAAcountHolderWithInvalidParameters_ShouldRaiseException()
        {
            // Arrange
            Action name = () => AccountHolder.Create("", "123456789-88", "0003325");
            Action document = () => AccountHolder.Create("John Doe", "", "0003325");
            Action agency = () => AccountHolder.Create("John Doe", "123456789-88", "");

            var accountHolder = AccountHolder
                .Create("John Doe", "123456789-88", "0003325");

            Action account = () => accountHolder.ChangeAgency(new CheckingAccount("", "085"));
            Action digit = () => accountHolder.ChangeAgency(new CheckingAccount("0058793", ""));

            // assert
            name.Should().Throw<ArgumentNullException>();
            document.Should().Throw<ArgumentNullException>();
            agency.Should().Throw<ArgumentNullException>();
            account.Should().Throw<ArgumentNullException>();
            digit.Should().Throw<ArgumentNullException>();
        }
    }
}