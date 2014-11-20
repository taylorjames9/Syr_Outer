using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NonMainChar : Character {
	
	//These will appear in inspector because they are part of the Character parent class
	//	*public enum MYCOLOR {Null, Blue, Yellow, Orange, Purple, Red, Black, Green, White, Aqua, Beige};
	//	*public Texture2D myTexture;
	//	*public GameObject myQueueOBJ;

	//private Vector2 myStartPosition;

	//private List<Item> myCurrentItems = new List<Item>();
	//private Character myAssailant;
	//private bool attacking = false;
	//private List<Character> myTargetList = new List<Character>();
	//private Character myCurrTarget;
	//private int tapOnMeCounter;

	//private GameObject levelManagerOBJ;
	//private LevelManager levelManScript;

	private GameObject activeMainPlayerOBJ; 
	private MainChar activeMainPlayerScript;

	// Use this for initialization
	void Start () {

		levelManagerOBJ = GameObject.Find("LevelManager_OBJ");
		levelManScript = levelManagerOBJ.GetComponent <LevelManager>();

	}

	void OnMouseDown(){
		if (levelManScript.getGameState() == GAME_STATE.NONE) {
			myQueueOBJ.SetActive (true);
		} else if (levelManScript.getGameState() == GAME_STATE.RED_ARROW_OUT) {
			//Call main player arrow rotate method
			activeMainPlayerOBJ = GameObject.FindGameObjectWithTag ("ActiveMain");
			activeMainPlayerScript = activeMainPlayerOBJ.GetComponent <MainChar>();

			activeMainPlayerScript.rotateArrow (this);
			Debug.Log ("Print this : " + this);
			activeMainPlayerScript.mainSetTarget (this);
			Debug.Log("Current target is "+activeMainPlayerScript.getTarget());
		}
	}
	
	void OnTriggerEnter2D(Collider2D  other){
		iGotHit(myAssailant.GetComponentInChildren<QueueScript1>().myItemObjects[0]);
		other.GetComponent<Character>().dropObject();
	}

	public void iGotHit(Item_Set item0){
		//if syringe type is black 
			//then I die

		//else if syringe type is color
		    //set new target

		if(item0.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
			Debug.Log ("NonMain drops dead");
		} else if(item0.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
			Debug.Log ("NonMain Set Target");
		}

		/*if(item0.paramet.itemFunction == itemType.ITEM_FUNCTION.DEATH){
			//dropDead
			Debug.Log ("NonMain drops dead");
		}

		else if(item0.paramet.itemFunction == itemType.ITEM_FUNCTION.SETTARGET){
			Debug.Log ("NonMain Set Target");
		}*/

	}

	public void dropObject(){

	}

	public void setMyAssailant(Character assailor){
		myAssailant = assailor;
	}

	public void setTarget(Character target){

	}
	

}
