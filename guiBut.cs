using UnityEngine;
using System.Collections;

public class guiBut : MonoBehaviour {

	void OnGUI () {
		GameObject agents = Resources.Load("Agents") as GameObject;
		GameObject buses = Resources.Load("Buses") as GameObject;
		GameObject underg = Resources.Load("Underground") as GameObject;
		GameObject foliage = Resources.Load("Foliage") as GameObject;
		GameObject strFurn = Resources.Load("Street Furniture") as GameObject;
		GameObject twtCon = Resources.Load("twitter_con") as GameObject;
		GameObject sounds = Resources.Load("Sounds") as GameObject;
		GameObject logos = Resources.Load("Logos") as GameObject;
		GameObject cluster = Resources.Load("clus_cont") as GameObject;
		float gap = Screen.width/28;
		float wid = Screen.width/8;

		if(GUI.Button(new Rect(gap,20,wid,30), "Agents")) {
			if(GameObject.Find ("Agents(Clone)")!=null) {
				Destroy (GameObject.Find ("Agents(Clone)"));
			} else {
				(Instantiate(agents)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
				
				
			}
		}
		
		if(GUI.Button(new Rect((2*gap)+wid,20,wid,30), "Transport")) {
			if(GameObject.Find ("Buses(Clone)")!=null) {
				Destroy (GameObject.Find ("Buses(Clone)"));
				Destroy (GameObject.Find("Underground(Clone)"));
				Destroy (GameObject.Find("Logos(Clone)"));
			} else {
				(Instantiate(buses)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
				(Instantiate(underg)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
				(Instantiate(logos)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
			}
		}
		
		if(GUI.Button(new Rect((3*gap)+(2*wid),20,wid,30), "Streetscape")) {
			if(GameObject.Find ("Foliage(Clone)")!=null) {
				Destroy (GameObject.Find ("Foliage(Clone)"));
				Destroy (GameObject.Find ("Street Furniture(Clone)"));
			} else {
				(Instantiate(foliage)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
				(Instantiate(strFurn)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
			}
		}
		
		if(GUI.Button(new Rect((4*gap)+(3*wid),20,wid,30), "Twitter")) {
			if(GameObject.Find ("twitter_con(Clone)")!=null) {
				Destroy (GameObject.Find ("twitter_con(Clone)"));
			} else {
				(Instantiate(twtCon)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
			}
		}
		
		if(GUI.Button(new Rect((5*gap)+(4*wid),20,wid,30), "UCLsounds")) {
			if(GameObject.Find ("Sounds(Clone)")!=null) {
				Destroy (GameObject.Find ("Sounds(Clone)"));
			} else {
				(Instantiate(sounds)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
			}
		}
		
		if(GUI.Button(new Rect((6*gap)+(5*wid),20,wid,30), "clusters")) {
			if(GameObject.Find ("cluster(Clone)")!=null) {
				Destroy (GameObject.Find ("clus_cont(Clone)"));
			} else {
				(Instantiate(cluster)as GameObject).transform.parent = GameObject.Find("ImageTarget").transform;
			}
		}
	}
}
