using CoreUtility.Extensions;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System;

namespace Ability {
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class AbilityAttribute : PropertyAttribute { }
    
    [CustomPropertyDrawer(typeof(AbilityAttribute))]
    public class AbilityDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (property.propertyType != SerializedPropertyType.String) {
                EditorGUI.PropertyField(position, property, label);
                return;
            }
            
            var abilityType = typeof(IAbility);
            var abilities = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Inherits(abilityType) && !t.IsInterface && !t.IsAbstract)
                .Select((t) => t.Name)
                .ToArray();

            if (abilities.Length == 0) return;
            
            var selectedAbility = property.stringValue;
            var selectedIndex = Array.IndexOf(abilities, selectedAbility);
            if (selectedIndex == -1) selectedIndex = 0; 

            selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, abilities);
            property.stringValue = abilities[selectedIndex];
        }
    }
}