using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AldacoUtilities{
	public class TweenGroup : MonoBehaviour {

		public TweenAbstract[] tweenScripts;

		[ContextMenu("Move Group")]
		public void Move(){
			foreach (TweenAbstract tscript in tweenScripts) {
				tscript.Move ();
			}
		}

		public void SetOnPointA(){
			foreach (TweenAbstract tscript in tweenScripts) {
				tscript.SetOnPointA ();
			}
		}

		public void SetOnPointB(){
			foreach (TweenAbstract tscript in tweenScripts) {
				tscript.SetOnPointB ();
			}
		}

	}
}

