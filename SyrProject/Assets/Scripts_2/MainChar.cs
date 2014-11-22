using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainChar : Character {
	
	public GameObject myArrow;
	private bool isConsideringTarget;
	private Character targetUnderConsideration;
	private bool isActingAsMain = true;
	//public List<Character> allCharsInScene = new List<Character>();
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

			break;
		case GAME_STATE.LEVEL_START:
			
			break;
		case GAME_STATE.RED_ARROW_OUT:

			break;
		case GAME_STATE.MAINCHAR_ACTIVE:
			sicTarget (getTarget ().transform, myQueue_Script.myItemObjects[0]);
			break;
		case GAME_STATE.CHAIN_REACTION:
			if(myCurrTarget != null){
				sicTarget(myCurrTarget.transform, myQueue_Script.myItemObjects[0]);
			}
			if(!attacking && (Vector2)transform.position != myStartPosition){
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
		tapOnMeCounter++;
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
		} else if (tapOnMeCounter > 3) {
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

}
