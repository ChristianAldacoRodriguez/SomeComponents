using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AldacoUtilities{
	public class Toast : MonoBehaviour {

		public TextMeshProUGUI textComponent;
		public TweenGroup tweenGroup;

		void Start(){
			DontDestroyOnLoad (gameObject);
		}

		public void Show(){
			tweenGroup.Move ();
		}

		public void Show(string text){
			textComponent.text = text;
			tweenGroup.Move ();
		}

		/// <summary>
		/// Callback used in the tween position component;
		/// </summary>
		public void DestroyThis(){
			GameObject.DestroyImmediate (gameObject);
		}

		public void Reset(){
			tweenGroup.SetOnPointA ();
		}


	}

}