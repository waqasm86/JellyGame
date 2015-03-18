using UnityEngine;
using System.Collections;


public class Collider4 : MonoBehaviour {
	
	void Start () {	
	}
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		int temp = Colliders.getCurrentMap();
		Colliders.SetCurrentMap (4);
		Colliders.SetLastMap (temp);
        print(1111111111111111+temp);
	}
}
