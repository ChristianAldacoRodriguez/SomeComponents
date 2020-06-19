using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AldacoUtilities
{
	public class SpinerScreen : MonoBehaviourSingletonDDOL<SpinerScreen>
    {
		
		public TweenGroup loadingScreen;
        public bool isOnScreen = false;
        [Header("CSA")]
        public TextMeshProUGUI loadingText;

        public static void Show()
        {
            if (instance != null)
                instance.ShowLoadingScreen();
        }

        public static void Show(string text)
        {
            if (instance != null)
            {
                instance.SetLoadingText(text);
                instance.ShowLoadingScreen();
            }
        }

        public static void Hide()
        {
            if(instance != null)
                instance.HideLoadingScreen();
        }

        public void SetLoadingText(string text)
        {
            loadingText.text = text;
        }

		[ContextMenu("Show")]
        public void ShowLoadingScreen()
        {
            if (isOnScreen)
                return;

            loadingScreen.Move();
            isOnScreen = true;

        }

		[ContextMenu("Hide")]
        public void HideLoadingScreen()
        {
            if (!isOnScreen)
                return;

            loadingScreen.Move();
            isOnScreen = false;

        }

    }

}

