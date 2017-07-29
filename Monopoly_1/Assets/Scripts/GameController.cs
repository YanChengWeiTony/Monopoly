using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;
using System;

public class GameController : MonoBehaviour {
	//prvate
	private Vector3 v1 = new Vector3 (0.29f, -0.68f, -6.244985f);
	private Vector3 v2 = new Vector3 (0.29f, 11f, -6.244985f);
	private Vector3 v3 = new Vector3 (0.29f, -12.36f, -6.244985f);

	//fundamental setting
	public int myname;
	public string ID;

	//others gameobject
	public Camera Cma;
	public Plane Pln_1;
	public Plane Pln_2;
	public Plane Pln_3;
	public GameObject others_display;
	public Image buyin_messenge_display;
	public Image sellout_messenge_display;

	//stocks
	public double[,] stock_inf;//1: slope, 2: price, 3: remain;
	public GameObject[] mystock;

	//text
	public Text Name;
	public Text Total_Asset_digit;
	public Text Cash_digit;
	public Text Bank_digit;
	public Text Estate_digit;
	public Text Stock_digit;
	public Text Knife_digit;
	public Text timer;

	//button
	public Button Back_others;
	public Button buyin_yes;
	public Button buyin_no;
	public Button sellout_yes;
	public Button sellout_no;

	//int
	public int Total_Asset;
	public int Cash;
	public int Bank;
	public int Estate;
	public int Stock;
	public int Knife;

	// Use this for initialization
	void Start () {
		Name.text = String.Format ("{0:D}", myname);
		ID = "1";
		stock_inf = new double[4, 7];
		stock_inf [1, 3] = 3.25;
		stock_inf [2, 4] = 4315;
	}
	
	// Update is called once per frame
	void Update () {
		//time evolution
		DateTime nowDateTime = DateTime.Now;
		timer.text = String.Format ("{0:D4}/{1:D2}/{2:D2} {3:D2}:{4:D2}:{5:D2}", nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, nowDateTime.Hour, nowDateTime.Minute, nowDateTime.Second);		

		Total_Asset = Cash + Bank + Estate + Stock;

		//url per 5 minutes

		//print on the screen
		Total_Asset_digit.text = String.Format("{0:D}", Total_Asset);
		Cash_digit.text = String.Format ("{0:D}", Cash);
		Bank_digit.text = String.Format ("{0:D}", Bank);
		Estate_digit.text = String.Format("{0:D}", Estate);
		Stock_digit.text = String.Format("{0:D}", Stock);
		Knife_digit.text = String.Format("{0:D}", Knife);

		for (int i = 1; i < mystock.Length; i++) {
			Text[] buffer = mystock [i].GetComponentsInChildren<Text> ();
			buffer [1].text = String.Format ("{0:F}%", stock_inf[1, i]);
			buffer [2].text = String.Format ("{0:F}", stock_inf[2, i]);
			buffer [3].text = String.Format ("{0:F}", stock_inf[3, i]);
		}
	}

	public void ChangePage(string ID){
		this.ID = ID;
	
		if (ID == "1") {
			Cma.transform.position = v1;
		}
		if (ID == "2") {
			Cma.transform.position = v2;
		}
		if (ID == "3") {
			Cma.transform.position = v3;
		}
	}

	public void See_others(int mode){
		//Consider all button;
		if(mode == 1){
			//on click
			others_display.gameObject.SetActive(true);
		
			Back_others.interactable = true;
		}
		if(mode == 2){
			//go back
			others_display.gameObject.SetActive(false);
		}
	}

	public void buyin_sellout(int mode){
		if (mode == 0) {
			buyin_messenge_display.gameObject.SetActive (false);
			sellout_messenge_display.gameObject.SetActive (false);
		}
		if (mode == 1) {
			buyin_messenge_display.gameObject.SetActive (true);
			sellout_messenge_display.gameObject.SetActive (false);

			buyin_yes.interactable = true;
			buyin_no.interactable = true;
		}
		if (mode == 2) {
			buyin_messenge_display.gameObject.SetActive (false);
			sellout_messenge_display.gameObject.SetActive (true);

			sellout_yes.interactable = true;
			sellout_no.interactable = true;
		}
	}
}
