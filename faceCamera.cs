using UnityEngine;
using System.Collections;

public class faceCamera : MonoBehaviour {
	private Transform tCam,tObj;
	private GameObject Cam, Obj;
	private Vector3 posCam, posObj;
	
	void Start () {

	}
	
	void Update () {
		Cam = GameObject.Find("ARCamera");
		Obj = this.gameObject;
		tCam = Cam.transform;
		tObj = Obj.transform;
		posCam = tCam.position;
		posObj = tObj.position;
		
		
		float a = posCam.y - posObj.y;
		float b = Mathf.Sqrt(Mathf.Pow((posCam.x-posObj.x),2)+Mathf.Pow((posCam.z-posObj.z),2));
		if(b>0.85f*a) {
			float sqx = Mathf.Pow(posCam.x,2);
			float sqz = Mathf.Pow(posCam.y,2);
			if (posCam.x>0 && sqx>=sqz) {
				this.transform.LookAt (2*posObj-new Vector3(1000000,posObj.y,posObj.z));
			}
			if (posCam.z>0 && sqz>=sqx) {
				this.transform.LookAt (2*posObj-new Vector3(posObj.x,posObj.y,1000000));
			}
			if (posCam.z<0 && sqz>=sqx) {
				this.transform.LookAt (2*posObj-new Vector3(posObj.x,posObj.y,-1000000));
			}
			if (posCam.x<0 && sqx>=sqz) {
				this.transform.LookAt (2*posObj-new Vector3(-1000000,posObj.y,posObj.z));
			}
		}
		else {
			this.transform.LookAt (2*posObj-new Vector3(posObj.x,10,posObj.z));
		}		
	}
}