using System;
using System.Collections.Generic;
using System.Text;

namespace ChainBlock.Contracts
{
    public interface ITransaction
    {
        int Id { get; set; }

        TransactionStatus status { get; set; }
        string From { get; set; }
        string To { get; set; }

        double Amount { get; set; }

    }
}
