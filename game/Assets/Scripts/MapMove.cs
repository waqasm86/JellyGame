using UnityEngine;
using System.Collections;

public class MapMove : MonoBehaviour {
    public GameObject[] maps;
    public GameObject role;
    public static int notify= 0 ;
    private int lastnotify = 0;
    public Camera camera;
    Rect cameraRect;
    Vector3 cemerasize,rootmap,roleposition,roleViewportPosition;
    public Transform[] mapprefabs;
    Transform tr, tr1, tr2;

    void Awake() {
        role = GameObject.FindGameObjectWithTag("Player");
    }

	// Use this for initialization
	void Start () {
        cameraRect = camera.pixelRect;
        cemerasize= Camera.main.ScreenToWorldPoint(new Vector3(cameraRect.xMax,cameraRect.yMax, 0));
        bool onground1 = Physics2D.Linecast(role.transform.position, maps[1].transform.position,
            1 << LayerMask.NameToLayer("background"));
        roleposition = role.transform.position;
        roleViewportPosition = Camera.main.WorldToViewportPoint(roleposition);
    }
	
	// Update is called once per frame
	void Update () {
        //第一种实现方案，加了碰撞器，碰撞时检测速度方向
        if (notify == 0)
            return;
        else {         
        }
        switch (notify) { 
            case 1://经过map[0]往上
                tr = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);
                rootmap = maps[0].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[2].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
                
			if (roleViewportPosition.x<0.5)
                {
				    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y , 0);
                }
                else {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
				break;
            case 2://经过map[0]往下
                tr = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);
                rootmap = maps[0].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[2].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
			if (roleViewportPosition.x<0.5)
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                else
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                break;
            case 3://经过map[0]往左
                tr = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);
                rootmap = maps[0].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
			if (roleViewportPosition.y<0.5)
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x ,rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 4://经过map[0]往右
                tr = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[0].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
				if (roleViewportPosition.y<0.5)
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x,rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x , rootmap.y - 2 * cemerasize.y, 0);
                }
                break;


            case 5://经过map[1]往上
                rootmap = maps[1].transform.position;
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[3].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
				if (roleViewportPosition.x<0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                break;
            case 6://经过map[1]往下
                rootmap = maps[1].transform.position;
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[3].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
				if (roleViewportPosition.x<0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                break;
            case 7://经过map[1]往左
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[1].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
				if (roleViewportPosition.y<0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x,
				    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x,
				    rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 8://经过map[1]往右
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[1].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
				if (roleViewportPosition.y<0.5)
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x,
				    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x,
				    rootmap.y - 2 * cemerasize.y, 0);
                }
                break;


            case 9://经过map[2]往上
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[2].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[0].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
				if (roleViewportPosition.x<0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                break;
            case 10://经过map[2]往下
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[2].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[0].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
				if (roleViewportPosition.x<0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y , 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                break;
            case 11://经过map[2]往左
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[2].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
				if (roleViewportPosition.y<0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x,
				    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x,
				    rootmap.y - 2 * cemerasize.y, 0);
                }
//                if (lastnotify == 9)//往左上
//                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
//                    rootmap.y + 2 * cemerasize.y, 0);
//                else if (lastnotify == 10)//往左下
//                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
//                    rootmap.y - 2 * cemerasize.y, 0);
                break;
            case 12://经过map[2]往右
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[3], maps[3].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[2].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
				if (roleViewportPosition.y<0.5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x,
				    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[0].transform.position = new Vector3(rootmap.x,
				    rootmap.y - 2 * cemerasize.y, 0);
                }
                break;

            case 13://经过map[3]往上
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);
	
                rootmap = maps[3].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[1].transform.position = new Vector3(rootmap.x,
                    rootmap.y + 2 * cemerasize.y, 0);
				if (roleViewportPosition.x<0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                break;
            case 14://经过map[3]往下
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);


                rootmap = maps[3].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[1].transform.position = new Vector3(rootmap.x,
                    rootmap.y - 2 * cemerasize.y, 0);
				if (roleViewportPosition.x<0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
				    rootmap.y, 0);
                }
                break;
            case 15://经过map[3]往左
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[3].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x
                    , rootmap.y, 0);
				if (roleViewportPosition.y<0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x,
				    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x,
				    rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 16://经过map[3]往右
                tr = (Transform)Instantiate(mapprefabs[0], maps[0].transform.position,
                Quaternion.identity);
                tr1 = (Transform)Instantiate(mapprefabs[2], maps[2].transform.position,
                Quaternion.identity);
                tr2 = (Transform)Instantiate(mapprefabs[1], maps[1].transform.position,
                Quaternion.identity);
                Destroy(tr.gameObject,1);
                Destroy(tr1.gameObject, 1);
                Destroy(tr2.gameObject, 1);

                rootmap = maps[3].transform.position;
				roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x
                    , rootmap.y, 0);
				if (roleViewportPosition.y<0.5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y + 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x,
				    rootmap.y + 2 * cemerasize.y, 0);
                }
                else
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x,
                    rootmap.y - 2 * cemerasize.y, 0);
					maps[1].transform.position = new Vector3(rootmap.x ,
				    rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
        }
        if(notify !=0)
            lastnotify = notify;
        notify = 0;
        
	}
}
