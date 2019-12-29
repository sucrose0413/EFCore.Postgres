using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Hexio.EFCore.Postgres
{
    public class DatabaseModule<T> : Module where T : DbContext
    {
        private readonly DatabaseSettings _settings;
        private readonly OptionsBuilder _options;

        public DatabaseModule(DatabaseSettings settings, OptionsBuilder options)
        {
            _settings = settings;
            _options = options;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<T>().InstancePerLifetimeScope();

            builder.Register(_ =>
            {
                var contextOptionsBuilder = new DbContextOptionsBuilder<T>();

                foreach (var action in _options.ContextOptionsActions)
                {
                    action(contextOptionsBuilder);
                }

                contextOptionsBuilder.UseNpgsql(_settings.GetConnectionString(), x =>
                {
                    foreach (var action in _options.PostgresOptionsActions)
                    {
                        action(x);
                    }
                });

                return contextOptionsBuilder.Options;
            }).SingleInstance();
        }
    }
}