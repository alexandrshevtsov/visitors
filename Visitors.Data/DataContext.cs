using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Visitors.Domain;

namespace Visitors.Data
{
    public class DataContext : DbContext, IDataContext
    {
        #region Ctor

        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion

        #region Utilities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                    type.BaseType.GetGenericTypeDefinition() == typeof(DbEntityConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configuration = Activator.CreateInstance(type);
                configuration.ApplyConfiguration(modelBuilder);
            }
            //...or do it manually below. For example,
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        
        #endregion
    }
}
