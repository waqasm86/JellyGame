using UnityEngine;
using System.Collections;

public class moveandscale : MonoBehaviour {
    public Vector3 corner;
    public Transform target;

    public Transform parent;
    public float distance = 10.0f;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float x = 0.0f;
    public float y = 0.0f;


    private float beginX;
    private float beginY;
    private float endX;
    private float endY;
   
    public Transform prefeb;
    Vector2 oldPosition1;
    Vector2 oldPosition2;
    [HideInInspector]
    int inputcount;
	// Use this for initialization

	void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        if (rigidbody)
            rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        inputcount = Input.touchCount;
        if (inputcount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved) {
                x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
                y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                print("end"+Input.GetTouch(0).position.ToString());
                endX = Input.GetTouch(0).position.x;
                endY = Input.GetTouch(0).position.y;
            //    Vector3 tv4 = UICamera.currentCamera.ScreenToViewportPoint(new Vector3(beginX,beginY,1));
                Vector3 tv = Camera.main.ScreenToWorldPoint(new Vector3(beginX,beginY,1));
                Vector3 tv2 = Camera.main.ScreenToWorldPoint(new Vector3(endX, endY, 1));
                Vector3 tv3 = Camera.main.ScreenToViewportPoint(new Vector3(beginX, beginY, 1));
          //      Vector3 tv4 = parent.localPosition;
                float angle = Mathf.Atan2((beginX - endX),(beginY-endY));
                print(tv);
                print(tv2);
                print(tv3);
            //    print("uicamera" + tv4.ToString());
             //   if(beginX<endX)
            /*    Vector3 tv5= new Vector3();
                Ray ray = UICamera.currentCamera.ScreenPointToRay(new Vector3(beginX,beginY,0));
                print(ray.ToString());
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                     tv5= parent.InverseTransformPoint(hit.point);
                     print("yes");
                }
                Vector3 tv6 = parent.TransformPoint(tv5);
                print("xiangdui " + tv5.ToString());
                print("juedui" + tv6.ToString());
            */
                print("parent" + parent.position.ToString());
                 Transform tr = (Transform)Instantiate(prefeb,tv3,Quaternion.AngleAxis(((angle)*180/3.14f),Vector3.forward));
                 tr.parent = parent;
                 tr.localPosition = new Vector3(beginX/Screen.width*782,beginY/Screen.height*320,0);
                tr.localScale= new Vector3(1, 1, 1 );
                //   else
                //    Instantiate(prefeb, tv3, Quaternion.AngleAxis(((angle) * 180 / 3.14f), Vector3.forward));
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Began){
                print("begin"+Input.GetTouch(0).position.ToString());
                
                beginX = Input.GetTouch(0).position.x;
                beginY = Input.GetTouch(0).position.y;
            }
        }
        else if(inputcount>1){
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {

                var tempPosition1 = Input.GetTouch(0).position;
                var tempPosition2 = Input.GetTouch(1).position;
                if (isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
                {
                    if (distance > 3)
                    {
                        distance -= 0.5f;
                    }
                }
                else
                {
                    if (distance < 18.5)
                    {
                        distance += 0.5f;
                    }
                }
                oldPosition1 = tempPosition1;
                oldPosition2 = tempPosition2;
            }
        }
	}
    bool isEnlarge(Vector2 oP1,Vector2 oP2,Vector2 nP1,Vector2 nP2)
    {
    var leng1 =Mathf.Sqrt((oP1.x-oP2.x)*(oP1.x-oP2.x)+(oP1.y-oP2.y)*(oP1.y-oP2.y));
    var leng2 =Mathf.Sqrt((nP1.x-nP2.x)*(nP1.x-nP2.x)+(nP1.y-nP2.y)*(nP1.y-nP2.y));
    if(leng1<leng2)
    {
         return true; 
    }else
    {
        return false; 
    }
    }
    void LateUpdate() {
        if (target)
        {
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            var rotation = Quaternion.Euler(y, x, 0);
            Vector3 tmp=new Vector3(0.0f,0.0f,-distance);
            var position = rotation * tmp + target.position;
            Vector3 worldpositiontl = UICamera.currentCamera.ViewportToScreenPoint(new Vector3(0, 1, distance));
            Vector3 worldpositionbl = UICamera.currentCamera.ViewportToScreenPoint(new Vector3(1, 1, distance));
            transform.rotation = rotation;
            transform.position = position;
         //   print(worldpositionbl.ToString());
        }
    }
    float ClampAngle(float angle,float min,float max) {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

}
