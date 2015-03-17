using UnityEngine;
using System.Collections;


public class Collider0 : MonoBehaviour {

	void Start () {	
	}
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		int temp = Colliders.getCurrentMap();
		Colliders.SetCurrentMap(0);
		Colliders.SetLastMap (temp);
	}
}
