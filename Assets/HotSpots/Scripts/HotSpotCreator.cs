using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AldacoUtilities{
	public class HotSpotCreator : MonoBehaviour {

		[Header("Controller")]
		public bool canCreate = true;
		public float distanceFromCenter = 500f;
		public bool disableVerticalRotation = true;
		public bool disableCreationOverUI = true;

		[Header("References")]
		public Camera eventCamera;
		public Transform centerTransform;
		public Transform hotSpotsParent;

		public List<GameObject> hotspotsList = new List<GameObject>();

		void Update(){
			if (canCreate) {
				if (Input.GetMouseButtonDown (0)) {
					if (disableCreationOverUI && !EventSystem.current.IsPointerOverGameObject ()) {
						Vector3 worldPos = eventCamera.ScreenToWorldPoint (Input.mousePosition + (Vector3.forward * distanceFromCenter));
						GenerateHotSpot (worldPos);
					}
				}
			}
		}


		public void GenerateHotSpot(Vector3 referencePosition){

			GameObject nHotSpot = HotSpotFactory.GetInstance ().GenerateHotSpot ("FICHA",referencePosition, centerTransform.position,hotSpotsParent,distanceFromCenter,disableVerticalRotation);
			hotspotsList.Add (nHotSpot);
			HotSpotController controller = nHotSpot.GetComponent<HotSpotController> ();
			Dictionary<string, object> data = new Dictionary<string, object> () {
				{"text","texto demo"},
				{"miniatura",null},
				{"description",25000}
			};
			controller.SetData (data);
		}

		[ContextMenu("Clear HotSpots")]
		public void ClearHotSpots(){
			hotspotsList.ForEach ((e)=>{
				Destroy(e);
			});
			hotspotsList.Clear ();
			Resources.UnloadUnusedAssets ();
		}

	}
}
