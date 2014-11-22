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

		Debug.Log ("My character is: "+this.charParamet.myColor+ " and my attacking status is: "+getAttacking());

		
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
			if(myCurrTarget != null){
				sicTarget(myCurrTarget.transform, myQueue_Script.myItemObjects[0]);
			}
			if(!attacking && (Vector2) transform.position != myStartPosition){
				walkBackToStartPosition(myStartPosition);
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
			activeMainPlayerOBJ = GameObject.FindGameObjectWithTag ("ActiveMain");
			activeMainPlayerScript = activeMainPlayerOBJ.GetComponent <MainChar>();
			activeMainPlayerScript.rotateArrow (this);
			activeMainPlayerScript.setTargetUnderConsideration(this);
		}
	}
}
