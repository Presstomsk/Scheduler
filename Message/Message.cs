using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Scheduler.Message
{
    /// <summary>
    /// Сообщение для обмена данными между задачами
    /// </summary>
    public class Message : IMessage
    {
        /// <summary>
        /// Тип сообщения 
        /// </summary>
        public MsgType MsgType { get; set; }
        /// <summary>
        /// Данные в формате JSON
        /// </summary>
        public string DataJson { get; set; }
        /// <summary>
        /// Данные в классе Object
        /// </summary>
        public object DataObject { get; set; }
        /// <summary>
        /// Ошибка 
        /// </summary>
        public Exception Error { get; set; }
        /// <summary>
        /// Отправить сообщение об ошибке в планировщик
        /// </summary>
        /// <param name="type">Тип сообщения</param>
        /// <param name="ex">Ошибка</param>
        public IMessage SendError(MsgType type, Exception ex)
        {
            if (type != MsgType.Data)
            {
                MsgType = type;
                DataJson = String.Empty;
                DataObject = null;
                Error = ex;
                return this;
            }
            return null;
        }
        /// <summary>
        /// Отправка данных в планировщик
        /// </summary>
        /// <typeparam name="T">Тип передаваемых данных</typeparam>
        /// <param name="data">Данные</param>        
        public IMessage SendData<T>(T data)
        {
            MsgType = MsgType.Data;
            Error = null;
            try
            {
                DataJson = JsonSerializer.Serialize<T>(data);
                DataObject = null;
                return this;
            }
            catch
            {
                DataJson = String.Empty;
                DataObject = data;
                return this;
            }
        }
        /// <summary>
        /// Получение данных из планировщика
        /// </summary>
        /// <typeparam name="T">Тип получаемых данных</typeparam>
        /// <returns>Данные</returns>
        public T GetData<T>()
        {
            if (!String.IsNullOrEmpty(DataJson))
            {
                return JsonSerializer.Deserialize<T>(DataJson);
            }
            else
            {
                return (T)DataObject;
            }
        }
    }
}
