using UnityEngine;
using System.Collections;

public class TimeCount : MonoBehaviour {
    private UISlider uislider;
    private UISprite slidersprite;
    public GameObject getOver;
    public static bool gameOver;
    void Awake()
    {
        print("aaa");
        uislider = this.transform.parent.Find("TimeCount").GetComponent<UISlider>();
        slidersprite = GameObject.Find("UI Root/TimeCount/Overlay").GetComponent<UISprite>();
        uislider.value = 1.0f;
    }
    // Use this for initialization
    void Start()
    {
        gameOver = false;
        //   print(uislider.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(uislider.value> 0)
            uislider.value -= 0.05f*Time.deltaTime;
        if (uislider.value <= 0)
            uislider.value = 0;
        if (uislider.value < 0.6) {
            slidersprite.color = Color.yellow;
        }
        if (uislider.value < 0.2) {
            slidersprite.color = Color.red;
        }
        if (uislider.value == 0)
        {
            gameOver = true;
            getOver.SendMessage("getOverMenu");
        }
       
    }
    
}
