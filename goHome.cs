using UnityEngine;
using System.Collections;

public class goHome : MonoBehaviour {
	private GUITexture button;
	private Camera tCam;
	
	// Use this for initialization
	void Start () {
		button = (GUITexture) this.gameObject.GetComponent("GUITexture") as GUITexture;
		tCam = GameObject.Find("ARCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0) {
			foreach (Touch touch in Input.touches) {
		        if (touch.phase == TouchPhase.Began) {
					if (button.HitTest(touch.position, tCam)) {
						Application.LoadLevel(0);
					}
				}
			}
		}
	}
}
