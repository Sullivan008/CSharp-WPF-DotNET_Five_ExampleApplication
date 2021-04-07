using System;
using System.ComponentModel;
using Application.Core.Environment.Enums;
using Application.Core.Environment.Exceptions;
using Application.Core.Environment.StaticValues;
using Application.Core.Environment.StaticValues.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Application.DataAccessLayer.ContextFactory.Abstractions
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        public TContext CreateDbContext(string[] args)
        {
            EnvironmentType environmentType = GetEnvironmentType();

            return Create(environmentType);
        }

        private TContext Create(EnvironmentType environmentType)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString($"{environmentType}Connection");

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "The value cannot be null!");
            }

            DbContextOptionsBuilder<TContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(connectionString);

            DbContextOptions<TContext> options = optionsBuilder.Options;

            return CreateNewInstance(options);
        }

        private static string GetEnvironmentTypeName()
        {
            string result = Environment.GetEnvironmentVariable(EnvironmentVariables.GetEnvironmentVariableKey(EnvironmentVariableKey.AspNetCoreEnvironment));

            if (string.IsNullOrWhiteSpace(result))
            {
                throw new MissingEnvironmentVariableException($"The following Environment Variable does not exist with this key. {nameof(EnvironmentVariableKey).ToUpper()}: {EnvironmentVariableKey.AspNetCoreEnvironment}");
            }

            return result;
        }

        private static EnvironmentType GetEnvironmentType()
        {
            string environmentTypeName = GetEnvironmentTypeName();

            if (!Enum.TryParse(environmentTypeName, out EnvironmentType environmentType))
            {
                throw new InvalidEnumArgumentException($"The following environment type name is invalid. {nameof(environmentTypeName).ToUpper()}: {environmentTypeName}");
            }
            
            return environmentType;
        }
    }
}
