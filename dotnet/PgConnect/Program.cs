
using Npgsql;

Console.WriteLine("Введите имя пользователя ");// Вывод фразы
    var login = Console.ReadLine(); // Ввод юзернейма

Console.WriteLine("Введите пароль пользователя ");// Вывод фразы
    var password = Console.ReadLine(); // Ввод пароля

Console.WriteLine($"Введено имя пользователя {login}");       //user        или можно postgres

Console.WriteLine($"Введён пароль пользователя {password}");   //userpass   и пароль 23072001

    StreamReader sr = new StreamReader("../../../sdl1.conf");
        var connectionString = sr.ReadLine();

Npgsql.NpgsqlConnectionStringBuilder dot = new Npgsql.NpgsqlConnectionStringBuilder(connectionString);

    dot.Username = login;
    dot.Password = password;

await using var dataSource = NpgsqlDataSource.Create(dot); // Использование dotnet 


await using (var cmd = dataSource.CreateCommand("SELECT VERSION();")) // Вывод версии БД

await using (var reader = await cmd.ExecuteReaderAsync()) //Вывод запроса к БД в командную строку
    {
        while (await reader.ReadAsync())
             {
                 Console.WriteLine(reader.GetString(0));
             }
    }