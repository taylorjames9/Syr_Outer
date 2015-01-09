using UnityEngine;
using System.Collections;

public class StabBack_Script : MonoBehaviour {

	private int tapsOnSwitchBack;

	// Use this for initialization
	void Start () {
		//this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.15f);
		toggleStabBack(0.15f);
	}

	void OnMouseUp(){
		tapsOnSwitchBack++;
		if(tapsOnSwitchBack % 2 == 1){
			toggleStabBack(1.0f);
			Debug.Log("Setting stab back");
		}
		else {
			toggleStabBack(0.15f);
		}
	}

	public string toggleStabBack(float alph){
		this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, alph);
		if(alph< 0.5f){
			this.transform.GetComponentInParent<Character>().setStabBack(false);
			return "grey";
		}
		else{
			this.transform.GetComponentInParent<Character>().setStabBack(true);
			return "black";
		}
	}

}
