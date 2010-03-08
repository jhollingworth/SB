using System;
using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using SwanBob.Core;
using SwanBob.Data.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;

namespace SwanBob.Data.NHibernateMaps
{

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            var mappings = new AutoPersistenceModel();
            mappings.AddEntityAssembly(typeof(Class1).Assembly).Where(GetAutoMappingFilter);
            mappings.Conventions.Setup(GetConventions());
            mappings.Setup(GetSetup());
            mappings.IgnoreBase<Entity>();
            mappings.IgnoreBase(typeof(EntityWithTypedId<>));
            mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();

            return mappings;

        }

        #endregion

        private Action<AutoMappingExpressions> GetSetup()
        {
            return c =>
            {
                c.FindIdentity = type => type.Name == "Id";
            };
        }

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<SwanBob.Data.NHibernateMaps.Conventions.ForeignKeyConvention>();
                c.Add<SwanBob.Data.NHibernateMaps.Conventions.HasManyConvention>();
                c.Add<SwanBob.Data.NHibernateMaps.Conventions.HasManyToManyConvention>();
                c.Add<SwanBob.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                c.Add<SwanBob.Data.NHibernateMaps.Conventions.PrimaryKeyConvention>();
                c.Add<SwanBob.Data.NHibernateMaps.Conventions.ReferenceConvention>();
                c.Add<SwanBob.Data.NHibernateMaps.Conventions.TableNameConvention>();
            };
        }

        /// <summary>
        /// Provides a filter for only including types which inherit from the IEntityWithTypedId interface.
        /// </summary>

        private bool GetAutoMappingFilter(Type t)
        {
            return t.GetInterfaces().Any(x =>
                                         x.IsGenericType &&
                                         x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
        }
    }
}
