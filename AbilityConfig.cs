using CoreUtility.Extensions;
using System.Linq;
using UnityEngine;
using CoreUtility;

namespace Ability {
    [CreateAssetMenu(menuName = "Content/Config/Ability")]
    public class AbilityConfig : ScriptableObject {
        [SerializeField]
        internal bool LoadInMemory;
        [SerializeField]
        internal string LabelKey = "Abilities";
        // More Reading types -> Resources/Base
        [SerializeField]
        internal int AbilitiesCount = 4;

        [SerializeField]
        internal string[] PathList;
        [SerializeField]
        internal SearchType SearchType;

        [SerializeField]
        internal string FolderName;
        [SerializeField]
        internal string CoreFolderName = "Assets";

        
        void SearchFolder() {
            if (string.IsNullOrEmpty(FolderName)) 
                return;
            
            var path = FileHelper.FindFolder(CoreFolderName, FolderName);
            if (string.IsNullOrEmpty(path)) {
                Debug.LogError("Folder Name didn't contains in repository");
                return;
            }
            
            FolderName = string.Empty;

            if (PathList.Contains(path)) {
                Debug.LogWarning("Folder exist in importer array");
                return;
            }
            
            PathList = PathList.Add(path);
        }
    }
}

// Odin Template
/*
    public class AbilityConfig : ScriptableObject {
        [SerializeField]
        [BoxGroup("General", ShowLabel = false)]
        [TitleGroup("General/Settings")]
        internal bool LoadInMemory;
        [SerializeField]
        [BoxGroup("General", ShowLabel = false)]
        [TitleGroup("General/Settings")]
        internal string LabelKey = "Abilities";
        // More Reading types -> Resources/Base
        [SerializeField]
        [BoxGroup("General", ShowLabel = false)]
        [TitleGroup("General/Settings")]
        internal int AbilitiesCount = 4;

        [SerializeField]
        [BoxGroup("ImporterGroup", ShowLabel = false)]
        [TitleGroup("ImporterGroup/Importer")]
        internal string[] PathList;
        [SerializeField]
        [TitleGroup("ImporterGroup/Importer")]
        internal SearchType SearchType;

        [SerializeField]
        [TitleGroup("FindGroup/Finder")]
        [BoxGroup("FindGroup", ShowLabel = false)]
        internal string FolderName;
        [ReadOnly]
        [SerializeField]
        [TitleGroup("FindGroup/Finder")]
        internal string CoreFolderName = "Assets";

        [Button]
        [TitleGroup("FindGroup/Finder")]
        [ButtonGroup("FindGroup/Finder/Buttons")]
        void SearchFolder() {
            if (string.IsNullOrEmpty(FolderName)) 
                return;
            
            var path = FileHelper.FindFolder(CoreFolderName, FolderName);
            if (string.IsNullOrEmpty(path)) {
                Debug.LogError("Folder Name didn't contains in repository");
                return;
            }
            
            FolderName = string.Empty;

            if (PathList.Contains(path)) {
                Debug.LogWarning("Folder exist in importer array");
                return;
            }
            
            PathList = PathList.Add(path);
        }
    }
*/