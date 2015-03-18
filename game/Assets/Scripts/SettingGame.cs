using UnityEngine;
using System.Collections;

public class SettingGame : MonoBehaviour {


    public TweenPosition TpositionGameMenu;
    public TweenPosition TpositionGameOverMenu;
    public static bool onthebackground;
    public UIScrollBar scroll;
    public UIButton getmenuobj;
    public UIScrollView scrollview;
	// Use this for initialization
	void Start () {
        onthebackground = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void getmenu() {
        TpositionGameMenu.enabled = true;
      
        if(!onthebackground)
        {
            Time.timeScale = 0.0f;
            TpositionGameMenu.PlayForward();
            onthebackground = true;

        }
    }
    public void menuBack()
    {
        if (onthebackground)
        {
            TpositionGameMenu.PlayReverse();
            onthebackground = false;
            Time.timeScale = 1.0f;
        }
    }
    public void getOverMenu() 
    {
        TpositionGameOverMenu.enabled = true;
        Time.timeScale = 0.0f;
        TpositionGameOverMenu.PlayForward();
        getmenuobj.enabled = false;
        scrollview.enabled = false;
    }
    public void backtoMissionSelection() {
        Application.LoadLevel("MissionSelection");
    }
    public void replay() 
    {
        Application.LoadLevel("mission1-1");
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
