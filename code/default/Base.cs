using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution (Screen.width ,  (int)(Screen.width * 4.0 /3) , true);
		Debug.Log ((float)Screen.width / Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
