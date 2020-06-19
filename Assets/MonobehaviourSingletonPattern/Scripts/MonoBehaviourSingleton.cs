using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AldacoUtilities{
	public class MonoBehaviourSingleton<T> : MonoBehaviour {

		protected static T instance = default(T);

		public virtual void Awake(){
			if (instance != null) {
				DestroyImmediate (gameObject);
				return;
			}

			//DontDestroyOnLoad (gameObject);
			instance = GetComponent<T> ();

		}

		public static T GetInstance(){

			if (instance == null) {
				GameObject singleton = new GameObject (typeof(T).ToString(), new System.Type[]{typeof(T)});
				return singleton.GetComponent<T> ();
			}

			return instance;

		}

	}

}