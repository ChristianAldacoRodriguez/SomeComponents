using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AldacoUtilities{
	public class TweenCanvasGroup : TweenBase<CanvasGroup, float> {

		#region MUST_BE_OVERRIDEN_BY_DESCENDANTS
		[ContextMenu("Set Start Point")]
		public override void SetStartPointToTargetPoint(){
			if (animationTarget == null) {
				Debug.Log ("There is no Animation target to automatically generate point A");
				return;
			}

			pointA = animationTarget.alpha;
		}

		protected override void LerpValues(){
			animationTarget.alpha = Mathf.Lerp(pointA, pointB, animationCurve.Evaluate(animationTimer));
		}

		public override void SetOnPointA(){
			base.SetOnPointA ();
			animationTarget.alpha = pointA;
		}

		public override void SetOnPointB(){
			base.SetOnPointB ();
			animationTarget.alpha = pointB;
		}

		public override void ChangePointA(float newPointA){
			pointA = newPointA;
		}

		public override void ChangePointB(float newPointB){
			pointB = newPointB;
		}

		#endregion

		[ContextMenu("Activate Movement")]
		public override void Move(){
			base.Move ();
		}

	}

}

