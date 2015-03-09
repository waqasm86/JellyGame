using UnityEngine;
using System.Collections;

public class SetScores : MonoBehaviour {

    public static int scores;
    private int lastscores =0;
    UILabel uilabel;
	// Use this for initialization
	void Start () {
        uilabel = this.GetComponent<UILabel>();
        uilabel.text = "Scores:" + "    0";
	}
	
	// Update is called once per frame
	void Update () {
	    if(lastscores!=scores){
            uilabel.text = "Scores: " + scores;
        }
	}
}
