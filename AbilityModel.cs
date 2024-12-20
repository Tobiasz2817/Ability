using System;
using System.Linq;
using CoreUtility.Extensions;
using Storex;
using UnityEngine;

namespace Ability {
    public class AbilityModel {
        const string AbilitiesFileName = "Abilities";
        
        // Contains only available Abilities
        internal AbilityData[] Abilities;
        internal Action<int, AbilityData> OnValueChanged;

        internal AbilityModel(AbilityData[] bootAbilities = null) {
            LoadAbilities(bootAbilities);
            
            Application.quitting -= SaveAbilities;
            Application.quitting += SaveAbilities;
        }

        public void AddAt(int index, AbilityData ability) {
            if (index >= Abilities.Length)
                return;

            Abilities[index] = ability;
            OnValueChanged?.Invoke(index, ability);
        }
        
        public void RemoveAt(int index) {
            if (index >= Abilities.Length)
                return;

            Abilities[index] = default;
            OnValueChanged?.Invoke(index, default);
        }
        
        public AbilityData? GetAbility(Type abilityType) =>
            Abilities.FirstOrDefault((ab) => ab.Ability.GetType() == abilityType);

        async void LoadAbilities(AbilityData[] bootAbilities) {
            var abilities = new AbilityData[AbilitiesCore.Config.AbilitiesCount];
            
            var data = StorexVault.Load<AbilitiesData>(AbilitiesFileName);
            if (data.AbilitiesIds == null || data.AbilitiesIds.Length <= 0) {
                for (var i = 0; i < bootAbilities.Length; i++) {
                    if (abilities.IsOutOfRange(i))
                        break;

                    Abilities = abilities.CopySubset(bootAbilities);
                }
                return;
            }

            var allAbilities = (await AbilitiesCore.FetchAbilities()).
                Where((abilityData) => data.AbilitiesIds.Contains(abilityData.Id)).
                ToArray();

            Abilities = abilities.CopySubset(allAbilities);
        }

        void SaveAbilities() =>
                StorexVault.Save(new AbilitiesData { AbilitiesIds = Abilities.Select((data) => data.Id).Where((id) => id != 0).ToArray() }, AbilitiesFileName);
    }

    [Serializable]
    public struct AbilitiesData {
        public int[] AbilitiesIds;
    } 
}