using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {

    public LineRenderer lineRender;
    Vector3 beginposition,endposition,midposition;
    bool isclicked = false;
    BoxCollider2D boxcollider2D;
    public Transform prefab,prefab1,parent;
    public Color[] linecolor;
    public float[] colorUsed;
    public static int selectColorindex;
    public GameObject[] sendmsg;
    Transform tr;
    float singleUsed;
	// Use this for initialization
	void Start () {
        selectColorindex = 0;
        singleUsed = 0;
	}
    public static float InvSqrt(float x1,float x2,float y1,float y2)
    {
        float a = Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
        return a;
    }
	// Update is called once per frame
	void Update () {
        if (TimeCount.gameOver)
            return;
        if (colorUsed[selectColorindex] == 0)
            return;
        bool Mousedown = Input.GetMouseButton(0);
        if (Input.GetMouseButtonDown(0)&&!isclicked && rolecontroller.isrunning) {
            if(UICamera.hoveredObject !=null)
            {
                if(UICamera.hoveredObject.tag.Equals("SelectColor")||
                    UICamera.hoveredObject.tag.Equals("stopButton"))
                {
                    return;
                }
            }
            singleUsed = 0;
            Time.timeScale = 0.2f;
            beginposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 1));
            print(beginposition.ToString());
            isclicked = true;
            tr = (Transform)Instantiate(prefab, new Vector3(beginposition.x,beginposition.y,0),
                Quaternion.identity);
            tr.parent = parent;

            lineRender = tr.GetComponent<LineRenderer>();
            lineRender.material.color = linecolor[selectColorindex];
            lineRender.SetWidth(0.5f, 0.5f);
            lineRender.SetVertexCount(3);
            lineRender.SetPosition(0, new Vector3(beginposition.x,beginposition.y,-0.5f));
            
        }
        if (Mousedown && isclicked && rolecontroller.isrunning) {
            midposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                 Input.mousePosition.y, 1));
          //  lineRender.SetPosition(1, midposition);
          //  lineRender.SetPosition(2, beginposition);
            lineRender.SetPosition(1, new Vector3(midposition.x,midposition.y,-0.5f));
            lineRender.SetPosition(2, new Vector3(beginposition.x, beginposition.y, -0.5f));
            singleUsed = InvSqrt(midposition.x,beginposition.x,midposition.y,beginposition.y);
        }
        
        if (Input.GetMouseButtonUp(0)&&isclicked&&rolecontroller.isrunning) {
            isclicked = false;
            Mousedown = false;
            Time.timeScale = 1.0f;
            endposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 1));
            float angle = Mathf.Atan2((beginposition.y-endposition.y),(beginposition.x-endposition.x));
            float distance = Mathf.Sqrt(Mathf.Pow((beginposition.y - endposition.y), 2) + Mathf.Pow((beginposition.x - endposition.x), 2));
            Transform tr1 = (Transform)Instantiate(prefab1, (beginposition + endposition) / 2, Quaternion.AngleAxis(angle * 180 / 3.14f, Vector3.forward));
            boxcollider2D = tr1.GetComponent<BoxCollider2D>();
            boxcollider2D.size = new Vector2(distance, 0.2f);
            colorUsed[selectColorindex] -= singleUsed;
            if (colorUsed[selectColorindex] <= 0)
            {
                colorUsed[selectColorindex] = 0;
            }
            sendmsg[selectColorindex].SendMessage("ColorChangetoMuch", colorUsed[selectColorindex]);
        }
	}
}
