using System;
using System.Windows;

namespace BankAccountApp
{
    public partial class MainWindow : Window
    {
        private BankAccount myAccount;

        public MainWindow()
        {
            InitializeComponent();
            myAccount = new BankAccount("UA123456789", 1000.00);
            UpdateAccountInfo();
        }

        private void UpdateAccountInfo()
        {
            txtAccountNumber.Text = myAccount.AccountNumber;
            txtBalance.Text = myAccount.Balance.ToString("C");
        }

        private void BtnDeposit_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double amount))
            {
                if (myAccount.Deposit(amount, out string errorMessage))
                {
                    UpdateAccountInfo();
                    MessageBox.Show("Баланс успішно поповнено!");
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Введіть правильну суму.");
            }
        }

        private void BtnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double amount))
            {
                if (myAccount.Withdraw(amount, out string errorMessage))
                {
                    UpdateAccountInfo();
                    MessageBox.Show("Кошти успішно зняті!");
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Введіть правильну суму.");
            }
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(myAccount.GetAccountInfo());
        }
    }

    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public double Balance { get; private set; }

        public BankAccount(string accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public bool Deposit(double amount, out string errorMessage)
        {
            if (amount > 0)
            {
                Balance += amount;
                errorMessage = null;
                return true;
            }
            else
            {
                errorMessage = "Сума повинна бути більшою за нуль.";
                return false;
            }
        }

        public bool Withdraw(double amount, out string errorMessage)
        {
            if (amount > 0)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    errorMessage = null;
                    return true;
                }
                else
                {
                    errorMessage = "Недостатньо коштів на рахунку.";
                }
            }
            else
            {
                errorMessage = "Сума повинна бути більшою за нуль.";
            }
            return false;
        }

        public string GetAccountInfo()
        {
            return $"Номер рахунку: {AccountNumber}\nПоточний баланс: {Balance:C}";
        }
    }
}
