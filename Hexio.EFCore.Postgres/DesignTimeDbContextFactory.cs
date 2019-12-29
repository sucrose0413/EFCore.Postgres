using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hexio.EFCore.Postgres
{
    public static class DesignTimeDbContextFactory<T> where T : DbContext
    {
        public class Postgres : IDesignTimeDbContextFactory<T>
        {
            public T CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<T>();

                builder.UseNpgsql("Server=localhost;");

                var arguments = new object[]
                {
                    builder.Options,
                };

                var instance = Activator.CreateInstance(typeof(T), arguments);

                return instance as T;
            }
        }
    }
}