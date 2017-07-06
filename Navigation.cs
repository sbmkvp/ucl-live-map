using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	void OnGUI () {
		GameObject cam = GameObject.Find("ARCamera") as GameObject;
		float x = cam.transform.position.x;
		float y = cam.transform.position.y;
		float z = cam.transform.position.z;
		float gap = Screen.width/28;
		float wid = Screen.width/8;

		if(GUI.Button(new Rect(gap,20,wid,30), "Zoom in")) {
			cam.transform.position = new Vector3(x,y-0.1f,z);
		}
		
		if(GUI.Button(new Rect((2*gap)+wid,20,wid,30), "Zoom out")) {
			cam.transform.position = new Vector3(x,y+0.1f,z);
		}
		
		if(GUI.Button(new Rect((3*gap)+(2*wid),20,wid,30), "Left")) {
			cam.transform.position = new Vector3(x-0.1f,y,z);
		}
		
		if(GUI.Button(new Rect((4*gap)+(3*wid),20,wid,30), "Right")) {
			cam.transform.position = new Vector3(x+0.1f,y,z);
		}
		
		if(GUI.Button(new Rect((5*gap)+(4*wid),20,wid,30), "Top")) {
			cam.transform.position = new Vector3(x,y,z+0.1f);
		}
		
		if(GUI.Button(new Rect((6*gap)+(5*wid),20,wid,30), "Bottom")) {
			cam.transform.position = new Vector3(x,y,z-0.1f);
		}
	}
}
