using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NonMainChar : Character {

	private GameObject activeMainPlayerOBJ; 
	private MainChar activeMainPlayerScript;

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
			Debug.Log ("GAME SATE IN CHAIN REACTION");
			Debug.Log ("myCurrTarget ="+myCurrTarget);
			if(myCurrTarget != null){
				Debug.Log ("SICCING TARGET");
				sicTarget(myCurrTarget.transform, myQueue_Script.myItemObjects[0]);
			}
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
		//if(other.gameObject.name == myCurrTarget.name ||other.gameObject.name == myAssailant.name){
			reactToGetHit(myAssailant.GetComponentInChildren<QueueScript1>().myItemObjects[0]);
			other.GetComponent<Character>().dropItem();
		//}
	}

}
