using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class twitter : MonoBehaviour {
private GameObject twit, obj;
public ArrayList myNodes;

void Start () {
	myNodes = new ArrayList();
	obj = Resources.Load("twitter",typeof(GameObject)) as GameObject;
	StartCoroutine("GetTwitterUpdate"); 
	}

	void Update () {

	}
	
	IEnumerator GetTwitterUpdate() {
		WWW www = new WWW("http://search.twitter.com/search.json?q=ucl&geocode=51.524414%2C-0.132789%2C0.75km&rpp=100");
		float elapsedTime = 0.0f;
		while (!www.isDone) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= 10.0f) break;
			yield return null;  
		}
		if (!www.isDone || !string.IsNullOrEmpty(www.error)) {
			Debug.LogError(string.Format("Fail Whale!\n{0}", www.error));
			yield break;
		}
		string response = www.text;
		IDictionary search = (IDictionary) Json.Deserialize(response);
		IList tweets = (IList) search["results"];
		foreach (IDictionary tweet in tweets) {
			if (tweet["geo"]!=null){
				IDictionary geo = (IDictionary) tweet["geo"];
				IList cor = (IList) geo["coordinates"];
				string s1 = string.Format("{0}",cor[0]);
				string s2 = string.Format("{0}",cor[1]);
				float b1 = float.Parse(s1);
				float a1 = float.Parse(s2);
				Vector2 tpos = convertToModel(a1,b1);
				Vector3 newpos = new Vector3 (tpos.x,0.05f,tpos.y);
				twit = Instantiate(obj)as GameObject;
				twit.transform.position = newpos;
				twit.transform.parent = GameObject.Find("twitter_con(Clone)").transform;
				//twit.guiText.enabled = false;
				GameObject txt = twit.transform.Find ("tweet").gameObject;
				txt.GetComponent<GUIText>().text = tweet["text"] as string;
				myNodes.Add (twit);
			}
	    }
 	}
	
	Vector2 convertToModel(float x3, float z3) {
		float x1 = -0.139566f; 
		float z1 = 51.524842f;
		float x2 = -0.131405f;
		float z2 = 51.528552f;
		float x4 = -0.134168f;
		float z4 = 51.520276f;
		
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
	
		Vector2 newpos = new Vector2 (x,z);
		return (newpos);
	}
}