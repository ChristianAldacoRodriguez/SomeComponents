using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace AldacoUtilities{
	public class HotSpotControllerInfo : HotSpotController {

		public TextMeshProUGUI titleText;

		public override void SetData(Dictionary<string, object> data){
			titleText.text = data ["text"].ToString ();
		}

		public override void OnPress(){
			
		}

	}
}