using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AldacoUtilities{
	public class HotSpotFactory : MonoBehaviourSingleton<HotSpotFactory> {

		public List<HotSpot> hotSpots;
		public Dictionary<string, HotSpot> hotSpotsDictionary = new Dictionary<string, HotSpot> ();

		void Start(){
			hotSpots.ForEach ( (element) =>{
				hotSpotsDictionary.Add(element.id, element);
			});
		}

		public GameObject GenerateHotSpot(string hotSpotId,Vector3 referencePosition, Vector3 centerPosition, Transform hotSpotsParent, float distanceFromCenter, bool disableVerticalRotation = true){
			GameObject hotSpotPrefab = (hotSpotsDictionary.ContainsKey (hotSpotId)) ? hotSpotsDictionary [hotSpotId].prefab : null;
			if (hotSpotPrefab == null) {
				return null;
			}

			Quaternion viewDirection = Quaternion.LookRotation (referencePosition - centerPosition);

			GameObject nHotspot = Instantiate (hotSpotPrefab,Vector3.zero, viewDirection, hotSpotsParent) as GameObject;
			nHotspot.transform.Translate ((Vector3.forward) * distanceFromCenter,Space.Self);

			if (disableVerticalRotation) {
				Vector3 tmpEuler = viewDirection.eulerAngles;
				tmpEuler.x = 0f;
				nHotspot.transform.eulerAngles = tmpEuler;
			}

			return nHotspot;

		}

	}

	[System.Serializable]
	public class HotSpot{
		public string id = "";
		public HotSpotType hotSpotType = HotSpotType.INFO;
		public GameObject prefab;
	}

	public enum HotSpotType{
		INFO = 0,
		NAVEGATION = 1,
		DECORATOR = 2,
		FICHA = 3

	}
}

