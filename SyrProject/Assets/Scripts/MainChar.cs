﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainChar : Character {
	
	public GameObject myArrow;
	private bool isConsideringTarget;
	private Character targetUnderConsideration;
	private bool isActingAsMain = true;
	private int randomNumForThisLevel;

	public override void Start(){
		base.Start();
		anim.SetInteger("MainInt", 0); 
		myArrow.SetActive (false);
		Debug.Log ("Random ass count "+levelManScript.charsInLevel.Count());
		randomNumForThisLevel = Random.Range (1, levelManScript.charsInLevel.Count());
		Debug.Log("Random num = "+randomNumForThisLevel);
		targetUnderConsideration = levelManScript.charsInLevel[randomNumForThisLevel];
	}

	void Update(){

		switch(levelManScript.getGameState()){
		case GAME_STATE.NONE:
				Debug.Log("IN GameState NONE");
			break;
		case GAME_STATE.LEVEL_START:

			Debug.Log("IN LEVEL STARTOOOOOO");

			break;
		case GAME_STATE.RED_ARROW_OUT:

			break;
		case GAME_STATE.MAINCHAR_ACTIVE:
			//sicTarget (getTarget ().transform);
			break;
		case GAME_STATE.CHAIN_REACTION:
			Debug.Log ("My curr target is: "+getTarget());
			if(getTarget() != null && myQueue_Script.myItemObjects.Count > 0){
				switchAnim(anim, 1);
				sicTarget(getTarget().transform);
			}
			else if(myQueue_Script.myItemObjects.Count <= 0 && !inStartPosition()){
				walkBackToStartPosition(myStartPosition, 1.0f);
			}
			else if(iAmDead){
				Debug.Log ("I am DEAD");
				myQueueOBJ.SetActive(false);
			}
///////////
			if(inStartPosition() && allCharactersAreStationaryCheck()){
				tapOnMeCounter = 0;
				setTargetUnderConsideration(levelManScript.charsInLevel[randomNumForThisLevel]);
				setTarget(getTargetUnderConsideration());
				levelManScript.setGameState(GAME_STATE.RED_ARROW_OUT);
				arrived = false;
				//levelManScript.setGameState(GAME_STATE.LEVEL_START);
			}

			break;
		case GAME_STATE.LEVEL_END:
			
			break;
		default:
			break;
		}
	}
	
	void OnMouseDown(){
		setTapOnMeCounter(1);
		myQueueOBJ.SetActive (true);
		if (tapOnMeCounter > 1) {
			myArrow.SetActive (true);
			/*
			 *Regarding the line below. When setting the Character objects in the inspector, always
			 *place the first one, first. 
			 * 
			 */
			rotateArrow(levelManScript.charsInLevel[randomNumForThisLevel]);
			levelManScript.setGameState(GAME_STATE.RED_ARROW_OUT); 
			gameObject.tag="ActiveMain";
		} else if (tapOnMeCounter > 2) {
			myArrow.SetActive (false);
			tapOnMeCounter = 0;
		}
	}

	public void rotateArrow (Character char1){
		Vector3 dir = char1.transform.position - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		myArrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void hideArrow(){
		//myArrow.setActive(false)
	}

	public void toggleMain(){
		isActingAsMain = !isActingAsMain;
	}

	public void setMainTarget(Character chr){
		myCurrTarget = chr;
	}

	public void clearMainTarget(){
		myCurrTarget = null;
	}

	public void rearrangeQueue(Item item){
		//if item.owner != this.gameObject.tag
			//add new item to Queue at location where it is touching collider
			//displayQueueFromQueueList();
		//if item.owner.equals(this.gameObject.tag)
			//transfer item to Queue at location where it is touching collider
			//displayQueueFromQueueList();
	}
	public void setTargetUnderConsideration(Character chr){
		targetUnderConsideration = chr;
	}

	public Character getTargetUnderConsideration(){
		return targetUnderConsideration;
	}
	public int getTapOnMeCounter(){
		return tapOnMeCounter;
	}
	public void setTapOnMeCounter(int addTap){
		tapOnMeCounter += addTap;
	}


}
