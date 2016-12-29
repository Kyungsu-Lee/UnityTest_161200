using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public GameObject camera;

	// Use this for initialization
	void Start () {
		//Screen.SetResolution (Screen.width ,  (int)(Screen.width * 4.0 /3) , true);

		this.transform.GetComponent<Transform> ().position = new Vector3 (this.transform.GetComponent<Transform> ().position.x, this.transform.GetComponent<Transform> ().position.y, this.transform.GetComponent<Transform> ().position.z * 2f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
