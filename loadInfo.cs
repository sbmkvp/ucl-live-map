using UnityEngine;
using System.Collections;
using MiniJSON;

public class loadInfo : MonoBehaviour {
	private IList list;
	
	void Start () {
		string strData;
		WWW www = new WWW("http://balaspa.comuf.com/build.json");
		while(!www.isDone) {}
		if(www.error==null) {
			strData = www.text;
		} else {
			TextAsset tas = Resources.Load("build",typeof(TextAsset))as TextAsset;
			strData = tas.text;
		}
		
		IDictionary results = (IDictionary) Json.Deserialize(strData);
		list = (IList) results["results"];
	}
	
	void Update () {
		foreach (Transform child in this.gameObject.transform) {
			if (child.gameObject.tag=="sel") {
				Component[] transforms = child.gameObject.GetComponentsInChildren(typeof(Transform));
				foreach (Transform comp in transforms){
					if (comp.gameObject.name == "01_title") {
						TextMesh texM = comp.gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
						string m = readData(child.gameObject.name);
						texM.text = string.Format(m);
						}
					if (comp.gameObject.name == "03_entity") {
						TextMesh texM = comp.gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
						string m = readData1(child.gameObject.name);
						texM.text = string.Format(m);
					}
				}
			}
		}
	}
	
	
	string readData(string query) {
		string rt = null;
		
		foreach(IDictionary building in list) {
			if(building["mesh"]as string ==query) {
				rt =  building["name"]as string;
			}
		}
		return(rt);
	}
	
	string readData1(string query) {
		string rt1 = null;
		foreach(IDictionary building in list) {
			if(building["mesh"]as string ==query) {
				rt1 +=  string.Format ("{0} : {1} \n",building["type"],building["entity"])as string;
			}
		}
		return(rt1);
	}
}
