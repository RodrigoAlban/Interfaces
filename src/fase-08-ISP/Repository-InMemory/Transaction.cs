using System;

namespace Repository_JSON
{
  public class Transaction
  {
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
  }
}
