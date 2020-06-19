using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AldacoUtilities{

	public class GameObjectCommonEventsHandler : MonoBehaviour {

		public UnityEvent OnEnableHandler;
		public UnityEvent OnDisableHandler;
		public UnityEvent OnDestroyHanlder;

		public void OnEnable(){
			OnEnableHandler.Invoke ();
		}

		public void OnDisable(){
			OnDisableHandler.Invoke ();
		}

		public void OnDestroy(){
			OnDestroyHanlder.Invoke ();
		}

	}

}

