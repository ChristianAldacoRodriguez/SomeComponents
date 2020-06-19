using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AldacoUtilities{
	public class PanoramaFilesLoader : MonoBehaviour {

		public static string[] panoramaFaceNameOrder = new string[]{
			"l_right",
			"l_left",
			"l_top",
			"l_bottom",
			"l_back",
			"l_front",
			"r_right",
			"r_left",
			"r_top",
			"r_bottom",
			"r_back",
			"r_front"
		};

		public enum FilesNameSearchMode
		{
			FaceName = 0,
			Numbers = 1
		}

		public enum ImageCreationMode
		{
			CopyPixels = 0,
			LoadFromBytes = 1
		}

		[Header("Configuration")]
		public string folderPath = "";
		public bool loadStereo = true;
		public FilesNameSearchMode filesSearchMode = FilesNameSearchMode.FaceName;
		[Tooltip("<b>CopyPixels Mode: </b>Slower. Can select TextureFormat.\n<b>LoadFromBytes: </b>Faster. TextureFormat gets automatically selected. Jpg=RGB24, Png=ARGB32")]
		public ImageCreationMode imageCreationMode = ImageCreationMode.CopyPixels;
		[Space]
		public RawImageConfig imageConfig = RawImageConfig.Default();
		[Space]
		public List<Texture2D> texturesLoaded = new List<Texture2D>();
		[Space]
		public UnityEngine.Events.UnityEvent OnTexturesLoaded;

		public Action OnTexturesFinishedLoad;
		public Action<List<Texture2D>> OnTexturesGetLoaded;

		private int loadLimit{
			get{
				return (loadStereo) ? 12 : 6;
			}
		}

		[ContextMenu("Load Images in Folder")]
		public void LoadImagesInFolder(){
			StartCoroutine (_LoadImagesInFolder());
		}

		public void LoadImagesInFolder(string _folderPath){
			folderPath = _folderPath;
			StartCoroutine (_LoadImagesInFolder());
		}

		public IEnumerator _LoadImagesInFolder(){
			yield return null;

			for (int i = 0; i < loadLimit; i++) {
				
				string filePath = (filesSearchMode == FilesNameSearchMode.FaceName) ? folderPath + panoramaFaceNameOrder[i] + ".jpg" : folderPath + (i + 1).ToString ("00") + ".jpg";

				WWW www = new WWW (@"file://" + filePath);
				yield return www;

				Texture2D nTex;

				if (imageCreationMode == ImageCreationMode.CopyPixels) {
					nTex = new Texture2D (www.texture.width,www.texture.height,imageConfig.textureFormat,imageConfig.enableMipMap);
					nTex.SetPixels (www.texture.GetPixels());
				} else {
					byte[] imgBytes = www.texture.EncodeToJPG();
					nTex = new Texture2D (2,2,imageConfig.textureFormat, imageConfig.enableMipMap);
					nTex.LoadImage (imgBytes);
					nTex.Apply (imageConfig.enableMipMap);
					imgBytes = null;

				}

				www.Dispose ();
				www = null;

				nTex.alphaIsTransparency = imageConfig.alphaIsTransparency;
				nTex.anisoLevel = imageConfig.anisoLevel;
				nTex.filterMode = imageConfig.filterMode;
				nTex.wrapMode = imageConfig.wrapMode;
				nTex.mipMapBias = imageConfig.mipMapLevel;


				nTex.Apply ();

				texturesLoaded.Add (nTex);

				Resources.UnloadUnusedAssets ();
			}
				
			yield return null;
			Resources.UnloadUnusedAssets ();
			System.GC.Collect ();

			OnTexturesLoaded.Invoke ();
			if (OnTexturesGetLoaded != null) {
				OnTexturesGetLoaded (texturesLoaded);
			}

			yield return null;
			Resources.UnloadUnusedAssets ();
			System.GC.Collect ();

		}

		[ContextMenu("Clear Memory")]
		public void ClearMemory(){
			StartCoroutine(_ClearMemory());
		}

		IEnumerator _ClearMemory(){
			texturesLoaded.Clear ();
			yield return new WaitForEndOfFrame ();
			Resources.UnloadUnusedAssets ();
			yield return new WaitForEndOfFrame ();
			System.GC.Collect ();
		}

	}

	[System.Serializable]
	public struct RawImageConfig{

		public int anisoLevel;
		public float mipMapLevel;

		public bool enableMipMap;
		public bool markAsNotReadable;
		public bool alphaIsTransparency;

		public TextureFormat textureFormat;
		public FilterMode filterMode;
		public TextureWrapMode wrapMode;


		public static RawImageConfig Default(){
			RawImageConfig res;
			res.anisoLevel = 1;
			res.mipMapLevel = 0f;

			res.enableMipMap = false;
			res.markAsNotReadable = false;
			res.alphaIsTransparency = false;

			res.textureFormat = TextureFormat.RGB24;
			res.filterMode = FilterMode.Point;
			res.wrapMode = TextureWrapMode.Clamp;

			return res;
		}

	}

}