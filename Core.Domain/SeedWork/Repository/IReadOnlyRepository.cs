using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.SeedWork.Repository
{
    /// <summary>
    /// The ReadOnlyRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// The aggregate root entity.
    /// </typeparam>
    public interface IReadOnlyRepository //Entity//, IAggregateRoot
    {
        /// <summary>
        /// The find by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        Task<dynamic> FindById(int id);
        /// <summary>
        /// The find by expression.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable<T>"</T>/>.
        /// </returns>
        Task<IEnumerable<dynamic>> FindByPredicate(Expression<Func<dynamic, bool>> predicate);
        /// <summary>
        /// The find by query.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/> of T.
        /// </returns>
        Task<IEnumerable<dynamic>> FindByQuery(string query);
        /// <summary>
        /// The find by sql conditional query.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/> of T.
        /// </returns>
        Task<IEnumerable<dynamic>> FindByConditionalQuery(string id = "", string where="",string sort = "");
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/> of T.
        /// </returns>
        Task<IEnumerable<dynamic>> FindAll();


    }
}
