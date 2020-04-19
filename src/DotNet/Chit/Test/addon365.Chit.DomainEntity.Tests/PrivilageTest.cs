using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using addon365.Chit.DomainEntity;
using System.Reflection;

namespace addon365.Chit.DomainEntity.Tests
{
    public class PrivilageTest
    {
        PrivilageValues _privilageValues;
        
        public PrivilageTest()
        {
            _privilageValues = new PrivilageValues();
        }

        [Fact]
        public void ValidatingDefaultValues()
        {
            

            foreach (Privilage v in _privilageValues.MyProperty)
            {

                Type DataType = GetProperty(v.Source,v.PropertyName).PropertyType;

                var ff = Convert.ChangeType(v.DefaultValue, DataType);

                Assert.NotNull(ff);
            }
      

        }

        [Fact]
        public void SetDefaultValues_ToProperty()
        {
           

            foreach (Privilage v in _privilageValues.MyProperty)
            {                

                PropertyInfo prop = GetProperty(v.Source,v.PropertyName);
                prop.SetValue(GetInstance(v.Source), Convert.ChangeType(v.DefaultValue, prop.PropertyType));


            }
         
        }
        private Type GetType(string source)
        {
            int li = source.LastIndexOf('.');
            string assembly = source.Substring(0, li);

            Type type = Type.GetType(source + "," + assembly);

            if (type == null)
                throw new Exception("Assembly Missing(DLL) :" + assembly);

            return type;
        }
        private PropertyInfo GetProperty(string source,string propertyName)
        {
            return GetType(source).GetProperty(propertyName);
        }
        private object GetInstance(string source)
        {

            Type type = GetType(source);
            object instance = null;


            ConstructorInfo ctor = type.GetConstructor(new Type[] { });
            instance = ctor.Invoke(new object[] { });
            return instance;
        }
    }
}
