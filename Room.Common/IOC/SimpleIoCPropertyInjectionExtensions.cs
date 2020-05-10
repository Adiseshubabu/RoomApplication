using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Advanced;
using System.Reflection;

namespace Room.Common.IOC
{
    public static class SimpleIoCPropertyInjectionExtensions
    {
        public static void AutowirePropertiesWithAttribute<TAttribute>(
          this ContainerOptions options)
          where TAttribute : Attribute
        {
            options.PropertySelectionBehavior =
                new AttributePropertyInjectionBehavior(
                    options.PropertySelectionBehavior,
                    typeof(TAttribute));
        }

        private sealed class AttributePropertyInjectionBehavior
            : IPropertySelectionBehavior
        {
            private readonly IPropertySelectionBehavior behavior;
            private readonly Type attribute;

            public AttributePropertyInjectionBehavior(
                IPropertySelectionBehavior baseBehavior,
                Type attributeType)
            {
                this.behavior = baseBehavior;
                this.attribute = attributeType;
            }

            public bool SelectProperty(Type type, PropertyInfo prop)
            {
                return this.IsPropertyDecorated(prop) ||
                    this.behavior.SelectProperty(type, prop);
            }

            private bool IsPropertyDecorated(PropertyInfo p)
            {
                return p.GetCustomAttributes(this.attribute, true).Any();
            }
        }
    }
}
