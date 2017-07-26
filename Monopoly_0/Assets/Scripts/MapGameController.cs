using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
public class MapGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeScene(string myscene){
		if (myscene == "main") {
			SceneManager.LoadScene ("main");
		}
		if (myscene == "map") {
			SceneManager.LoadScene ("map");
		}
	}
}
