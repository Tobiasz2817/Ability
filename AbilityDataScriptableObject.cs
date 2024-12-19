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
        public int Id;
        public float Cooldown;
        public string Animation;
        public Sprite Sprite;
        
        public string AbilityName => Ability?.GetType().Name;
        
        [ShowInterface] [SerializeReference] 
        public IAbility Ability;
    }
}