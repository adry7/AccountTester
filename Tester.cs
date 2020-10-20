using NUnit.Framework;

namespace AccountTester
{
    [TestFixture]
    public class Tester
    {
        private double epsilon = 1e-6;

        [Test]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            Account account = new Account(-20);
            Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        }

        [Test]
        public void WithdrawCannotHaveNegativeAmount()
        {

            Account account = new Account(0);
            Assert.AreEqual(false, account.Withdraw(-5));

        }

        [Test]
        public void DepositCannotHaveNegativeAmount()
        {
            Account account = new Account(0);
            Assert.AreEqual(false, account.Deposit(-5));
        }


        [Test]
        public void AccountCannotOverstepOverdraftLimit()
        {
            Account account = new Account(100);
            Assert.AreEqual(true, account.Withdraw(100));
            Assert.AreEqual(false, account.Withdraw(1));

        }

        [Test]
        public void DepositCorrectAmount()
        {
            Account account = new Account(0);
            account.Deposit(20);
            Assert.AreEqual(20, account.Balance, epsilon);


        }

        [Test]
        public void WithdrawCorrectAmount()
        {
            Account account = new Account(15);

            account.Deposit(20);

            account.Withdraw(5);

            Assert.AreEqual(15, account.Balance, epsilon);

        }

        [Test]
        public void CheckWithdrawReturnResults()
        {
            Account account = new Account(10);
            account.Deposit(20);
            Assert.AreEqual(false, account.Withdraw(35));
            Assert.AreEqual(true, account.Withdraw(5));
            Assert.AreEqual(true, account.Withdraw(25));
            Assert.AreEqual(false, account.Withdraw(1));


        }

        [Test]
        public void CheckDepositReturnResults()
        {
            Account account = new Account(0);
            Assert.AreEqual(true, account.Deposit(20));

        }


    }
}
