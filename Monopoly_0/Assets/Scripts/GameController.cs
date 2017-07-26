using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {

	// Use this for initialization

	public Text timer;

	public Text Total_Asset_digit;
	public Text Cash_digit;
	public Text Bank_digit;
	public Text Estate_digit;
	public Text Stock_digit;
	public Text Knife_digit;

	public int Total_Asset;
	public int Cash;
	public int Bank;
	public int Estate;
	public int Stock;
	public int Knife;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DateTime nowDateTime = DateTime.Now;
		timer.text = String.Format ("{0:D4}/{1:D2}/{2:D2} {3:D2}:{4:D2}:{5:D2}", nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, nowDateTime.Hour, nowDateTime.Minute, nowDateTime.Second);

		//time evolution
		Total_Asset = Cash + Bank + Estate + Stock;

		//print on the screen
		Total_Asset_digit.text = String.Format("{0:D}", Total_Asset);
		Cash_digit.text = String.Format ("{0:D}", Cash);
		Bank_digit.text = String.Format ("{0:D}", Bank);
		Estate_digit.text = String.Format("{0:D}", Estate);
		Stock_digit.text = String.Format("{0:D}", Stock);
		Knife_digit.text = String.Format("{0:D}", Knife);
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
