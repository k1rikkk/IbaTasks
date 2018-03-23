using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class TypeInfo
    {
        protected Type type;

        public TypeInfo(Type type) => this.type = type;
        public static TypeInfo New<T>() => new TypeInfo(typeof(T));

        public IEnumerable<CustomAttributeData> Attributes => type.CustomAttributes;
        public IEnumerable<MethodInfo> Methods => type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(mi => !mi.IsSpecialName);
        public IEnumerable<ConstructorInfo> Constructors => type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        public IEnumerable<PropertyInfo> Properties => type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }
}
