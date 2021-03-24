using ChainBlock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainBlock.Models
{
    public class Transaction : ITransaction
    {
        
        public int Id { get; set; }

        public TransactionStatus status { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }

    }
}
