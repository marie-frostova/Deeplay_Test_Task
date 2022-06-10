# Enterprise Personnel Accounting

### Что это и как работает
1. Стартовая страница - это поиск. Можно искать сотрудников по ФИО, позиции и отделу. Результат поиска внизу страницы, выдается по 10 человек на страницу.
![alt text](https://github.com/marie-frostova/Deeplay_Test_Task/blob/master/Images/2.jpg?raw=true)
2. Если нажать на кнопку "Add Employee", то попадем на страницу, где можно заполнить всю информацию о сотруднике. В поле ввода менеджера применяется технология ajax, которая позволяет пользователю получать возможные варианты для ввода не перезагружая страницу.
![alt text](https://github.com/marie-frostova/Deeplay_Test_Task/blob/master/Images/1.jpg?raw=true)
3. Также если кликнуть на любого сотрудника, то можно увидеть всю информацию о нем. если у него есть подчиненные, то мы можем увидеть их в списке. Любого сотрудника можно редактировать или удалять.
![alt text](https://github.com/marie-frostova/Deeplay_Test_Task/blob/master/Images/3.jpg?raw=true)
4. Еще можно добавлять и удалять позиции в списке всех позиций. Каждую позицию можно редактировать. То же самое касается отделов.
![alt text](https://github.com/marie-frostova/Deeplay_Test_Task/blob/master/Images/4.jpg?raw=true)

### Архитектура
В качестве архитектурного решения был выбран паттерн MVC на основе ASP .Net Core, так как это не предполагает написания отдельной клиентской части сервиса.<br />
(1) Пользователь посредством View посылает запрос<br />
(2) Запрос обрабатывается контроллером. Контроллер, если необходимо, обращается к модели<br />
(3) Модель отдает контроллеру необходимые данные<br />
(4) Контроллер генерирует представление для пользователя<br />
На картинке показано, какие основные модели используются, чтобы описывать данные в проекте.<br />
Также можно увидеть, что в контроллерах методы связаны с соответствующими представлениями цветом.<br />
Контроллеры сами не общаются с базой данных, для этого есть сервисы: `IEmployeeService`, `IPositionService`...<br />
![alt text](https://github.com/marie-frostova/Deeplay_Test_Task/blob/master/Images/Architecture.jpg?raw=true)

### Стек технологий
- ASP .NET Core MVC (.NET 6)
- Razor (+JS)

### Чтобы запустить этот проект, вам нужно проделать следующие шаги:
1. Скачать репозиторий себе на компьютер
2. В Microsoft SQL Manager Studio ( или где либо еще ) создать новую базу данных
3. В Visual Studio ( или другой IDE ) установить через менеджер пакетов:
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFramework
4. Открываем appsettings.json и в пустую строку `"DefaultConnection": ""` вписываем `Server=[server_name];Database=[database_name];Trusted_Connection=True;`
5. Tools -> Connect to Database... - подключиться к созданной ранее базе данных
6. Tools -> NuGet Package Manager -> Package Manager Console
7. В открывшейся консоли вводим следующие команды:
    - `Add-Migration [name]`
    - `Update-Database`
8. Если вы правильно проделали эти шаги, у вас проект должен запускаться
