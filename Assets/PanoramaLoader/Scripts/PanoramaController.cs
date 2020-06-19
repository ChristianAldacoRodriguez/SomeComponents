using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace AldacoUtilities{
	public class PanoramaController : MonoBehaviour {

		public TweenCanvasGroup leftCanvasTweener;
		public TweenCanvasGroup rightCanvasTweener;
		public bool isVisible = false;
		[Tooltip("Correct Order 01-06: Right, Left, Top, Bottom, Back, Front")]
		public RawImage[] leftEyeFaces;
		[Tooltip("Correct Order 01-06: Right, Left, Top, Bottom, Back, Front")]
		public RawImage[] rightEyeFaces;


		[ContextMenu("Show Panorama")]
		public void Show(){
			if (isVisible)
				return;

			leftCanvasTweener.Move ();
			rightCanvasTweener.Move ();
		}

		[ContextMenu("Hide Panorama")]
		public void Hide(){
			if (!isVisible)
				return;

			leftCanvasTweener.Move ();
			rightCanvasTweener.Move ();
		}

		public void SetFacesImages(List<Texture2D> fullArray){

			for (int i = 0; i < 6; i++) {
				leftEyeFaces [i].texture = fullArray [i];
			}

			for (int i = 6; i < 12; i++) {
				rightEyeFaces [i-6].texture = fullArray [i];
			}

		}

	}
}

