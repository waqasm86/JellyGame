using UnityEngine;
using System.Collections;

public class ItemCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            SetScores.scores += 100;
            Destroy(GameObject.Find("background1/addgrade"));
            Destroy(GameObject.Find("background2/addgrade"));
            Destroy(GameObject.Find("background3/addgrade"));
            Destroy(GameObject.Find("background4/addgrade"));
         //   Destroy(this.gameObject, 0.5f);
        }
    }
}
