using UnityEngine;
using System.Collections;

public class TimeCount : MonoBehaviour {
    private UISlider uislider;
    private UISprite slidersprite;
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
        //   print(uislider.ToString());
        print("aaaa");
    }

    // Update is called once per frame
    void Update()
    {
        if(uislider.value> 0)
            uislider.value -= 0.01f*Time.deltaTime;
        if (uislider.value < 0.6) {
            slidersprite.color = Color.yellow;
        }
        if (uislider.value < 0.2) {
            slidersprite.color = Color.red;
        }
    }
    
}
