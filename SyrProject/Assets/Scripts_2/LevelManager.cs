using UnityEngine;
using System.Collections;

public enum GAME_STATE {NONE, RED_ARROW_OUT, MAINCHAR_ACTIVE};

public class LevelManager : MonoBehaviour {

	public GAME_STATE myGameState;
	
	public void setGameState(GAME_STATE myGam ){
		myGameState = myGam;
	}

	public GAME_STATE getGameState(){
		return myGameState;
	}
}
