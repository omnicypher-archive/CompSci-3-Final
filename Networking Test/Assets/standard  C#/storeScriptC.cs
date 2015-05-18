﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class storeScriptC : MonoBehaviour {
	public Menu store;
	public int money;
	public int hoverCost = 10;
	public int crabCost = 20;
	public int virusCost = 30;
	public bool heroUpdate;
	public bool zeroUpdate;
	Text cashReady;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void StorePurchaseC (int whichItem) {
		if (store.IsOpen) {
			cashReady = GameObject.FindWithTag ("money").GetComponent<Text>();

			if (Network.isClient) {
				money = int.Parse (cashReady.text);
					//insert money qualifications here
				if (whichItem == 1 && money >= hoverCost) {
					money-=hoverCost;
					GameObject.FindWithTag ("money").GetComponent<Text>().text = (money.ToString ());
						GameObject.FindWithTag ("stuffScript").GetComponent <stuff> ().spawnEnemys (1, 1);
				} else if (whichItem == 2 && money >= crabCost) {
					money -= crabCost;
					GameObject.FindWithTag ("money").GetComponent<Text>().text = (money.ToString ());
						GameObject.FindWithTag ("stuffScript").GetComponent <stuff> ().spawnEnemys (2, 1);
				} else if (whichItem == 3 && money >= virusCost) {
					money -= virusCost;
					GameObject.FindWithTag ("money").GetComponent<Text>().text = (money.ToString ());
						GameObject.FindWithTag ("stuffScript").GetComponent <stuff> ().spawnEnemys (3, 1);
				} 
			} else if (Network.isServer) {
				money = int.Parse (cashReady.text);
				if (whichItem == 1 && money >= hoverCost) {
					money -= hoverCost;
					GameObject.FindWithTag ("money").GetComponent<Text>().text = (money.ToString ());
						GameObject.FindWithTag ("stuffScript").GetComponent <stuff> ().spawnEnemys (1, 2);
				} else if (whichItem == 2 && money >= crabCost) {
					money -= crabCost;
					GameObject.FindWithTag ("money").GetComponent<Text>().text = (money.ToString ());
						GameObject.FindWithTag ("stuffScript").GetComponent <stuff> ().spawnEnemys (2, 2);
				} else if (whichItem == 3  && money >= virusCost) {
					money -= virusCost;
					GameObject.FindWithTag ("money").GetComponent<Text>().text = (money.ToString ());
						GameObject.FindWithTag ("stuffScript").GetComponent <stuff> ().spawnEnemys (2, 3);
				} 
			}

		}
	}
}
	
