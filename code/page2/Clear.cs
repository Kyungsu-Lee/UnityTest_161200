using UnityEngine;
using System.Collections;
using System;
using Instruction;
using FileHelper;

public class Clear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		for (Resource.stage = 300; Resource.stage <= 600; Resource.stage += 100) {
			string str = FileStreamHelper.readStringFromFile ("stage" + (Resource.stage / 100) * 100 + ".txt");


			string[] stages = str.Split (new char[]{ ',' });

			for (int i = 0; i < stages.Length; i++)
				stages [i] = "0";

			string s = "";
			for (int i = 0; i < 12; i++)
				s += stages [i] + ",";

			FileStreamHelper.writeStringToFile (s, "stage" + (Resource.stage / 100) * 100 + ".txt");
		}
	}
}
