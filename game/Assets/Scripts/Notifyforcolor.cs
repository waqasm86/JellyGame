using UnityEngine;
using System.Collections;

public class Notifyforcolor : MonoBehaviour {

    UISprite colorSprite;
	// Use this for initialization
	void Start () {
        colorSprite = GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ColorChangetoMuch(float used)
    {
        if (used > 10 && used < 20)
            colorSprite.spriteName = "大量fixed";
        else if (used < 10 && used > 0)
            colorSprite.spriteName = "少量fixed";
        else if (used == 0)
            colorSprite.spriteName = "空fixed";
    }
}
