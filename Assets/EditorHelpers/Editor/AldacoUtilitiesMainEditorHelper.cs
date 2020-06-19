using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AldacoUtilitiesMainEditorHelper : Editor {


	[MenuItem("Utilities/Clear Player Prefs")]
	public static void ClearPlayerPrefs(){
		Debug.Log ("Clear");
	}


}
