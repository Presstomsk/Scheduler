# SCHEDULER
Библиотека планировщика выполнения задач.<br>
Планировщик обеспечивает поочередный запуск задач, обмен сообщениями между ними, логирование выполнения каждой задачи.<br>
 
## ПРИМЕР ИСПОЛЬЗОВАНИЯ:<br><br> 

#### Формирование списка задач<br><br>

<p>using Microsoft.Extensions.Logging;</p><br>

<p>ILogger<ISchedulerFactory> logger = default;</p>
<p>ISchedulerFactory scheduler = new SchedulerFactory(logger);</p>
<p>public IMessage Some_Func_1(IMessage msg = default) {return msg;}</p>
<p>var msg = scheduler.Create().Do(Some_Func_1).Do(Some_Func_2).Do(Some_Func_3).Start(Some_IMessage);</p><br>

#### Формирование вложенного списка задач<br><br>

<p>using Microsoft.Extensions.Logging;</p><br>

<p>ILogger&lt;ISchedulerFactory> logger = default;</p>
<p>ISchedulerFactory scheduler1 = new SchedulerFactory(logger).Create().Do(Some_Func_1).Do(Some_Func_2).Do(Some_Func_3);</p>
<p>ISchedulerFactory scheduler2 = new SchedulerFactory(logger).Create().Do(Some_Func_4).Do(Some_Func_5).Do(Some_Func_6);</p>
<p>......</p>				  
<p>public IMessage Some_Func_1(IMessage msg = default) {return msg;}</p>
<p>......</p>	
<p>var msg = new SchedulerFactory(logger).Create().Do(scheduler1.Start).Do(scheduler2.Start).Do(scheduler3.Start).Start(Some_IMessage);</p><br>

#### Формирование положительного сообщения<br><br>

<p>public class Message : IMessage</p><br>
<p>public class Data</p><br>

<p>Data data = new Data{.....};</p>
<p>IMessage msg = new Message(data, data.GetType());</p><br>

#### Формирование отрицательного сообщения с генерацией исключения в коде<br><br>

<p>public class Message : IMessage</p><br>
<p>IMessage msg = new Message(null, null, false, new Exception("error"));</p><br>

#### Формирование отрицательного сообщения без генерации исключения в коде<br><br>

<p>public class Message : IMessage</p><br>
<p>IMessage msg = new Message(null, null, false, new Exception("error"), true);</p><br><br>

## ЛОГИРОВАНИЕ ВНУТРИ ПЛАНИРОВЩИКА:<br><br>

2022-09-14 19:41:44.127 [INF] {"SourceContext":"Scheduler.ISchedulerFactory","client":"client"} [14.09.2022 19:41:44] PROCESS : CitiesDatabaseUpdateWorkflow, STEP[1] : GetUpdateDBDate, STATUS: DONE, Длительность операции : 00:00.39 

2022-09-14 19:00:54.175 [INF] {"SourceContext":"Scheduler.ISchedulerFactory","client":"client"} [14.09.2022 19:00:54] PROCESS : InputDataValidationWorkflow, Validator : Start, STATUS: ERROR, Введите пункт отправления! 







        



