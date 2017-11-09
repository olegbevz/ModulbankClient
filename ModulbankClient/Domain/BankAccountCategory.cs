namespace ModulbankClient
{
    public enum BankAccountCategory
    {
        /// <summary>
        /// Расчетный счет
        /// </summary>
        CheckingAccount,

        /// <summary>
        /// Депозитный счет
        /// </summary>
        DepositAccount,

        /// <summary>
        /// Карточный счет
        /// </summary>
        CardAccount,

        /// <summary>
        /// Счет для процентов по депозиту
        /// </summary>
        DepositRateAccount,

        /// <summary>
        /// Счет учета резервов
        /// </summary>
        ReservationAccounting
    }
}
