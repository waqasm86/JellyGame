using UnityEngine;
using System.Collections;

public class BeginSceneBehavior : MonoBehaviour {


    public static bool hasvolume;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        hasvolume = true;
        audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadMissionSelect() {
        Application.LoadLevel("MissionSelection");
    
    }
    public void LoadMission1() {
        Application.LoadLevel("mission1-1");
    }
    public void ForbbidenVolume() {
        if (hasvolume)
        {
            hasvolume = false;
            audio.volume = 0;
        }
        else {
            hasvolume = true;
            audio.volume = 1;
        }

    }
}
