using UnityEngine;
using System.Collections;

public class rolecontroller : MonoBehaviour {
    public static  bool isrunning;
    public JellySprite m_jellysprite;
    public float pushForce = 100;
    public float shotForce = 2000;
    private int inputcount;
    private float beginX;
    private float beginY;
    private float endX;
    private float endY;
    bool isclicked;
    Vector3 beginposition;
    Vector3 endposition;
    bool initempanel;
	// Use this for initialization
	void Start () {
        isrunning = false;
        initempanel = false;
	}
	
	// Update is called once per frame
	void Update () {
        bool Mousedown = Input.GetMouseButton(0);
        if (UICamera.hoveredObject != null)
        {
            if (UICamera.hoveredObject.tag.Equals("SelectColor") ||
                UICamera.hoveredObject.tag.Equals("stopButton"))
            {
                initempanel = true;
                return;
            }
        }
        if (Input.GetMouseButtonUp(0)&&initempanel) 
        {
            initempanel = false;
        }
        if (Mousedown && !isclicked&&!isrunning && !initempanel)
        {
            Time.timeScale = 0.3f;
            beginposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 1));
            isclicked = true;
         
        }
        if (Input.GetMouseButtonUp(0)&&!isrunning&&isclicked)
        {
            isclicked = false;
            Time.timeScale = 1.0f;
            endposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 1));
            float angle = Mathf.Atan2((beginposition.y - endposition.y), (beginposition.x - endposition.x));
            Vector2 forceonrole = new Vector2(beginposition.x - endposition.x, beginposition.y - endposition.y);
            gameObject.rigidbody2D.AddForce(forceonrole.normalized*500);
            isrunning = true;
        }
		
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        rigidbody2D.AddForce(new Vector2(H*20,V*20));
        inputcount = Input.touchCount;
        if (!isrunning && inputcount == 1) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (collider.Raycast(ray,out hit, 10.0f))
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    beginX = Input.GetTouch(0).position.x;
                    beginY = Input.GetTouch(0).position.y;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    endX = Input.GetTouch(0).position.x;
                    endY = Input.GetTouch(0).position.y;
                    isrunning = true;
                    Vector2 tp = new Vector2((endX - beginX), (endY - beginY));
                    m_jellysprite.AddForce(tp.normalized * shotForce);
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    m_jellysprite.AddForce(new Vector2(0, pushForce));
                }
            }
        }
	}
}
