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
				itemGoesToThisSpot = (Vector2) coll.transform.position;
			}
			else if(coll.gameObject.name == "Orange_Spot2"){
				Debug.Log("TOUCHING ORANGE SPOT 2");
				QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				orangeQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;

			}
			else if(coll.gameObject.name == "Orange_Spot3"){
				Debug.Log("TOUCHING ORANGE SPOT 3");
				QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				orangeQueueScript.myItemObjects.Insert(2, this.GetComponent<Item_Set>());
				orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
			}
			else if(coll.gameObject.name == "Blue_Spot1"){
				Debug.Log("TOUCHING Blue SPOT 1");
				QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				blueQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
			}
			else if(coll.gameObject.name == "Blue_Spot2"){
				Debug.Log("TOUCHING Blue SPOT 2");
				QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				blueQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
			}
			else if(coll.gameObject.name == "Blue_Spot3"){
				Debug.Log("TOUCHING Blue SPOT 3");
				QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				blueQueueScript.myItemObjects.Insert(2, this.GetComponent<Item_Set>());
				blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
			}
			else if(coll.gameObject.name == "Green_Spot1"){
				Debug.Log("TOUCHING green SPOT 0");
				QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				greenQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
			}
			else if(coll.gameObject.name == "Green_Spot2"){
				Debug.Log("TOUCHING green SPOT 1");
				QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				greenQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
			}
			else if(coll.gameObject.name == "Green_Spot3"){
				Debug.Log("TOUCHING green SPOT 2");
				QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
				greenQueueScript.myItemObjects.Insert(2, this.GetComponent<Item_Set>());
				greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
				touchingWhereIWantToBe = true;
				itemGoesToThisSpot = (Vector2) coll.transform.position;
				
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
