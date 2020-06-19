using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AldacoUtilities{

	public class TweenRotation : TweenBase<Transform, Transform> {

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

			pointA.rotation = animationTarget.rotation;
		}

		protected override void LerpValues(){
			animationTarget.rotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, animationCurve.Evaluate(animationTimer));
		}

		public override void SetOnPointA(){
			base.SetOnPointA ();
			animationTarget.rotation = pointA.rotation;
		}

		public override void SetOnPointB(){
			base.SetOnPointB ();
			animationTarget.rotation = pointB.rotation;
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

