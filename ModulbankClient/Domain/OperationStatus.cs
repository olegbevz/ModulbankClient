namespace ModulbankClient
{
    public enum OperationStatus
    {
        /// <summary>
        /// Исходящая, ожидающая исполнения
        /// </summary>
        SendToBank,

        /// <summary>
        /// Исходящий исполненный
        /// </summary>
        Executed,

        /// <summary>
        /// Исходящая, отказано банком в исполнении
        /// </summary>
        RejectByBank,

        /// <summary>
        /// Исходящая, отправленная в банк и отменённая пользователем
        /// </summary>
        Canceled,

        /// <summary>
        /// Входящая исполненная
        /// </summary>
        Received
    }
}
