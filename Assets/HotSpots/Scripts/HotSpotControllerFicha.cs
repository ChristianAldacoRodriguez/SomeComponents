using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace AldacoUtilities{
	public class HotSpotControllerFicha : HotSpotController {

		public TextMeshProUGUI titleText;
		public Image thumbnailComponent;
		public TextMeshProUGUI descriptionText;

		[Header("Favoritos")]
		[SerializeField]
		private bool _isFavorite = false;
		public bool isFavorite{
			get{
				return _isFavorite;
			}

			set{
				_isFavorite = value;
				favoriteGameObject.SetActive (value);
			}
		}
		public GameObject favoriteGameObject;

		public override void SetData(Dictionary<string, object> data){
			titleText.text = data ["text"].ToString ();
			thumbnailComponent.sprite = data ["miniatura"] as Sprite;
			descriptionText.text =  int.Parse(data ["description"].ToString ()).ToString("N0");

		}

		public override void OnPress(){

		}

	}
}

