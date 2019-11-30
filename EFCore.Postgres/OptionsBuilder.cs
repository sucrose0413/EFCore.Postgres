using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace EFCore.Postgres
{
    public class OptionsBuilder
    {
        public IList<Action<DbContextOptionsBuilder>> ContextOptionsActions = new List<Action<DbContextOptionsBuilder>>();
        public IList<Action<NpgsqlDbContextOptionsBuilder>> PostgresOptionsActions = new List<Action<NpgsqlDbContextOptionsBuilder>>();

        /// <summary>
        /// Configure EF through DbContextOptionsBuilder
        /// </summary>
        /// <param name="action"></param>
        public void Configure(Action<DbContextOptionsBuilder> action)
        {
            ContextOptionsActions.Add(action);
        }

        /// <summary>
        /// Configure Postgress through NpgsqlDbContextOptionsBuilder
        /// </summary>
        /// <param name="action"></param>
        public void DatabaseOption(Action<NpgsqlDbContextOptionsBuilder> action)
        {
            PostgresOptionsActions.Add(action);
        }
    }
}