﻿using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        BankAccount Account;
        public Form1()
        {
            Account = new BankAccount(
                new StandardBonusCalculator(),
                new WindowsFedNotifier());
            InitializeComponent();
            UpdateBalance();
        }

        private void UpdateBalance()
        {
            this.Text = Account.GetBalance().ToString("c");
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(Account.Deposit);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(Account.Withdraw);
        }

        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amountToDeposit = decimal.Parse(txtAmount.Text);
                op(amountToDeposit);
                UpdateBalance();
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a number you moron.",
                    "Error on transaction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (OverdraftException)
            {
                MessageBox.Show("You don't have enough money, get a job!",
                    "Error on transaction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }
    }
}
