using System;

namespace SimpleBlockchain.Data
{
    [Serializable]
    public class BankAccount
    {
        public string OwnerName { get; set; }
        public string AccountNumber { get; set; }
    }
}