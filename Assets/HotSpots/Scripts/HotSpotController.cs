using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace AldacoUtilities{
	public class HotSpotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

		public TweenGroup animationGroup;
		public string posicionJSON
		{
			get{
				return "{\"x\":\"" + transform.position.x + "\",\"y\":\""+transform.position.y + "\",\"z\":\""+transform.position.z + "\"}";
			}
		}
		//public bool enableAnimation = true;
		//public bool isOnScreen = false;

		#region IPointerEnterHandler implementation
		public void OnPointerEnter (PointerEventData eventData)
		{
			animationGroup.Move ();
		}
		#endregion

		#region IPointerExitHandler implementation

		public void OnPointerExit (PointerEventData eventData)
		{
			animationGroup.Move ();	
		}

		#endregion

		public virtual void SetData(Dictionary<string, object> data){

		}

		public virtual void OnPress(){

		}
	}
}