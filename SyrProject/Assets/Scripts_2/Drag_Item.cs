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

	void Start(){
		startPosition = transform.position;



	}

	void OnCollisionStay2D(Collision2D coll) {
		switch(coll.gameObject.name){
		case "Orange_Spot1":
			QueueScript1 orangeQueueScript = this.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.Insert(0, (Item_Set)coll.gameObject.GetComponent<Item_Set>());
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;

			break;
		default:
			break;
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
		
	}

	void OnMouseUp(){
		if(touchingWhereIWantToBe){


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
