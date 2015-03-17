using UnityEngine;
using System.Collections;


public class Collider3 : MonoBehaviour {
	
	void Start () {	
	}
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		print ("1111");
		int temp = Colliders.getCurrentMap();
		Colliders.SetCurrentMap (3);
		Colliders.SetLastMap (temp);
	}
}
