using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModulbankClient
{
    public interface IModulbankClient
    {
        /// <summary>
        /// Получение информации о компаниях пользователя и счетах компаний пользователя.
        /// </summary>
        /// <returns>В случае успеха возвращает информацию о компаниях и счетах пользователя</returns>
        IEnumerable<Company> GetAccountInfo();

        /// <summary>
        /// Получение баланса по счету
        /// </summary>
        /// <param name="bankAccountId">Cистемный идентификатор счета, по которому запрашиваются баланс</param>
        /// <returns>В случае успеха возвращает сумму остатка денежных средств на счете</returns>
        double GetBalance(Guid bankAccountId);

        /// <summary>
        /// Просмотр истории операций по счету
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <param name="condition"></param>
        /// <returns>В случае успеха возвращает список операций по счету</returns>
        IEnumerable<Operation> GetOperationHistory(Guid bankAccountId, OperationCondition condition);

        /// <summary>
        /// Получение информации о компаниях пользователя и счетах компаний пользователя.
        /// </summary>
        /// <returns>В случае успеха возвращает информацию о компаниях и счетах пользователя</returns>
        Task<IEnumerable<Company>> GetAccountInfoAsync();

        /// <summary>
        /// Получение баланса по счету
        /// </summary>
        /// <param name="bankAccountId">Cистемный идентификатор счета, по которому запрашиваются баланс</param>
        /// <returns>В случае успеха возвращает сумму остатка денежных средств на счете</returns>
        Task<double> GetBalanceAsync(Guid bankAccountId);

        /// <summary>
        /// Просмотр истории операций по счету
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <param name="condition"></param>
        /// <returns>В случае успеха возвращает список операций по счету</returns>
        Task<IEnumerable<Operation>> GetOperationHistoryAsync(Guid bankAccountId, OperationCondition condition);
    }
}
