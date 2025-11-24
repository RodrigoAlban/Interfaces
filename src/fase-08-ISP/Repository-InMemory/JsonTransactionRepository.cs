using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Repository_JSON
{
  public class JsonTransactionRepository : IRepository<Transaction>
  {
    private readonly string _filePath;
    private List<Transaction> _transactions;
    private int _nextId;

    public JsonTransactionRepository(string filePath = "transactions.json")
    {
      _filePath = filePath;
      _transactions = new List<Transaction>();
      _nextId = 1;
      LoadFromJson();
    }

    private void LoadFromJson()
    {
      if (File.Exists(_filePath))
      {
        try
        {
          string json = File.ReadAllText(_filePath);
          _transactions = JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
          
          if (_transactions.Count > 0)
          {
            _nextId = _transactions.Max(t => t.Id) + 1;
          }
        }
        catch
        {
          _transactions = new List<Transaction>();
          _nextId = 1;
        }
      }
    }

    private void SaveToJson()
    {
      var options = new JsonSerializerOptions { WriteIndented = true };
      string json = JsonSerializer.Serialize(_transactions, options);
      File.WriteAllText(_filePath, json);
    }

    public void Add(Transaction entity)
    {
      entity.Id = _nextId++;
      _transactions.Add(entity);
      SaveToJson();
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
        SaveToJson();
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
        SaveToJson();
      }
    }
  }
}
