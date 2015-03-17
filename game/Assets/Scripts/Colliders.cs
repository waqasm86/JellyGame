using UnityEngine;
using System.Collections;

public class Colliders{

	private static int CurrentMap = 4;
	private static int LastMap = -1;

	public static int getCurrentMap(){
		return CurrentMap;
	}
	public static int getLastMap(){
		return LastMap;
	}
	public static void SetCurrentMap(int c){
		CurrentMap = c;
	}
	public static void SetLastMap(int l){
		LastMap =l;
	}
}
