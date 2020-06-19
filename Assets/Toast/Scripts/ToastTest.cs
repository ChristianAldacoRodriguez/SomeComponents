using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AldacoUtilities;

public class ToastTest : MonoBehaviour {

	public ToastFactory factory;

	// Use this for initialization
	void Start () {
		factory = ToastFactory.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
