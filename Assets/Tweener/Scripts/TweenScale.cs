using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AldacoUtilities{

	public class TweenScale : TweenBase<Transform, Transform> {

		#region MUST_BE_OVERRIDEN_BY_DESCENDANTS
		[ContextMenu("Set Start Point")]
		public override void SetStartPointToTargetPoint(){
			if (animationTarget == null) {
				Debug.Log ("There is no Animation target to automatically generate point A");
				return;
			}

			if (pointA == null) {
				GameObject gb = new GameObject (name + "-START_POS");
				pointA = gb.transform;

			}

			pointA.localScale = animationTarget.localScale;
		}

		protected override void LerpValues(){
			animationTarget.localScale = Vector3.Lerp(pointA.localScale, pointB.localScale, animationCurve.Evaluate(animationTimer));
		}

		public override void SetOnPointA(){
			base.SetOnPointA ();
			animationTarget.localScale = pointA.localScale;
		}

		public override void SetOnPointB(){
			base.SetOnPointB ();
			animationTarget.localScale = pointB.localScale;
		}

		public override void ChangePointA(Transform newPointA){
			pointA = newPointA;
		}

		public override void ChangePointB(Transform newPointB){
			pointB = newPointB;
		}

		#endregion

		[ContextMenu("Activate Movement")]
		public override void Move(){
			base.Move ();
		}
			
	}

}