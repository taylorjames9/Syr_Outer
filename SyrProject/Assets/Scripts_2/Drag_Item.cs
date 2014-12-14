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
	//public List<Transform> myQHolders = new List<Transform>();
	//LevelManager levelManScript;
	GameObject levelManOBJ;
	LevelManager levelManScript;

	void Start(){
		startPosition = transform.position;
		levelManOBJ = GameObject.FindWithTag("LevelManager"); 
		levelManScript = levelManOBJ.GetComponent<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("Trigger touched with: "+ coll.gameObject.name);
		Debug.Log("Preview should be showing");
		if(iAmBeingMoved){
			previewNewQueue(coll);
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		Debug.Log("Removing Preview");
		if(iAmBeingMoved){
			removePreview(coll);
		}
	}

	public void previewNewQueue(Collider2D coll){

		if(coll.gameObject.name == "Orange_Spot1"){
			Debug.Log("TOUCHING ORANGE SPOT 1");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
			itemGoesToThisSpot = (Vector2) coll.transform.position;
			//levelManScript.sortAllQueuesInLevel();
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

	public void removePreview(Collider2D coll){
		if(coll.gameObject.name == "Orange_Spot1"){
			Debug.Log("Removing from ORANGE SPOT 1");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.RemoveAt(0);
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			//levelManScript.sortAllQueuesInLevel();
		}
		else if(coll.gameObject.name == "Orange_Spot2"){
			Debug.Log("Removing from ORANGE SPOT 2");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.RemoveAt(1);
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
		}
		else if(coll.gameObject.name == "Orange_Spot3"){
			Debug.Log("Removing from ORANGE SPOT 3");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.RemoveAt(2);
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
		}
		else if(coll.gameObject.name == "Blue_Spot1"){
			Debug.Log("removing from Blue SPOT 1");
			QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			blueQueueScript.myItemObjects.RemoveAt(0);
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
		}
		else if(coll.gameObject.name == "Blue_Spot2"){
			Debug.Log("Removing from Blue SPOT 2");
			QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			blueQueueScript.myItemObjects.RemoveAt(1);
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
		}
		else if(coll.gameObject.name == "Blue_Spot3"){
			Debug.Log("Removing From Blue SPOT 3");
			QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			blueQueueScript.myItemObjects.RemoveAt(2);
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
		}
		else if(coll.gameObject.name == "Green_Spot1"){
			Debug.Log("Removing from green SPOT 1");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			greenQueueScript.myItemObjects.RemoveAt(0);
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
		}
		else if(coll.gameObject.name == "Green_Spot2"){
			Debug.Log("Removing from green SPOT 2");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			greenQueueScript.myItemObjects.RemoveAt(1);
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
		}
		else if(coll.gameObject.name == "Green_Spot3"){
			Debug.Log("Removing from green SPOT 3");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			greenQueueScript.myItemObjects.RemoveAt(2);
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = false;
			itemGoesToThisSpot = (Vector2) startPosition;
			
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
