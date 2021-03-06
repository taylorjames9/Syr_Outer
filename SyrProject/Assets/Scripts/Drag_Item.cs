﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]

public class Drag_Item : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector2 startPosition;
	private bool touchingWhereIWantToBe;
	private Vector2 itemGoesToThisSpot;
	private bool iAmBeingMoved;
	private bool removedFromOrigSpot;
	private int positionICameFrom;

	GameObject levelManOBJ;
	LevelManager levelManScript;
	public static int tapOnSyringeCounter;

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
		}
		else if(coll.gameObject.name == "Orange_Spot2"){
			Debug.Log("TOUCHING ORANGE SPOT 2");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			if(orangeQueueScript.myItemObjects.Count > 0){
				Debug.Log ("GOING INTO ORANGE SPT 2");
				orangeQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) coll.transform.position;
			} else if (orangeQueueScript.myItemObjects.Count == 0){
				orangeQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) orangeQueueScript.myQSpots[0].transform.position;
			}
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
		}
		else if(coll.gameObject.name == "Orange_Spot3"){
			Debug.Log("TOUCHING ORANGE SPOT 3");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			if(orangeQueueScript.myItemObjects.Count >= 2){
				orangeQueueScript.myItemObjects.Insert(2, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) coll.transform.position;
			} 
			else if(orangeQueueScript.myItemObjects.Count == 1){
				orangeQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) orangeQueueScript.myQSpots[1].transform.position;
			}
			else{
				orangeQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) orangeQueueScript.myQSpots[0].transform.position;
			}
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
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
			if(blueQueueScript.myItemObjects.Count > 0){
				Debug.Log ("GOING INTO BLUE SPT 2");
				blueQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) coll.transform.position;
			} else {
				blueQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) blueQueueScript.myQSpots[0].transform.position;
			}
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
			
		}
		else if(coll.gameObject.name == "Blue_Spot3"){
			Debug.Log("TOUCHING Blue SPOT 3");
			QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			if(blueQueueScript.myItemObjects.Count >= 2){
				blueQueueScript.myItemObjects.Insert(2, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) coll.transform.position;
			} 
			else if(blueQueueScript.myItemObjects.Count == 1){
				blueQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) blueQueueScript.myQSpots[1].transform.position;

			}
			else{
				blueQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) blueQueueScript.myQSpots[0].transform.position;
			}
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
			
		}
		else if(coll.gameObject.name == "Green_Spot1"){
			Debug.Log("TOUCHING green SPOT 1");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			greenQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
			itemGoesToThisSpot = (Vector2) coll.transform.position;
		}
		else if(coll.gameObject.name == "Green_Spot2"){
			Debug.Log("TOUCHING green SPOT 2");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			itemGoesToThisSpot = (Vector2) startPosition;
			if(greenQueueScript.myItemObjects.Count > 0){
				Debug.Log ("GOING INTO GREEN SPT 2");
				greenQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) coll.transform.position;
			} else {
				greenQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) greenQueueScript.myQSpots[0].transform.position;
			}
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
		}
		else if(coll.gameObject.name == "Green_Spot3"){
			Debug.Log("TOUCHING green SPOT 3");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			itemGoesToThisSpot = (Vector2) startPosition;
			if(greenQueueScript.myItemObjects.Count >= 2){
				greenQueueScript.myItemObjects.Insert(2, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) coll.transform.position;
			} 
			else if(greenQueueScript.myItemObjects.Count == 1){
				greenQueueScript.myItemObjects.Insert(1, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) greenQueueScript.myQSpots[1].transform.position;
			}
			else{
				greenQueueScript.myItemObjects.Insert(0, this.GetComponent<Item_Set>());
				itemGoesToThisSpot = (Vector2) greenQueueScript.myQSpots[0].transform.position;
			}
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			touchingWhereIWantToBe = true;
		}

	}

	public void removePreview(Collider2D coll){

		itemGoesToThisSpot = (Vector2) startPosition;

		if(coll.gameObject.name == "Orange_Spot1"){
			Debug.Log("Removing from ORANGE SPOT 1");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
		}
		else if(coll.gameObject.name == "Orange_Spot2" ){
			Debug.Log("Removing from ORANGE SPOT 2!!!!");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
		}
		else if(coll.gameObject.name == "Orange_Spot3" ){
			Debug.Log("Removing from ORANGE SPOT 3");
			QueueScript1 orangeQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			orangeQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			orangeQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
			
		}
		else if(coll.gameObject.name == "Blue_Spot1" ){
			Debug.Log("removing from Blue SPOT 1");
			QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			blueQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
			
		}
		else if(coll.gameObject.name == "Blue_Spot2"){
			Debug.Log("Removing from Blue SPOT 2");
			QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			blueQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
			
		}
		else if(coll.gameObject.name == "Blue_Spot3" ){
			Debug.Log("Removing From Blue SPOT 3");
			QueueScript1 blueQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			blueQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			blueQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
			
		}
		else if(coll.gameObject.name == "Green_Spot1" ){
			Debug.Log("Removing from green SPOT 1");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			greenQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
			
		}
		else if(coll.gameObject.name == "Green_Spot2"){
			Debug.Log("Removing from green SPOT 2");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			greenQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
		}
		else if(coll.gameObject.name == "Green_Spot3"){
			Debug.Log("Removing from green SPOT 3");
			QueueScript1 greenQueueScript = coll.GetComponentInParent<QueueScript1>(); 
			greenQueueScript.myItemObjects.Remove((Item_Set) this.GetComponent<Item_Set>());
			greenQueueScript.displayNewQueueVisualFromOwnerQueueList();
			itemGoesToThisSpot = (Vector2) startPosition;
			touchingWhereIWantToBe = false;
		}
	}

	
	void OnMouseDown()
	{
		QueueScript1 myQueueScript = GetComponentInParent<QueueScript1>();
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		positionICameFrom = myQueueScript.myItemObjects.IndexOf((Item_Set) this.GetComponent<Item_Set>());

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
			//for Tutorial
			tapOnSyringeCounter++;
		}
		else{
			QueueScript1 myQueueScript = GetComponentInParent<QueueScript1>();
			myQueueScript.myItemObjects.Insert(positionICameFrom, this.GetComponent<Item_Set>());
			myQueueScript.displayNewQueueVisualFromOwnerQueueList();
			transform.position = (Vector2) startPosition;
		}
	}

	public void setTouchingWhereIWantToBe(bool tf){
		if(tf){
			touchingWhereIWantToBe = true;
		}
		else
			touchingWhereIWantToBe = false;
	}
}
