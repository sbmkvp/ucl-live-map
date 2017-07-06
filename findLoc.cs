using UnityEngine;
using System.Collections;

public class findLoc : MonoBehaviour {

	private GameObject cube;
	
	void Start () {
		cube = this.gameObject;
		if(Input.location.isEnabledByUser) {
			wait();
			InvokeRepeating("setLocation",1,10f);
		}
	}
	
	void Update () {
	
	}
	
	void setLocation(){
		Input.location.Start(5,5);
		
		if (Input.location.status == LocationServiceStatus.Failed) {
			return;
		} else {
			float x1 = -0.139566f; 
			float z1 = 51.524842f;
			float x2 = -0.131405f;
			float z2 = 51.528552f;
			float x3 = (float)Input.location.lastData.longitude;
			float z3 = (float)Input.location.lastData.latitude;
			float x4 = -0.134168f;
			float z4 = 51.520276f;
			
			if (Application.platform == RuntimePlatform.WindowsEditor){
            	x3 = -0.134196f;
				z3 = 51.524392f;
			}
			
			float p = Mathf.Sqrt(Mathf.Pow((x1-x3),2)+Mathf.Pow((z1-z3),2));
			float q = Mathf.Sqrt(Mathf.Pow((x2-x3),2)+Mathf.Pow((z2-z3),2));
			float r = Mathf.Sqrt(Mathf.Pow((x1-x2),2)+Mathf.Pow((z1-z2),2));
			float s = Mathf.Sqrt(Mathf.Pow((x1-x4),2)+Mathf.Pow((z1-z4),2));
			
			float xdis = (float)((Mathf.Pow(r,2)+Mathf.Pow(p,2)-Mathf.Pow(q,2))/(2*r));
			float zdis = (float)(Mathf.Sqrt(Mathf.Pow(p,2)-Mathf.Pow(xdis,2)));
				
			float x = (xdis/r)-0.5f;
			float z = 0.45f-(zdis/s);
			
			float adjustment = Mathf.Sqrt(Mathf.Pow ((z-0.45f),2))*0.389f;
			x = x - adjustment;
		
			Vector3 newpos = new Vector3 (x,0.04f,z);
			cube.transform.position = newpos;
        }
        Input.location.Stop ();
	}
	
	IEnumerator wait() {
				int maxWait = 20;
				while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
					yield return new WaitForSeconds(1);
				maxWait--;
        	}
	}
}
