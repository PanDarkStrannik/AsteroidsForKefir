using System.Collections.Generic;
using Assets.Scripts.Core.ProtoData.ModuleData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Core.ProtoData
{
    [CreateAssetMenu(fileName = "Proto Data", menuName = "Balance/Proto")]
    public class ProtoData : SerializedScriptableObject
    {
        [field:SerializeField, AssetsOnly] public GameObject prefab { get; private set; }
        [SerializeField, ListDrawerSettings(CustomAddFunction = nameof(AddProto))] private List<ProtoModule> _moduleData = new();

        public IReadOnlyList<ProtoModule> moduleData => _moduleData;

        private ProtoModule AddProto()
        {
            return new ProtoModule();
        }
    }
}
