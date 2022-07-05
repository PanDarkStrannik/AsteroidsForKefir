using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Core.ProtoData.ModuleData
{
    public class ProtoModule
    {
        [field: SerializeField] public LogicData logicData { get; private set; }

        [field: SerializeField, ShowIf("@logicData!=null"), ValueDropdown(nameof(GetAllPossibleTypes))]
        private Type _logicType;

        private IEnumerable<ValueDropdownItem<Type>> GetAllPossibleTypes()
        {
            if (logicData == null)
                return null;
            return from x in typeof(ILogic).Assembly.GetTypes()
                let y = x.BaseType
                where !x.IsAbstract && !x.IsInterface &&
                      y is { IsGenericType: true } &&
                      y.GetGenericTypeDefinition() == typeof(Logic<>) &&
                      logicData.GetType().IsAssignableFrom(y.GetGenericArguments().First())
                select new ValueDropdownItem<Type>(x.Name,x);
        }

        private bool Validate()
        {
            return logicData != null && GetAllPossibleTypes().Any(someType=> someType.Value == _logicType);
        }
    }
}
