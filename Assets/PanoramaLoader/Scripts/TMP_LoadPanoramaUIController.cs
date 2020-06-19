using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AldacoUtilities;

public class TMP_LoadPanoramaUIController : MonoBehaviour {

	public string folderPath = "";
	public PanoramaFilesLoader loader;


	public GameObject panoramaPrefab;
	public PanoramaController currentPanorama;

	void Start(){
		loader.OnTexturesGetLoaded = this.OnPanoramaFinishLoadImages;
	}

	[ContextMenu("Instantiate Panorama Cube")]
	public void InstantiatePanoramaCube(){
		currentPanorama = GameObject.Instantiate (panoramaPrefab).GetComponent<PanoramaController>();
	}

	[ContextMenu("Load Panorama")]
	public void LoadPanorama(){
		currentPanorama = GameObject.Instantiate (panoramaPrefab).GetComponent<PanoramaController>();
		loader.LoadImagesInFolder (folderPath);
	}

	public void OnPanoramaFinishLoadImages(List<Texture2D> faces){
		currentPanorama.SetFacesImages (faces);
		currentPanorama.Show ();
	}

}
