using UnityEngine;
using System.Collections;
using ObjectHierachy;

public class Move : MonoBehaviour {

	int x = 0, y = 0;
	Character character;
	bool click = false;
	public GameObject circle;

	// Use this for initialization
	void Start () {
		character = new Character (circle.transform);
		character.connectMap (Map.instance);
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	public void move()
	{

		int _x = x;
		int _y = y;


			if (Input.GetKeyDown (KeyCode.A)) {
				x--;
			click = true;
			}

			else if (Input.GetKeyDown (KeyCode.W)) {
				y++;
				click = true;
			} else if (Input.GetKeyDown (KeyCode.S)) {
				y--;
				click = true;
			} else if (Input.GetKeyDown (KeyCode.D)) {
				x++;
				click = true;
			}

		if (!Map.instance.checkBound (x, y)) {
			x = _x;
			y = _y;
			click = false;
		}

			if (click) {
			character.locateAt (x,y);
			Map.instance.get (x, y).changColor ();
				click = false;
			}

	}
}
