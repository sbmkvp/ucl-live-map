//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using MiniJSON;
//
//public class addInfo : MonoBehaviour {
//	private GameObject building;
//	private IList list;
//	private string rt,rt1;
//	
//	void Start () {	
//		building = this.transform.parent.gameObject;
//		Component[] transforms = this.GetComponentsInChildren(typeof(Transform));
//		foreach (Transform child in transforms){
//			if (child.gameObject.name == "01_title") {
//				TextMesh texM = child.gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
//				string m = readData(building.name);
//				texM.text = string.Format(m);
//			}
//			if (child.gameObject.name == "03_entity") {
//				TextMesh texM = child.gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
//				string m = readData1(building.name);
//				texM.text = string.Format(m);
//			}
//		}
//	}
//	
//	void Update () {
//		
//	}
//	
//	string readData(string query) {
//		string strData;
//		
//		WWW www = new WWW("http://balaspa.comuf.com/build.json");
//		while(!www.isDone) {}
//		if(www.error==null) {
//			strData = www.text;
//		} else {
//			TextAsset tas = Resources.Load("build",typeof(TextAsset))as TextAsset;
//			strData = tas.text;
//		}
//		
//		IDictionary results = (IDictionary) Json.Deserialize(strData);
//		list = (IList) results["results"];
//		foreach(IDictionary building in list) {
//			if(building["mesh"]as string ==query) {
//				rt =  building["name"]as string;
//			}
//		}
//		return(rt);
//	}
//	
//	string readData1(string query) {
//		foreach(IDictionary building in list) {
//			if(building["mesh"]as string ==query) {
//				rt1 +=  string.Format ("{0} : {1} \n",building["type"],building["entity"])as string;
//			}
//		}
//		return(rt1);
//	}
//	
//}