using Repository_JSON;

Console.WriteLine("=== Banco Digital - Teste de Transações ===");

// Instanciando o Repositório JSON
IRepository<Transaction> repository = new JsonTransactionRepository();

var transacao1 = new Transaction
{
  Amount = 150.00m,
  Description = "Transferência PIX",
  Date = DateTime.Now
};

var transacao2 = new Transaction
{
  Amount = 59.90m,
  Description = "Pagamento débito",
  Date = DateTime.Now
};

Console.WriteLine("\nAdicionando transações...");
repository.Add(transacao1);
repository.Add(transacao2);

Console.WriteLine("\nListando todas as transações:");
foreach (var t in repository.GetAll())
{
  Console.WriteLine($"ID: {t.Id} | Data: {t.Date} | Descrição: {t.Description} | Valor: {t.Amount:C}");
}


Console.WriteLine("\nBuscando transação ID 1:");
var busca = repository.GetById(1);
if (busca != null)
{
  Console.WriteLine($"Encontrado: {busca.Description} - {busca.Amount:C}");
}

if (busca != null)
{
  Console.WriteLine("\nAtualizando transação ID 1...");
  busca.Amount = 200.00m;
  repository.Update(busca);

  var atualizada = repository.GetById(1);
  Console.WriteLine($"Novo valor: {atualizada?.Amount:C}");
}



Console.WriteLine("\nDeletando transação ID 2...");
repository.Delete(2);

Console.WriteLine("\nLista final:");
foreach (var t in repository.GetAll())
{
  Console.WriteLine($"ID: {t.Id} | {t.Description} | {t.Amount:C}");
}
