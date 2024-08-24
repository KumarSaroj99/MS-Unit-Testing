using System.Security.Principal;

namespace BanckTransactionMSTest
{
    [TestClass]
    public class UnitTest1
    {
        BankAccount _bank;
        public UnitTest1() 
        { 
            _bank = new BankAccount();
        }
        [TestMethod]
        public void IsDepositAmount_1000_DepositedCheckByIncreasedAmount()
        {

            double amountToDeposit = 1000;
            double expectedBalance = 1000;
            _bank.Deposit(amountToDeposit);
            double actualBalance = _bank.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance);
        }
        [TestMethod]
        public void IsWithdrawalAmount_100_WithdrawCheckByDecreasedAmount()
        {
            double amountToDeposit = 1000;
            _bank.Deposit(amountToDeposit);
            double amountToWithdraw = 100;
            double expectedBalance = 900;
            _bank.Withdraw(amountToWithdraw);
            double actualBalance = _bank.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance);
        }
        [TestMethod]
        public void IsBalanceDecreasesAfterTransfer_100_FromYourAccount()
        {
            double amountToDeposit = 1000;
            _bank.Deposit(amountToDeposit);
            double amountToTransfer= 100;
            BankAccount account = new BankAccount();
            _bank.Transfer(account, amountToTransfer);
            double expectedBalance = 900;
            double actualBalance = _bank.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance);

        }
        [TestMethod]
        public void ISBalanceIncreasedAfterTransfer_100_AmountToReceiverAccount()
        {
            double amountToDeposit = 1000;
            _bank.Deposit(amountToDeposit);
            double amountToTransfer = 100;
            BankAccount account = new BankAccount();
            _bank.Transfer(account, amountToTransfer);
            double expectedBalanceOfReceivedAccount = 100;
            double actualBalanceOfReceivedAccount = account.GetBalance();

            Assert.AreEqual(expectedBalanceOfReceivedAccount, actualBalanceOfReceivedAccount);
        }
        [TestMethod]
        public void DepositeExceptionForNegitiveAmount()
        {
            BankAccount account=new BankAccount();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                account.Deposit(-100);
            });
        }
        [TestMethod]
        public void WithdrawExceptionForNegitiveAmount()
        {
            BankAccount account = new BankAccount();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                account.Withdraw(-100);
            });
        }
        [TestMethod]
        public void WithdrawExceptionForInsufficientBalance()
        {
            BankAccount account = new BankAccount();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                account.Withdraw(100);
            });
        }
    }
}