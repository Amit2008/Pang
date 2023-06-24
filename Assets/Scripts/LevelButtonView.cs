using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Pang
{
    /// <summary>
    /// This script is used to set the level button view.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelNameText;
        private Button _goToGameButton;
        private Action _buttonAction;
        
        private void Awake()
        {
            _goToGameButton = GetComponent<Button>();
            _goToGameButton.onClick.AddListener(OnLevelButtonClick);
        }

        public void SetLevelButtonView(string levelName, Action buttonAction) 
        {
            _levelNameText.text = levelName;
            _buttonAction = buttonAction;
        }

        private void OnLevelButtonClick() 
        {
            _buttonAction?.Invoke();
        }
    }
}
