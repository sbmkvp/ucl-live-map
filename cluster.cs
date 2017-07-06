using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class cluster : MonoBehaviour {
private GameObject clust, obj;
public ArrayList myNodes;

void Start () {
	myNodes = new ArrayList();
	obj = Resources.Load("cluster",typeof(GameObject)) as GameObject;
	StartCoroutine("GetClusterUpdate"); 
	}

	void Update () {

	}
	
	IEnumerator GetClusterUpdate() {
		WWW www = new WWW("https://campusm.ucl.ac.uk/clusterpc_services/service/pcavailability.jsonp");
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

		JsonData jsonRooms = JsonMapper.ToObject(www.text);
		
		for (int i=0; i<jsonRooms["PcAvailability"]["room"].Count;i++) {
			string s1 = string.Format ("{0}",jsonRooms["PcAvailability"]["room"][i]["latitude"]);
			string s2 = string.Format ("{0}",jsonRooms["PcAvailability"]["room"][i]["longitude"]);
			float b1 = float.Parse(s1);
			float a1 = float.Parse(s2);
			Vector2 tpos = convertToModel(a1,b1);
			Vector3 newpos = new Vector3 (tpos.x,0.07f,tpos.y);
			clust = Instantiate(obj)as GameObject;
			clust.transform.position = newpos;
			clust.transform.parent = GameObject.Find("clus_cont(Clone)").transform;
			GameObject txt = clust.transform.Find ("clusinfo").gameObject;
			txt.GetComponent<GUIText>().text = string.Format("{0}: {1} out of {2} computers are free",jsonRooms["PcAvailability"]["room"][i]["buildingName"],jsonRooms["PcAvailability"]["room"][i]["free"],jsonRooms["PcAvailability"]["room"][i]["seats"]);
			myNodes.Add (clust);
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