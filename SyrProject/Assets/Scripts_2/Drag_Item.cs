using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]

public class Drag_Item : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startPosition;

	void Start(){
		//StartCoroutine("getStartPosition");
		startPosition = transform.position;
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
		transform.position = startPosition;
	}

	IEnumerator getStartPosition(){
		Debug.Log("Before Waiting 1 seconds");
		yield return new WaitForSeconds(0);
		startPosition = transform.position;
		Debug.Log("After Waiting 1 seconds");


	}

	
}
