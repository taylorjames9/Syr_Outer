using UnityEngine;
using System.Collections;

public class StabBack_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//this.GetComponent.SpriteRenderer.color = new Color(1f,1f,1f,0.5f);
		this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.15f);
	}

	void OnMouseUp(){
		this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		//this.transform.GetComponentInParent<Character>().setStabBack(true);
		Debug.Log("Setting stab back");
	}

}
