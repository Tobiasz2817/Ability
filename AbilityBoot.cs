using System.Linq;
using UnityEngine;

namespace Ability {
    public class AbilityBoot : MonoBehaviour {
        AbilityModel _model;
        AbilityController _controller;

        public AbilityView _view;
        public AbilityDataScriptableObject[] _bootData;
        
        void Awake() {
            /*var abilities = _bootData.Select((data) => data.Data).ToArray();
            
            _model = new AbilityModel(abilities);
            _controller = new AbilityController(_view, _model);*/
        }
    }
}
