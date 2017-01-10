using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

	public Sprite[] img;
	int flag;
	int index = 0;

	// Use this for initialization
	void Start () {
		index = 0;
		flag = 999;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (flag < 10) {

			if(index < img.Length )
				this.transform.GetComponent<SpriteRenderer> ().sprite = img [(index++) % img.Length];

			else
				flag = Random.Range (10, 1000);



		} else {
			flag = Random.Range (0, 1000);
			index = 0;
		}
	}
}
