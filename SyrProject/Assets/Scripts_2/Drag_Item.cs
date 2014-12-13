using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]

public class Drag_Item : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startPosition;
	private bool touchingWhereIWantToBe;
	private Vector2 itemGoesToThisSpot;
	private bool iAmBeingMoved;

	void Start(){
		startPosition = transform.position;



	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("COLLIDER ON SYR GOT COLLIDED");
		Debug.Log("COLLIDING WITH : "+ coll.gameObject.name);
		//if(coll.gameObject is Q_Spot_Coll_Script){
		if(iAmBeingMoved){
			if(coll.gameObject.name == "Orange_Spot1"){
				Debug.Log("TOUCHING ORANGE SPOT 1");
				QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				orangeQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				
				orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				//transform.position = coll.transform.position;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
				/**
				 * Make the parent of this thing the parent of the other object that you collided with
				 * */
			}
		}
	}
	
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		transform.position = curPosition;
		iAmBeingMoved = true;
	}

	void OnMouseUp(){
		iAmBeingMoved = false;
		if(touchingWhereIWantToBe){
			transform.position = itemGoesToThisSpot;
		}
		else
			transform.position = startPosition;
	}

	public void setTouchingWhereIWantToBe(bool tf){
		if(tf){
			touchingWhereIWantToBe = true;
		}
		else
			touchingWhereIWantToBe = false;
	}

}
