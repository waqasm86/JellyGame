using UnityEngine;
using System.Collections;

public class MapMoveByLHX : MonoBehaviour {
    public GameObject[] maps;
    public GameObject role;
    public static int notify= 0 ;
    private int lastnotify = 0;
    public Camera camera;
    Rect cameraRect;
    Vector3 cemerasize;
    Vector3 rootmap;
    Vector3 roleposition;
    Vector3 roleViewportPosition;

    void Awake() {
        role = GameObject.FindGameObjectWithTag("Player");

    }
	// Use this for initialization
	void Start () {
        cameraRect = camera.pixelRect;
       // print(v.xMin + "," + v.xMax + "," + v.yMin + "," + v.yMax);
        cemerasize= Camera.main.ScreenToWorldPoint(new Vector3(cameraRect.xMax,cameraRect.yMax, 0));
        bool onground1 = Physics2D.Linecast(role.transform.position, maps[1].transform.position,
            1 << LayerMask.NameToLayer("background"));
        print(onground1);
    //    print("world:" + a.ToString());
        roleposition = role.transform.position;
        roleViewportPosition = Camera.main.WorldToViewportPoint(roleposition);
 //       print("aaa"+roleViewportPosition.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        //第一种实现方案，加了碰撞器，碰撞时检测速度方向
        if (notify == 0)
            return;
        else {
            roleposition = role.transform.position;
            roleViewportPosition = Camera.main.WorldToViewportPoint(roleposition);
            print("world" + roleposition.ToString());
            print("viewport:"+roleViewportPosition.ToString());
        }
        switch (notify) { 
            case 1://经过map[0]往上
                rootmap = maps[0].transform.position;
                maps[2].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                if(lastnotify == 4)//往右上
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if(lastnotify == 3)//往左上
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                break;
            case 2://经过map[0]往下
                rootmap = maps[0].transform.position;
                maps[2].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 4)//往右下
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                else if (lastnotify == 3)//往左下
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 3://经过map[0]往左
                rootmap = maps[0].transform.position;
                maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 1)//往左上
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 2)//往左下
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 4://经过map[0]往右
                rootmap = maps[0].transform.position;
                maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }

                if (lastnotify == 1)//往右上
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 2)//往右下
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;



            case 5://经过map[1]往上
                rootmap = maps[1].transform.position;
                maps[3].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                if (lastnotify == 7)//往右上
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 8)//往左上
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                break;
            case 6://经过map[1]往下
                rootmap = maps[1].transform.position;
                maps[3].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 8)//往右下
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                else if (lastnotify == 7)//往左下
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 7://经过map[1]往左
                rootmap = maps[1].transform.position;
                maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 5)//往左上
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 6)//往左下
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 8://经过map[1]往右
                rootmap = maps[1].transform.position;
                maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 5)//往右上
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 6)//往右下
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;


            case 9://经过map[2]往上
                rootmap = maps[2].transform.position;
                maps[0].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                if (lastnotify == 12)//往右上
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 11)//往左上
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                break;
            case 10://经过map[2]往下
                rootmap = maps[2].transform.position;
                maps[0].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }

                if (lastnotify == 12)//往右下
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                else if (lastnotify == 11)//往左下
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 11://经过map[2]往左
                rootmap = maps[2].transform.position;
                maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 9)//往左上
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 10)//往左下
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 12://经过map[2]往右
                rootmap = maps[2].transform.position;
                maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 9)//往右上
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 10)//往右下
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;

            case 13://经过map[3]往上
                rootmap = maps[3].transform.position;
                maps[1].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 16)//往右上
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                else if (lastnotify == 15)//往左上
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 14://经过map[3]往下
                rootmap = maps[3].transform.position;
                maps[1].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                if (roleViewportPosition.x > 0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                if (lastnotify == 16)//往右下
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 15)//往左下
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                break;
            case 15://经过map[3]往左
                rootmap = maps[3].transform.position;
                maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 13)//往左上
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 14)//往左下
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 16://经过map[3]往右
                rootmap = maps[3].transform.position;
                maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
                if (roleViewportPosition.y > 0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                }
                if (lastnotify == 13)//往右上
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                else if (lastnotify == 14)//往右下
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
                break;
        }
        if(notify !=0)
            lastnotify = notify;
        notify = 0;
        //第二种实现方案 直接用坐标
    /*    bool onground1 = Physics2D.Linecast(role.transform.position, maps[1].transform.position,
            1 << LayerMask.NameToLayer("background"));
     * //射线检测在哪一个background出了问题，一直返回真
        if (roleViewportPosition.x > 0.5)
        {

        }
        else { 
            
        }
        if (roleViewportPosition.y > 0.5)
        {

        }
        else { 
            
        }*/
	}
    
    
}
