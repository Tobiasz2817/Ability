using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ability {
    public class AbilityUI : MonoBehaviour {
        public Image Icon;
        public CanvasGroup IconCanvasGroup;
        public Image FillMask;
        public Button Button;
        public int Id;

        public Action<int> OnPress;

        void Awake() =>
            IconCanvasGroup = Icon.GetComponent<CanvasGroup>();
        void Start() =>
            Button.onClick.AddListener(() => OnPress?.Invoke(Id));
        
        public void UpdateImage(Sprite sprite) {
            IconCanvasGroup.alpha = sprite != null ? 1 : 0;
            Icon.sprite = sprite;
        }

        public void SetId(int id) =>
            this.Id = id;
        public void FillAbility() =>
            FillMask.fillAmount = 1;
        public void UpdateFillAmount(float progress) =>
            FillMask.fillAmount = float.IsNaN(progress) ? 0 : progress;
    }
}