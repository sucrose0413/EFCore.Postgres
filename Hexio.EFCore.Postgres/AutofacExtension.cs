using System;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Hexio.EFCore.Postgres
{
    public static class AutofacExtensions
    {
        public static void UsePostgres<T>(this ContainerBuilder builder,
            DatabaseSettings settings, Action<OptionsBuilder> action = null) where T : DbContext
        {
            var optionsBuilder = new OptionsBuilder();

            action?.Invoke(optionsBuilder);

            var module = new DatabaseModule<T>(settings, optionsBuilder);

            builder.RegisterModule(module);
        }
    }
}