using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ChainBlock.Contracts;

namespace ChainBlock.Models
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> _transactions;

        public Chainblock()
        {
            this._transactions = new Dictionary<int, ITransaction>();
        }
        public int Count => this._transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this._transactions.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException("Duplicate tx");
            }

            this._transactions[tx.Id] = tx;
           
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ITransaction tx)
        {
            if (!this._transactions.ContainsValue(tx))
            {
                return false;
            }
            return true;
        }

        public bool Contains(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id should be positive num");
            }
            if (!this._transactions.ContainsKey(id))
            {
                return false;
            }
            
                return true;
            
        }

        public IEnumerable<ITransaction> GetAllAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersByYransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
