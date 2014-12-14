using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum GAME_STATE {NONE, LEVEL_START, RED_ARROW_OUT, MAINCHAR_ACTIVE, CHAIN_REACTION, LEVEL_END};

public class LevelManager : MonoBehaviour {

	public GAME_STATE myGameState;

	//add these in inspector
	public List<Character> charsInLevel; 
	public List<QueueScript1> myQObjs;

	void Start(){

	}
	
	public void setGameState(GAME_STATE myGam ){
		myGameState = myGam;
	}

	public GAME_STATE getGameState(){
		return myGameState;
	}

	public void sortAllQueuesInLevel(){
		foreach(QueueScript1 qScript in myQObjs){
			qScript.displayNewQueueVisualFromOwnerQueueList();
		}
	}


}
