using UnityEngine;

namespace Ability {
    [CreateAssetMenu(menuName = "Content/Config/Ability")]
    public class AbilityConfig : ScriptableObject {
        [SerializeField] internal bool LoadInMemory;
        [SerializeField] internal string LabelKey = "Abilities";
        [SerializeField] internal int AbilitiesCount = 4;
    }
}