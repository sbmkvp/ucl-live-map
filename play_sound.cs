using UnityEngine;
using System.Collections;

public class play_sound : MonoBehaviour {
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0) {
			foreach (Touch touch in Input.touches) {
		        if (touch.phase == TouchPhase.Began) {
					plsound(touch.position);
				}
		        if (touch.phase == TouchPhase.Ended) {
					stsound(touch.position);
				}
			}
		}
	}
	
	void plsound(Vector3 x) {
		Ray ray = Camera.main.ScreenPointToRay(x);
        RaycastHit hit ;
	    if (Physics.Raycast (ray, out hit)) {
			GameObject obj = hit.collider.gameObject;
			if(obj==this.gameObject){
				sound.Play();
			}
		}
	}
	
	void stsound(Vector3 x) {
		Ray ray = Camera.main.ScreenPointToRay(x);
        RaycastHit hit ;
	    if (Physics.Raycast (ray, out hit)) {
			GameObject obj = hit.collider.gameObject;
			if(obj==this.gameObject){
				sound.Stop();
			}
		}
	}
	
	
	
}
