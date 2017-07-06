using UnityEngine;
using System.Collections;

public class ClickHome : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		if(Input.touchCount==1) {
			foreach (Touch touch in Input.touches) {
		        if (touch.phase == TouchPhase.Began) {
					//sceneCh(touch.position);
					Ray ray = Camera.main.ScreenPointToRay(touch.position);
					RaycastHit hit ;
					if (Physics.Raycast (ray, out hit)) {
						GameObject button = hit.collider.gameObject;
						string nm = button.name;
						
						Material cMat = Resources.Load("home_button_c") as Material;
						button.transform.localScale = new Vector3 (button.transform.localScale.x,0.01f,button.transform.localScale.z);
						button.GetComponent<Renderer>().material = cMat;
						wait();
						
						if (nm=="Button 1") { Application.LoadLevel(1); }
						if (nm=="Button 2") { Application.LoadLevel(2); }
						if (nm=="Button 3") { Application.LoadLevel(3); }
					}
				}
			}
		}
	}
	
	IEnumerator wait() {
		yield return new WaitForSeconds(1);
	}
}
