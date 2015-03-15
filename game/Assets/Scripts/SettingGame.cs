using UnityEngine;
using System.Collections;

public class SettingGame : MonoBehaviour {


    public TweenPosition Tposition;
    public static bool onthebackground;
    public UIScrollBar scroll;
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
    public void setSelectedItem()
    {
        //        print(scroll.value);
        if (scroll.value == 1)
        {
            MouseMove.selectColorindex = 0;
        }
        else if (scroll.value < 0.9f && scroll.value > 0.6f)
        {
            MouseMove.selectColorindex = 1;
        }
        else if (scroll.value < 0.6f && scroll.value > 0.4f)
        {
            MouseMove.selectColorindex = 2;
        }
        else if (scroll.value < 0.4f && scroll.value > 0.2f)
        {
            MouseMove.selectColorindex = 3;
        }
        else if (scroll.value == 0)
        {
            MouseMove.selectColorindex = 4;
        }
    }
}
