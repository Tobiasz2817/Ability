using System.Collections.Generic;
using System.Threading.Tasks;
using CoreUtility;
using CoreUtility.Extensions;

namespace Ability {
    public class AbilityController {
        readonly AbilityView _view;
        readonly AbilityModel _model;

        //TODO::
        readonly ExecuteBuffer _buffer;
        readonly float _executeTime = 0.2f;

        HashSet<int> _timers = new();

        internal AbilityController(AbilityView view, AbilityModel model) {
            this._view = view;
            this._model = model;
            
            ConnectView();
            ConnectModel();

            BootView();
        }

        void ConnectView() =>
            _view.RegistryButtonCallback(UseAbility);

        void ConnectModel() =>
            _model.OnValueChanged += SwitchAbility;
        
        async void BootView() {
            while (_model.Abilities == null) 
                await Task.Yield();
            
            _model.Abilities.ForEach((ability, index) => {
                if (ability.Sprite == null)
                    return;
                
                _view.EquipAbility(index, ability);
            });
        }
        
        void SwitchAbility(int index, AbilityData data) =>
            _view.EquipAbility(index, data);
        
        void UseAbility(int index) {
            if (!_timers.Add(index))
                return;
            
            var ability = _model.Abilities[index];
            if (ability.Id == 0)
                return;
            
            _view.FillAbility(index);
            StaticTimer.RunCountdown(ability.Cooldown, 
                onComplete: () => _timers.Remove(index),
                onTick: progress => {
                    _view.UpdateFillAmount(index, progress);
                });
            
            
            // TODO:
            // Execute Ability
            // Notify Event bus for animation or more
        }
    }
}