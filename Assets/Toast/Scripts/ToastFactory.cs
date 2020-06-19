using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AldacoUtilities{
	public class ToastFactory : MonoBehaviourSingletonDDOL<ToastFactory>{

		public GameObject toastPrefab;
		private Toast currentToast = null;

		public void ShowToast(string text){

			if (currentToast == null) {
				if (toastPrefab == null)
					return;
				
				currentToast = GameObject.Instantiate (toastPrefab).GetComponent<Toast> ();
			} else {
				currentToast.Reset ();

			}

			currentToast.Show (text);

		}

		IEnumerator Start(){
			ResourceRequest rq = Resources.LoadAsync ("Toast/Canvas Toast");
			yield return rq;

			toastPrefab = rq.asset as GameObject;
		}

	}
}

