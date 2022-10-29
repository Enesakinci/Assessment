dotnet ef dbcontext scaffold "Host=localhost;Database=Assessment;Username=postgres;Password=asdqwe123" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities -f -project Domain


Scaffold-DbContext "Server=localhost;Port=5432;Database=Assessment;User Id=postgres;Password=asdqwe123;Integrated Security=true;Pooling=true;" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities -force
