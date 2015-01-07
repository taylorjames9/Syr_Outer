using UnityEngine;
using System.Collections;

public class StabBack_Script : MonoBehaviour {

	private int tapsOnSwitchBack;

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.15f);
	}

	void OnMouseUp(){
		tapsOnSwitchBack++;
		if(tapsOnSwitchBack % 2 == 1){
		this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		this.transform.GetComponentInParent<Character>().setStabBack(true);
		Debug.Log("Setting stab back");
		}
		else {
			this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.15f);
			this.transform.GetComponentInParent<Character>().setStabBack(false);
		}
	}

}
