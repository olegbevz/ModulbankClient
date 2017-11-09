namespace ModulbankClient
{
    public enum BankAccountStatus
    {
        /// <summary>
        /// Открытый
        /// </summary>
        New,

        /// <summary>
        /// Удаленный
        /// </summary>
        Deleted,

        /// <summary>
        /// Закрытый
        /// </summary>
        Closed,

        /// <summary>
        /// Замороженный
        /// </summary>
        Freezed,

        /// <summary>
        /// В процессе закрытия
        /// </summary>
        ToClosed,

        /// <summary>
        /// В процессе открытия
        /// </summary>
        ToOpen
    }
}
