# Enterprise Personnel Accounting

### Что это и как работает



### Архитектура


### Стек технологий
- ASP NET Core MVC (.NET 6)
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
