# SCHEDULER
Библиотека планировщика выполнения задач.<br>
Планировщик обеспечивает поочередный запуск задач, обмен сообщениями между ними, логирование выполнения каждой задачи.<br>
 
## ПРИМЕР ИСПОЛЬЗОВАНИЯ:<br><br> 

#### Формирование списка задач<br><br>

<p>using Microsoft.Extensions.Logging;</p><br>

<p>ILogger&lt;ISchedulerFactory> logger = default;</p>
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

#### Передача данных из задачи в планировщик

public class Message : IMessage

public class Data

Data data = new Data{.....};

IMessage msg = new Message().SendData(data);

#### Формирование сообщения об ошибке в планировщих с генерацией исключения

public class Message : IMessage

IMessage msg = new Message().SendError(MsgType.Error, new Exception(error.ErrorMessage));

#### Формирование сообщения об ошибке в планировщих без генерации исключения

public class Message : IMessage

IMessage msg = new Message().SendError(MsgType.LogError, new Exception(error.ErrorMessage));


#### Получение данных из планировщика

Data data = msg.GetData();

## ЛОГИРОВАНИЕ ВНУТРИ ПЛАНИРОВЩИКА:<br><br>

2022-09-14 19:41:44.127 [INF] {"SourceContext":"Scheduler.ISchedulerFactory","client":"client"} [14.09.2022 19:41:44] PROCESS : CitiesDatabaseUpdateWorkflow, STEP[1] : GetUpdateDBDate, STATUS: DONE, Длительность операции : 00:00.39 

2022-09-14 19:00:54.175 [INF] {"SourceContext":"Scheduler.ISchedulerFactory","client":"client"} [14.09.2022 19:00:54] PROCESS : InputDataValidationWorkflow, Validator : Start, STATUS: ERROR, Введите пункт отправления! 

2022-09-15 11:56:58.644 [INF] {"SourceContext":"Scheduler.ISchedulerFactory","client":"client"} [15.09.2022 11:56:58] PROCESS : InputDataValidationWorkflow, STEP[1] : Start, STATUS: ERROR, System.DivideByZeroException: Attempted to divide by zero.
   at Scheduler.SchedulerFactory.Start(IMessage msg) in C:\Users\user\source\repos\NewRepo4\AviaTickets\Scheduler\Scheduler\SchedulerFactory.cs:line 116
   at AviaTickets.Processes.InputDataValidationWorkflow.Start() in C:\Users\user\source\repos\NewRepo4\AviaTickets\AviaTickets\Processes\InputDataValidationWorkflow.cs:line 48
   at AviaTickets.Processes.InputDataValidationWorkflow.Start(IMessage msg) in C:\Users\user\source\repos\NewRepo4\AviaTickets\AviaTickets\Processes\InputDataValidationWorkflow.cs:line 43
   at Scheduler.SchedulerFactory.Start(IMessage msg) in C:\Users\user\source\repos\NewRepo4\AviaTickets\Scheduler\Scheduler\SchedulerFactory.cs:line 87 







        



