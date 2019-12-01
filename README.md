# EFCore.Postgres

This is a simple and small package for making it easier to integrate EntityFramework with Postgres into your application

The package includes an extension method for Autofac for easy Dependency Injection

## How to use

To register the database include the following in your ConfigureContainer method in Startup.cs

``` cs
var config = _configuration.GetSection("Postgres").Get<DatabaseSettings>();

builder.UsePostgres<MyDbContext>(config);
```

Be sure to setup your environment variables, these are the avilable ones

``` cs
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool DisableSSL { get; set; }
        public int Port { get; set; } = 5432;
        public bool TrustServerCertificate { get; set; } = false;
```

Create your DBContext
 
``` cs
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }

    public DbSet<MyEntity> MyEntity { get; set; }
}
```

To make migrations work, create a class with the following content

``` cs
public class ContextFactory : DesignTimeDbContextFactory<MyDbContext>.Postgres
{
}
```

And then include this somewhere in your startup code e.g in Startup.cs Configure method

``` cs
myDbContext.Database.Migrate();
```
