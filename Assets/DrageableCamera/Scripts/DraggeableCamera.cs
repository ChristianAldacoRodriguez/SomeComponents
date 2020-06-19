using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AldacoUtilities{
	public class DraggeableCamera : MonoBehaviour {

		public Transform cameraTransform;
		public float dragSpeed = 5f;
		public bool invertHorizontalDrag = false;
		public bool invertVerticalDrag = false;

		public int horizontalFactor{
			get{
				return (invertHorizontalDrag)? -1 : 1;
			}
		}

		public int verticalFactor{
			get{
				return (invertVerticalDrag)? -1 : 1;
			}
		}

		public float maxVerticalAngle = 60f;
		public float verticalDeceleration = 10f;
		public float horizontalDeceleration = 5f;


		private float verticalRotation = 0f;
		private float verticalVelocity = 0f;
		private float horizontalVelocity = 0f;

		private bool press = false;

		void Update(){

			Vector3 angle = Vector3.zero;

			#if UNITY_EDITOR

			if(Input.GetMouseButton(0)){
				verticalVelocity = Input.GetAxis ("Mouse Y") * dragSpeed * Time.deltaTime * verticalFactor;
				horizontalVelocity = Input.GetAxis ("Mouse X") * dragSpeed * Time.deltaTime * horizontalFactor;
			}else{
				horizontalVelocity = Mathf.Lerp (horizontalVelocity, 0f, Time.deltaTime * horizontalDeceleration);
				verticalVelocity = Mathf.Lerp (verticalVelocity, 0f, Time.deltaTime * verticalDeceleration);
			}
			#elif UNITY_ANDROID

			if(Input.touchCount == 1){
			verticalVelocity = Input.GetTouch(0).deltaPosition.y * dragSpeed * Time.deltaTime * verticalFactor;
			horizontalVelocity = Input.GetTouch(0).deltaPosition.x * dragSpeed * Time.deltaTime * horizontalFactor;
			}else{
			horizontalVelocity = Mathf.Lerp (horizontalVelocity, 0f, Time.deltaTime * horizontalDeceleration);
			verticalVelocity = Mathf.Lerp (verticalVelocity, 0f, Time.deltaTime * verticalDeceleration);
			}

			#endif


			//Vertical Drag
			angle = Vector3.right * verticalVelocity;
			verticalRotation = Mathf.Clamp (verticalRotation + angle.x, -maxVerticalAngle, maxVerticalAngle);
			if (verticalRotation < maxVerticalAngle && verticalRotation > -maxVerticalAngle)
				cameraTransform.Rotate (angle, Space.Self);

			//Horizontal Drag
			angle = Vector3.up * horizontalVelocity;
			cameraTransform.Rotate (angle, Space.World);

		}

	}

}

