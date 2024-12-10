using UnityEngine;
using System;
using CoreUtility.Editor;

namespace Ability {
    [CreateAssetMenu]
    public class AbilityDataScriptableObject : ScriptableObject {
        public AbilityData Data;
        void OnValidate() =>
            Data.Id = GetHashCode();
    }

    [Serializable]
    public struct AbilityData {
        public LayerMask mask;
        public int Id;
        public float Cooldown;
        public string Animation;
        public Sprite Sprite;
        [ShowInterface] [SerializeReference] public IAbility Ability;
        public string AbilityName => Ability?.GetType().Name;
    }
}