using System;
using CoreUtility.Extensions;
using UnityEngine;

namespace Ability {
    public class AbilityView : MonoBehaviour {
        [SerializeField] AbilityUI[] _uis;

        void Awake() =>
            _uis.ForEach((ui, index) => ui.SetId(index));
        internal void RegistryButtonCallback(Action<int> callback) =>
            _uis.ForEach((ui) => ui.OnPress += callback);
        internal void EquipAbility(int index, AbilityData data) =>
            _uis[index].UpdateImage(data.Sprite);      
        internal void FillAbility(int id) =>
            _uis[id].FillAbility();
        internal void UpdateFillAmount(int id, float progress) =>
            _uis[id].UpdateFillAmount(progress);
    }
}