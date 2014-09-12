using UnityEngine;
using System.Collections.Generic;

public class QueueScript : MonoBehaviour {


	//public List<Item> myItems = new List<Item>();
	public List<GameObject> myItems = new List<GameObject>();
	//public GameObject myPrefab; 
	//Vector2 leftMostItemPosition =  gameObject.transform.parent.transform.position - (gameObject.transform.parent.transform.Scale.x/2);
	public float offset = 0.3f;
	private int counter = 0;
	public float buffer;

	// Use this for initialization
	void Start () {
		float leftMostItemPosition = gameObject.transform.position.x - (gameObject.transform.localScale.x/2) +buffer;
		foreach (GameObject item in myItems) {
			GameObject clone = Instantiate(item, new Vector3(leftMostItemPosition + (offset * counter), transform.position.y, transform.position.z), transform.rotation) as GameObject;
			clone.transform.parent = gameObject.transform;
			counter++;
		}
	}
}
