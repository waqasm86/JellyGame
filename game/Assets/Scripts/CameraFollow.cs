using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float Xmax =1f;
	public float Ymax =10f;
	public float Xsmooth=8f;
	public float Ysmooth=8f;
	public Vector2 maxxy;
	public Vector2 minxy;
	
	public Transform player;
	// Use this for initialization
	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player").transform;
        print(GameObject.FindGameObjectWithTag("Player").transform.ToString());
	}
	bool checkx(){
		return Mathf.Abs(transform.position.x-player.position.x)>Xmax;
	}
	bool checky(){
		return Mathf.Abs(transform.position.y-player.position.y)>Ymax;
	}
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        print(GameObject.FindGameObjectWithTag("Player").transform.position.ToString());
        print("dada");
	}
    void Update() {
        track();
    }
	// Update is called once per frame
	void FixedUpdate () {
		track();
	}
	void track(){
		float tx=transform.position.x;
		float ty=transform.position.y;
		if(checkx()){
			tx = Mathf.Lerp(transform.position.x,player.position.x,Xsmooth*Time.deltaTime);
		}
		if(checky()){
			ty = Mathf.Lerp(transform.position.y,player.position.y,Ysmooth*Time.deltaTime);
		}
		tx = Mathf.Clamp(tx,minxy.x,maxxy.x);
		ty = Mathf.Clamp(ty,minxy.y,maxxy.y);
		transform.position = new Vector3(player.transform.position.x,player.transform
            .position.y,transform.position.z);
	}
}
