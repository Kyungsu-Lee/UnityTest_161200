using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;
using UnityEngine.SceneManagement;
using System.IO;

public class RingEvent : MonoBehaviour {

	float time = 0;
	public Sprite[] unclear;
	public Sprite[] clear;

	// Use this for initialization
	void Start () {
		this.transform.GetComponent<SpriteRenderer> ().sprite = unclear [Resource.stage % 100];
	}
	
	// Update is called once per frame
	void Update () {


		foreach (Character c in Character.characters)
			if (c == null)
				Debug.Log ("a");

		float rate = Character.clearedCharacter / (float)(Character.Count);

		int n = Map.instance.size;
		bool flag = true;

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				flag &= !Map.instance.get (i, j).color.Equals (new Color (1, 1, 1, 1));


		if (rate == 1 && flag) {
			if (time < 3)
				time += Time.deltaTime;
			else if (time < 4) {
				time += Time.deltaTime;
				this.transform.GetComponent<SpriteRenderer> ().sprite = clear [Resource.stage % 100];

			} else {
				time = 0;
				TextAsset data = Resources.Load ("stage" + (Resource.stage / 100) * 100, typeof(TextAsset)) as TextAsset;
				StringReader str = new StringReader (data.text);

				string line;

				string[] stages = new string[100];
				int idx = 0;

				while ((line = str.ReadLine ()) != null) {
					stages [idx++] = (line);
				}

				stages [Resource.stage % 12] = "1";

				string s = "";
				for (int i = 0; i < 12; i++)
					s += stages [i] + "\n";

				File.WriteAllText ("Assets/Resources/stage" + (Resource.stage / 100) * 100 + ".txt", s);

				for (int i = 0; i < 12; i++)
					Debug.Log (s);

				if (Resource.stage % 100 <= 12) {
					Resource.stage++;
					MapObject.ALLOBJECT.Clear ();
					Accessory.accessory.Clear ();
					Character.characters.Clear ();
					SceneManager.LoadScene ("Main");
				}
			}
			}
	}

	void OnMouseUp()
	{
	}
}
