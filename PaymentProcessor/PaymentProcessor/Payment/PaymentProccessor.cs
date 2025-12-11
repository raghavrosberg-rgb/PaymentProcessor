using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PaymentProcessor.Payment
{
    public sealed class PaymentProccessor
    {
        ///C# — Null-conditional assignment .net 9.0
        public void Payout(Account? account, decimal amount)
        {
            if (account != null)
            {
                account.Balance -= amount;
            }
        }

        ///C# — Null-conditional assignment .net 10.0
        public void PayoutDotNet10(Account? account, decimal amount)
        {
            account?.Balance -= amount;
        }
    }
}
