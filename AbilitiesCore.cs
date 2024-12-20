using System.Threading.Tasks;
using CoreUtility;
using UnityEngine;
using System.Linq;
using System;

namespace Ability {
    internal static class AbilitiesCore
    {
        // TODO: change to editor inspector settings
        internal static AbilityConfig Config;
        internal static AbilityData[] Abilities;
        
        #region Initialize

        [RuntimeInitializeOnLoadMethod]
        static void Initialize() {
            if(!Config.LoadInMemory) 
                return; 
            
            _ = FetchAbilities(Config);
        }
        
        internal static async Task<AbilityData[]> FetchAbilities(AbilityConfig abilityConfig = null) {
            if (Abilities != null && Abilities.Length > 0)
                return Abilities;
            
            var config = abilityConfig ?? Config;
            var abilities = (await AddressableLoad.Import<AbilityData>(SearchType.Inside, config.LabelKey)).ToArray();
            SortAbilities(ref abilities);

            Abilities = abilities;
            return Abilities;
        }

        #endregion

        internal static int GetAbilityId(Func<AbilityData, bool> condition) {
            for (var i = 0; i < Abilities.Length; i++) 
                if (condition.Invoke(Abilities[i]))
                    return i;

            return -1;
        }

        internal static AbilityData GetAbility(string typeName) =>
            Abilities.FirstOrDefault((ability) => string.Equals(ability.Ability.GetType().Name, typeName));
        
        internal static AbilityData GetAbility(int id) =>
            Abilities[id];
        
        /// <summary>
        /// Sort abilities by type name and change it on id 
        /// </summary>
        static void SortAbilities(ref AbilityData[] abilities) =>
            Array.Sort(abilities, (x, y) => -String.Compare(x.GetType().Name, y.GetType().Name, StringComparison.Ordinal));
    }
}