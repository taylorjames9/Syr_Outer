using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QueueScript1 : MonoBehaviour {


	private GameObject myOwner;
	//myOwnersList of projects

	private GameObject myPotentialIncomingObject;
	private GameObject myPotentialOutgoingObject;

	public List<Item_Set> myItemObjects = new List<Item_Set>();
	public List<Transform> myQSpots = new List<Transform>();

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
		foreach(Item_Set item in myItemObjects){
			item.transform.renderer.enabled = false; 
		}
		displayNewQueueVisualFromOwnerQueueList ();
	}


	//Responsibilities
	public void addNewObjectToOwnerQueue(){

	}

	public void removeUsedObjectFromOwnerQueue(){
		myItemObjects[0].transform.renderer.enabled = false;
		myItemObjects.RemoveAt(0);
	}

	public void animatePotentialNewIncomingObject(){

	}

	public void animatePotentialOutgoingObject(){

	}

	public void displayNewQueueVisualFromOwnerQueueList(){
		Debug.Log("Number of Queue items in list for"+this.transform.parent.name+" : "+myItemObjects.Count);
			for(int i=0; i<myItemObjects.Count; i++){
			myItemObjects[i].transform.tag = i.ToString();
			if(myItemObjects.Count >= 0 && myItemObjects[i] != null){
				myItemObjects[i].transform.renderer.enabled = true;
				myItemObjects[i].transform.parent = gameObject.transform;
			 	myItemObjects[i].transform.position = myQSpots[i].transform.position;
			}
		}
	}


//	public void displayNewQueueVisualFromOwnerQueueList(){
//		Debug.Log ("Ran displayQueue Method");
//		float leftMostPosition = gameObject.transform.position.x - (gameObject.transform.localScale.x / 2)+buffer;
//		foreach (Item_Set item in myItemObjects) {
//			if(item != null){
//				item.transform.renderer.enabled = true;
//				Debug.Log ("Should be rearranging new queue");
//				item.transform.position = new Vector3 (leftMostPosition + (offset * counter), transform.position.y, transform.position.z);
//				item.transform.parent = gameObject.transform;
//				counter++;
//			}
//		}
//
//	}

}
