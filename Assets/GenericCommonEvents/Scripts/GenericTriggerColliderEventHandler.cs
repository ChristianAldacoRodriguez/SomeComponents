using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace AldacoUtilities
{
    public class GenericTriggerColliderEventHandler : MonoBehaviour
    {
        public List<string> tagsToCompare;
        public UnityEvent OnTriggerEnterUnityEvent;
        public UnityEvent OnTriggerExitUnityEvent;
        public GameObject currentObject;

        public void OnTriggerEnter(Collider other)
        {
            bool taggedObject = false;
            tagsToCompare.ForEach((tag) => {
                if (other.CompareTag(tag))
                {
                    taggedObject = true;
                }
            });

            if (taggedObject)
            {
                OnTriggerEnterUnityEvent.Invoke();
            }

        }

		public void OnTriggerExit(Collider other){
			bool taggedObject = false;
			tagsToCompare.ForEach((tag) => {
				if (other.CompareTag(tag))
				{
					taggedObject = true;
				}
			});

			if (taggedObject)
			{
				OnTriggerExitUnityEvent.Invoke();
			}
		}


    }
}


