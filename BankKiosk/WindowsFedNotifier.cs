using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    class WindowsFedNotifier : INotifyTheFeds
    {
        public void NotifyOfWithdrawal(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show("The fed has been notified of your activity.");
        }
    }
}
