using UnityEngine;
using System.Collections;

public class SettingGame : MonoBehaviour {


    public TweenPosition Tposition;
    public static bool onthebackground;
	// Use this for initialization
	void Start () {
        onthebackground = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void getmenu() {
        Tposition.enabled = true;
        if (onthebackground)
        {
            Tposition.PlayReverse();
            onthebackground = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
            Tposition.PlayForward();
            onthebackground = true;

        }
    }
    public void backtoMissionSelection() {
        Application.LoadLevel("MissionSelection");
    }
}
