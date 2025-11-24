using System.Collections.Generic;

namespace Repository_JSON
{
    // Interface para leitura (Query/Read)
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
    }

    // Interface para adição e atualização (Command/Write)
    public interface IWritableRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
    }

    // Interface para remoção (Command/Delete)
    public interface IRemovableRepository<T>
    {
        void Delete(int id);
    }

    // O Repositório Completo (agrega as outras interfaces)
    // Uma classe pode implementar esta interface se precisar de todas as operações.
    public interface IRepository<T> : IReadOnlyRepository<T>, IWritableRepository<T>, IRemovableRepository<T>
    {
        // Esta interface herda todos os métodos das interfaces menores
    }
}