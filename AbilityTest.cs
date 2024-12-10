using System;
using UnityEngine;

namespace Ability {
    public class AbilityTest : MonoBehaviour {
        void Update() {
            var abilities = Abilities.Fetch();

            Debug.Log(abilities.Length);
        }
    }
}