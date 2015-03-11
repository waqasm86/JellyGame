using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {

    public LineRenderer lineRender;
    Vector3 beginposition,endposition,midposition;
    bool isclicked = false;
    BoxCollider2D boxcollider2D;
    public Transform prefab,prefab1,parent;
    public Color linecolor;
    Transform tr;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool Mousedown = Input.GetMouseButton(0);
        if (Input.GetMouseButtonDown(0)&&!isclicked && rolecontroller.isrunning) {
            Time.timeScale = 0.2f;
            beginposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 1));
            print(beginposition.ToString());
            isclicked = true;
            tr = (Transform)Instantiate(prefab, new Vector3(beginposition.x,beginposition.y,0),
                Quaternion.identity);
            tr.parent = parent;

            lineRender = tr.GetComponent<LineRenderer>();
            lineRender.material.color = linecolor;
            lineRender.SetWidth(0.1f, 0.1f);
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
            
        }
	}
}
