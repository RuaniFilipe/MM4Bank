using FluentAssertions;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Enum;
using System;
using Xunit;

namespace MM4Bank.Domain.Tests
{
    public class TransactionUnitTest
    {
        [Fact(DisplayName = "Create valid transaction")]
        public void CreateTransaction_WithValidParameters_ResultObjectValidState()
        {
            Account account1 = new();
            Account account2 = new();

            account1.Deposit(2000m);
            Action action = () =>
            {
                new Transaction(1000m, account1, account2, TransactionType.TRANSFER);
            };
            action.Should()
                .NotThrow<System.Exception>();
        }

        [Fact(DisplayName = "Create transaction with negative value")]
        public void CreateTransaction_WithNegativeValue_ResultObjectValidState()
        {
            Account account1 = new();
            Account account2 = new();

            decimal value = -1000m;
            account1.Deposit(2000m);
            Action action = () =>
            {
                new Transaction(value, account1, account2, TransactionType.TRANSFER);
            };
            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid value, value must be greater than 0");
        }

        [Fact(DisplayName = "Create transaction with no balance")]
        public void CreateTransaction_WithNoBalance_ResultObjectValidState()
        {
            Account account1 = new();
            Account account2 = new();

            Action action = () =>
            {
                new Transaction(1000m, account1, account2, TransactionType.TRANSFER);
            };
            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Not enough balance on source account.");
        }
    }
}
