using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AldacoUtilities{

	public class Rotator : MonoBehaviour {

		public Vector3 axis = new Vector3(0f,0f,-25f);
		public Space rotationSpace = Space.World;

		void FixedUpdate(){
			transform.Rotate (axis * Time.deltaTime,rotationSpace);
		}

	}
}

