using System;


namespace Scheduler
{    /// <summary>
     /// Сообщение для обмена данными между задачами
     /// </summary>
    public interface IMessage
    {   
        /// <summary>
        /// Тип сообщения 
        /// </summary>
        MsgType MsgType { get; set; }
        /// <summary>
        /// Данные в формате JSON
        /// </summary>
        string DataJson { get; set; }
        /// <summary>
        /// Данные в классе Object
        /// </summary>
        object DataObject { get; set; }
        /// <summary>
        /// Ошибка 
        /// </summary>
        Exception Error { get; set; }
        /// <summary>
        /// Отправить сообщение об ошибке в планировщик
        /// </summary>
        /// <param name="type">Тип сообщения</param>
        /// <param name="ex">Ошибка</param>
        IMessage SendError(MsgType type, Exception ex);
        /// <summary>
        /// Отправка данных в планировщик
        /// </summary>
        /// <typeparam name="T">Тип передаваемых данных</typeparam>
        /// <param name="data">Данные</param>        
        IMessage SendData<T>(T data);
        /// <summary>
        /// Получение данных из планировщика
        /// </summary>
        /// <typeparam name="T">Тип получаемых данных</typeparam>
        /// <returns>Данные</returns>
        public T GetData<T>();

    }

    /// <summary>
    /// Тип сообщения
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        /// Данные
        /// </summary>
        Data,
        /// <summary>
        /// Ошибка с с генерацией исключения
        /// </summary>
        Error,
        /// <summary>
        /// Ошибка без генерации исключения
        /// </summary>
        LogError

    }
}
