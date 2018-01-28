// This class is auto generated

using System;
using System.Collections.Generic;

namespace NaughtyAttributes.Editor
{
    public static class PropertyMetaDatabase
    {
        private static Dictionary<Type, PropertyMeta> metasByAttributeType;

        static PropertyMetaDatabase()
        {
            metasByAttributeType = new Dictionary<Type, PropertyMeta>();
            metasByAttributeType[typeof(BlankSpaceAttribute)] = new BlankSpacePropertyMeta();
metasByAttributeType[typeof(InfoBoxAttribute)] = new InfoBoxPropertyMeta();
metasByAttributeType[typeof(OnValueChangedAttribute)] = new OnValueChangedPropertyMeta();
metasByAttributeType[typeof(SectionAttribute)] = new SectionPropertyMeta();

        }

        public static PropertyMeta GetMetaForAttribute(Type attributeType)
        {
            PropertyMeta meta;
            if (metasByAttributeType.TryGetValue(attributeType, out meta))
            {
                return meta;
            }
            else
            {
                return null;
            }
        }
    }
}

