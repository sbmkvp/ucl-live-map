using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {
	private GameObject building;
	private bool cl;
	private Vector3 pt;
	private GameObject obj;
	private Material mat;
	private Transform t;
	private Vector3 tar;
	private GameObject temp;
	private Material selt, nselt;

	void Start () {
		obj = Resources.Load("board",typeof(GameObject)) as GameObject;
		nselt = Resources.Load("twit_bird",typeof(Material)) as Material;
		selt = Resources.Load("twit_sel",typeof(Material)) as Material;
	}
	
	void Update () {
		if(Input.touchCount>0) {
			foreach (Touch touch in Input.touches) {
		        if (touch.phase == TouchPhase.Began) {
					clickReaction(touch.position);
				}
			}
		}
	}
	
	void clickReaction(Vector3 tar) {
		Ray ray = Camera.main.ScreenPointToRay(tar);
        RaycastHit hit ;
	    if (Physics.Raycast (ray, out hit)) {
			building = hit.collider.gameObject;
			if(building.transform.parent.name=="ucl_buildings"){			
				if(building.tag == "sel") {
					foreach(Transform child in building.transform) {	
						Destroy(child.gameObject);
					}
					building.GetComponent<Renderer>().material = Resources.Load("ucl_build", typeof(Material))as Material;
					building.tag = "Untagged";
				} else {
					Vector3 pos = new Vector3(hit.point.x,(hit.point.y+0.10f),hit.point.z);
					temp = Instantiate (obj,pos,Quaternion.Euler(0,0,0)) as GameObject;
					temp.transform.parent = building.transform;
					building.GetComponent<Renderer>().material = Resources.Load("ucl_build_sel", typeof(Material))as Material;
					building.tag = "sel";
				}
			}
			if(building.transform.parent.name == "twitter(Clone)") {
				GameObject tw = building.transform.parent.gameObject;
				GameObject gtxt = tw.transform.Find("tweet").gameObject;
				GUIText txt = gtxt.GetComponent<GUIText>();
				GameObject cgtw = GameObject.Find("cur_tweet") as GameObject;
				GUIText ctw = cgtw.GetComponent<GUIText>();
				if(string.Compare(txt.text,ctw.text)==0) {
					ctw.text = " ";
					tw.GetComponent<Renderer>().material = nselt;
				} else {
					ctw.text = txt.text;
					tw.GetComponent<Renderer>().material = selt;
				}
			}
			if(building.transform.parent.name == "clus_cont(Clone)") {
				GameObject gtxt = building.transform.Find("clusinfo").gameObject;
				GUIText txt = gtxt.GetComponent<GUIText>();
				print (txt.text);
				GameObject cgtw = GameObject.Find("cur_tweet") as GameObject;
				GUIText ctw = cgtw.GetComponent<GUIText>();
				if(string.Compare(txt.text,ctw.text)==0) {
					ctw.text = " ";
					print ("hello");
					//tw.renderer.material = nselt;
				} else {
					ctw.text = txt.text;
					//tw.renderer.material = selt;
				}
			}
		}
	}
}