using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pang
{
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI popupTitle;

        public void SetView(string title) 
        {
            popupTitle.text = title;
        }
    }
}
