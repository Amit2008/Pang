using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pang
{
    /// <summary>
    /// This class represents the view for the gameplay menu and provides methods to set the view's properties.
    /// </summary>
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI popupTitle;

        /// <summary>
        /// Sets the view's title text.
        /// </summary>
        /// <param name="title">The title to be displayed in the view.</param>
        public void SetView(string title)
        {
            popupTitle.text = title;
        }
    }
}

