using System;
using UnityEngine;

namespace Ability {
    public class DamageReduction : IAbility {
        public int reduction;
        public int percent;
    }
    
    public interface IAbility {
        
    }
    
    public class AterDash : IAbility {
    }
    
    public class AkerDash : IAbility {
        
    }
    
    [Serializable]
    public class DamsageReduction : IAbility {
        public int reduction;
        public int percent;
        public GameObject go;
    }
    public class ZakaAbility : IAbility {
        
    }
    
    public class Dash : IAbility {
        public int power;
        public int duration;
        public int time;
    }
}