using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;
using UnityEngine.SceneManagement;

public class BlockEvent : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnMouseDown()
	{
		/*
		int n = Map.instance.size;

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				Debug.Log (i + " " + j + " : " +Map.instance.get (i, j).OnObject + " // " + Map.instance.get(i, j).index);
				*/
	}

	void OnMouseUp()
	{
		/*
		Resource.stage++;
		MapObject.ALLOBJECT.Clear ();
		Accessory.accessory.Clear ();
		Character.characters.Clear();
		SceneManager.LoadScene ("Main");
		*/

		//makeMap.clearEvent ();

		//Resource.clear();
		//Resource.stage = 5;
		//SceneManager.LoadScene ("p2");

		if (!this.transform.GetComponent<SpriteRenderer> ().color.Equals (new Color (1, 1, 1, 1))) {

			Color color = this.transform.GetComponent<SpriteRenderer> ().color;

			foreach (Character c in Character.characters)
				if (c.Color.Equals (color)) {
					c.toStartPoint ();
				}
		}
	}

}
