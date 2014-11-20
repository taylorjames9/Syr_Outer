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
	public override void Start(){
		base.Start();
	}

	void Update(){
		
		switch(levelManScript.getGameState()){
		case GAME_STATE.NONE:
			
			break;
		case GAME_STATE.LEVEL_START:
			
			break;
		case GAME_STATE.RED_ARROW_OUT:
			
			break;
		case GAME_STATE.MAINCHAR_ACTIVE:

			break;
		case GAME_STATE.CHAIN_REACTION:
			//if myTarget not null
				//sicTarget


			break;
		case GAME_STATE.LEVEL_END:
			
			break;
		default:
			break;
		}
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
		reactToGetHit(myAssailant.GetComponentInChildren<QueueScript1>().myItemObjects[0]);
		other.GetComponent<Character>().dropItem();
	}

//	public void iGotHit(Item_Set item0){
////		if(item0.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
////			Debug.Log ("NonMain drops dead");
////		} else if(item0.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
////			Debug.Log ("NonMain Set Target");
////		}
	//}

	public void setMyAssailant(Character assailor){
		myAssailant = assailor;
	}

	public void setTarget(Character target){

	}
	

}
