using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AldacoUtilities{

	public delegate void LerpMethod();
	public delegate float DistanceMethod();

	public class TweenAbstract : MonoBehaviour{

		public virtual void Move(){
			Debug.Log ("Executing from abstract class");
		}

		public virtual void SetOnPointA(){

		}

		public virtual void SetOnPointB(){

		}

	}

	public class TweenBase<T,POINTSTYPE> : TweenAbstract
	{

		[Header("Target Values")]
		public T animationTarget;
		public AnimationCurve animationCurve = AnimationCurve.Linear(0f,0f,1f,1f);
		[Space]
		public POINTSTYPE pointA;
		public POINTSTYPE pointB;

		[Space(10)]
		[Header("Events", order = 5)]
		public TweenEvents tweenEvents;

		protected bool isActive = false;
		protected float animationTimer = 0f;
		protected float sideMultiplier = 1f;
		protected float maxTime = 0f;

		#region UNITY_METHODS
		protected virtual void Start(){

			maxTime = animationCurve.keys [animationCurve.length - 1].time;

			if (pointA == null)
				SetStartPointToTargetPoint ();
		}

		protected virtual void FixedUpdate(){
			UpdateValue ();
		}
		#endregion


		#region MUST_BE_OVERRIDEN_BY_DESCENDANTS

		public virtual void SetStartPointToTargetPoint(){

		}

		protected virtual void LerpValues(){

		}

		protected virtual void Reset(){
			isActive = false;
			animationTimer = 0f;
			sideMultiplier = 1f;
		}

		public override void SetOnPointA(){
			isActive = false;
			animationTimer = 0f;
			sideMultiplier = 1f;
		}

		public override void SetOnPointB(){
			isActive = false;
			animationTimer = maxTime;
			sideMultiplier = -1f;
		}

		public virtual void ChangePointA(POINTSTYPE newPointA){

		}

		public virtual void ChangePointB(POINTSTYPE newPointB){

		}

		public virtual void Pause(){
			if (isActive)
				isActive = false;
		}

		public virtual void UnPause(){
			if (!isActive) {
				isActive = true;
			}
		}

		#endregion

		public override void Move(){
			tweenEvents.OnActivate.Invoke ();
			if (!isActive)
				isActive = true;
			else
				sideMultiplier *= -1f;
		}

		public virtual void UpdateValue(){

			if (!isActive)
				return;

			animationTimer = Mathf.Clamp(animationTimer + (Time.deltaTime * sideMultiplier),0f,maxTime);
			LerpValues ();

			tweenEvents.OnUpdateValue.Invoke ();

			if (animationTimer >= maxTime) {
				isActive = false;
				sideMultiplier *= -1f;
				OnReachB ();
			} else if(animationTimer <= 0f){
				isActive = false;
				OnReachA ();
				sideMultiplier *= -1f;
			}
		}

		#region EVENT_TRIGGERING
		public virtual void OnReachA(){
			tweenEvents.OnReachA.Invoke ();
			tweenEvents.OnReachAnyPoint.Invoke ();
		}

		public virtual void OnReachB(){
			tweenEvents.OnReachB.Invoke ();
			tweenEvents.OnReachAnyPoint.Invoke ();
		}
		#endregion

	}

	[System.Serializable]
	public struct TweenEvents{

		public UnityEvent OnActivate;
		public UnityEvent OnReachA;
		public UnityEvent OnReachB;
		public UnityEvent OnReachAnyPoint;
		public UnityEvent OnUpdateValue;

	}

}

