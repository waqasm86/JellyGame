using UnityEngine;
using System.Collections;

public class ColCollider1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject b = col.gameObject;
            if (b.rigidbody2D.velocity.x> 0)
            {
                MapMove.notify = 4;
            }
            else
            {
                MapMove.notify = 3;
            }
        }
    }
}
