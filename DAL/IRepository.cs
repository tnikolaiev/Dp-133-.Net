using System.Linq;

namespace Ras.DAL
{
    /// <summary>
    ///     Represents repository of <typeparamref name="T" />. Provides methods and properties to manipulte data.
    /// </summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        ///     Represents all <typeparamref name="T" /> entities in databas.
        ///     Does not contains these entities, all queries will be applied as SQL query to database.
        /// </summary>
        IQueryable<T> All { get; }

        /// <summary>
        ///     Creates new entity in DB with given data by <paramref name="item" />.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Create(T item);

        /// <summary>
        ///     Finds and returns entities in database by <paramref name="key" /> values.
        /// </summary>
        /// <param name="key">PK values.</param>
        /// <returns></returns>
        T Read(params object[] key);

        /// <summary>
        ///     Finds entity by PK in <paramref name="item" /> and updates data in accordace to <paramref name="item" />.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Update(T item);

        /// <summary>
        ///     Removes given entity from database.
        /// </summary>
        /// <param name="item">Entity that will be removed from database.</param>
        void Delete(T item);

        /// <summary>
        ///     Removes entity from database.
        /// </summary>
        /// <param name="item">PK values.</param>
        void Delete(params object[] key);
    }
}