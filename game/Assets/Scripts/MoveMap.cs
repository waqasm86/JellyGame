using UnityEngine;
using System.Collections;

public class MoveMap : MonoBehaviour
{
    public GameObject[] maps;
    public GameObject role;
    public Camera camera;
    Rect cameraRect;
    Vector3 cemerasize, rootmap, roleposition, roleViewportPosition;
    public Transform[] mapprefabs;

    int current = Colliders.getCurrentMap();
    int last = Colliders.getLastMap();

    void Awake()
    {
        role = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        cameraRect = camera.pixelRect;
        cemerasize = Camera.main.ScreenToWorldPoint(new Vector3(cameraRect.xMax, cameraRect.yMax, 0));
        bool onground1 = Physics2D.Linecast(role.transform.position, maps[1].transform.position,
                                            1 << LayerMask.NameToLayer("background"));
        roleposition = role.transform.position;
        roleViewportPosition = Camera.main.WorldToViewportPoint(roleposition);
        print("width   " + cameraRect.xMax + " height    " + cameraRect.yMax);

    }

    void Update()
    {
        current = Colliders.getCurrentMap();
        last = Colliders.getLastMap();
        switch (current)
        {
            case 0:
                rootmap = maps[0].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 1)
                {
                    maps[8].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[2].transform.position.y, 0);
                    maps[5].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 2)
                {
                    maps[7].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[1].transform.position.y, 0);
                    maps[4].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 3)
                {
                    maps[8].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[6].transform.position = new Vector3(maps[6].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[7].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 6)
                {
                    maps[5].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[3].transform.position = new Vector3(maps[3].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[4].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 1:
                rootmap = maps[1].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 0)
                {
                    maps[8].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[2].transform.position.y, 0);
                    maps[5].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 2)
                {
                    maps[6].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[0].transform.position.y, 0);
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 4)
                {
                    maps[6].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[7].transform.position = new Vector3(maps[7].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[8].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 7)
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[4].transform.position = new Vector3(maps[4].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[5].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 2:
                rootmap = maps[2].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 1)
                {
                    maps[6].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[0].transform.position.y, 0);
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 0)
                {
                    maps[7].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[1].transform.position.y, 0);
                    maps[4].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 5)
                {
                    maps[7].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[8].transform.position = new Vector3(maps[8].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[6].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 8)
                {
                    maps[4].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[5].transform.position = new Vector3(maps[5].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 3:
                rootmap = maps[3].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[4].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[4].transform.position.y, 0);
                    maps[7].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 4)
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[5].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[5].transform.position.y, 0);
                    maps[8].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 6)
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[0].transform.position = new Vector3(maps[0].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 0)
                {
                    maps[8].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[6].transform.position = new Vector3(maps[6].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[7].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 4:
                rootmap = maps[4].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 3)
                {
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[5].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[5].transform.position.y, 0);
                    maps[8].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 5)
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[3].transform.position.y, 0);
                    maps[6].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 7)
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[1].transform.position = new Vector3(maps[1].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 1)
                {
                    maps[6].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[7].transform.position = new Vector3(maps[7].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[8].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 5:
                rootmap = maps[5].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 4)
                {
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[3].transform.position.y, 0);
                    maps[6].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 3)
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[4].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[4].transform.position.y, 0);
                    maps[7].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 8)
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[2].transform.position = new Vector3(maps[2].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 2)
                {
                    maps[7].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[8].transform.position = new Vector3(maps[8].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[6].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 6:
                rootmap = maps[6].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 8)
                {
                    maps[4].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[7].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[7].transform.position.y, 0);
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 7)
                {
                    maps[5].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[8].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[8].transform.position.y, 0);
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 0)
                {
                    maps[5].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[3].transform.position = new Vector3(maps[3].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[4].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 3)
                {
                    maps[2].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[0].transform.position = new Vector3(maps[0].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[1].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 7:
                rootmap = maps[7].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 6)
                {
                    maps[5].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[8].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[8].transform.position.y, 0);
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 8)
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[6].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[6].transform.position.y, 0);
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 1)
                {
                    maps[3].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[4].transform.position = new Vector3(maps[4].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[5].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 4)
                {
                    maps[0].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[1].transform.position = new Vector3(maps[1].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[2].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
            case 8:
                rootmap = maps[8].transform.position;
                roleViewportPosition = Camera.main.WorldToViewportPoint(rootmap);
                if (last == 7)
                {
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[6].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, maps[6].transform.position.y, 0);
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 6)
                {
                    maps[4].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[7].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, maps[7].transform.position.y, 0);
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                else if (last == 2)
                {
                    maps[4].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[5].transform.position = new Vector3(maps[5].transform.position.x, rootmap.y + 2 * cemerasize.y, 0);
                    maps[3].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y + 2 * cemerasize.y, 0);
                }
                else if (last == 5)
                {
                    maps[1].transform.position = new Vector3(rootmap.x - 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[2].transform.position = new Vector3(maps[2].transform.position.x, rootmap.y - 2 * cemerasize.y, 0);
                    maps[0].transform.position = new Vector3(rootmap.x + 2 * cemerasize.x, rootmap.y - 2 * cemerasize.y, 0);
                }
                break;
        }
    }
}
