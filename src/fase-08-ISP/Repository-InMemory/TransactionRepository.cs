using System.Collections.Generic;
using System.Linq;

namespace Repository_JSON
{
  public class TransactionRepository : IRepository<Transaction>
  {
    private readonly List<Transaction> _transactions = new List<Transaction>();
    private int _nextId = 1;

    public void Add(Transaction entity)
    {
      entity.Id = _nextId++;
      _transactions.Add(entity);
    }

    public IEnumerable<Transaction> GetAll()
    {
      return _transactions;
    }

    public Transaction? GetById(int id)
    {
      return _transactions.FirstOrDefault(t => t.Id == id);
    }

    public void Delete(int id)
    {
      var transaction = GetById(id);
      if (transaction != null)
      {
        _transactions.Remove(transaction);
      }
    }

    public void Update(Transaction entity)
    {
      var existingTransaction = GetById(entity.Id);
      if (existingTransaction != null)
      {
        existingTransaction.Amount = entity.Amount;
        existingTransaction.Description = entity.Description;
        existingTransaction.Date = entity.Date;
      }
    }
  }
}
