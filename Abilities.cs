namespace Ability {
    public static class Abilities {
        public static AbilityData[] Fetch() => 
            AbilitiesCore.Abilities;

        public static T Fetch<T>() {
            foreach (var abilityData in AbilitiesCore.Abilities) 
                if (abilityData.GetType() == typeof(T))
                    return (T)abilityData.Ability;

            return default;
        }
    }
}