using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QueueScript1 : MonoBehaviour {


	private GameObject myOwner;
	//myOwnersList of projects

	private GameObject myPotentialIncomingObject;
	private GameObject myPotentialOutgoingObject;

	public List<Item_Set> myItemObjects = new List<Item_Set>();

	//Each object inside the collider with a prefab will have a triggerEnter2D methods, which when active, will change these colliderBools
	//might be easiest to make these into properties
	private bool collider_1_isActive;
	private bool collider_2_isActive;
	private bool collider_3_isActive;
	private bool collider_4_isActive;
	private bool collider_5_isActive;

	private static float offset = 0.5f;
	private static float buffer = 0.2f;
	private int counter = 0;


	void Start(){

		this.gameObject.SetActive (false);

		myOwner = transform.parent.gameObject;
		displayNewQueueVisualFromOwnerQueueList ();
		//myItemObjects = gameObject.GetComponentsInChildren(Transform);

		Debug.Log ("My Item list " + myItemObjects);

	}


	//Responsibilities
	public void addNewObjectToOwnerQueue(){

	}

	public void removeUsedObjectFromOwnerQueue(){

	}

	public void animatePotentialNewIncomingObject(){

	}

	public void animatePotentialOutgoingObject(){

	}

	public void displayNewQueueVisualFromOwnerQueueList(){
		Debug.Log ("Ran displayQueue Method");
		float leftMostPosition = gameObject.transform.position.x - (gameObject.transform.localScale.x / 2)+buffer;
		foreach (Item_Set item in myItemObjects) {
			Debug.Log ("Should be setting position.");
			item.transform.position = new Vector3 (leftMostPosition + (offset * counter), transform.position.y, transform.position.z);
			item.transform.parent = gameObject.transform;
			counter++;
		}

	}

}
