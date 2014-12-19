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
			Debug.Log (this+" In start position = "+ inStartPosition());
			if(myCurrTarget != null){
				sicTarget(myCurrTarget.transform);
			}
			if(iAmDead){
				Debug.Log ("I am DEAD");
				switchAnim(anim, 3);
			}

			break;
		case GAME_STATE.LEVEL_END:
			
			break;
		default:
			break;
		}
	}

	public bool OnMouseDown(){
		if (levelManScript.getGameState() == GAME_STATE.NONE) {
			myQueueOBJ.SetActive (true);
		} else if (levelManScript.getGameState() == GAME_STATE.RED_ARROW_OUT) {
			activeMainPlayerOBJ = GameObject.FindGameObjectWithTag ("ActiveMain");
			activeMainPlayerScript = activeMainPlayerOBJ.GetComponent <MainChar>();
			activeMainPlayerScript.rotateArrow (this);
			activeMainPlayerScript.setTargetUnderConsideration(this);
		}
		return true;
	}
}
