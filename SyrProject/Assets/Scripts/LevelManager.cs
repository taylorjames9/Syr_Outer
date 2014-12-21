using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GAME_STATE {NONE, LEVEL_START, RED_ARROW_OUT, MAINCHAR_ACTIVE, CHAIN_REACTION, LEVEL_END};

public class LevelManager : MonoBehaviour {

	public GAME_STATE myGameState;

	//add these in inspector
	public List<Character> charsInLevel; 
	public List<Character> eliminateThese;
	public List<Character> photoThese;
	public List<QueueScript1> myQObjs;

	public static bool bDeathInLevel;
	public static int liabilityCounter;
	public int numGoalsThisLevel;
	public RectTransform panelRectTransform;
	public Text howdIDo;


	void Start(){
		liabilityCounter = 0;
		panelRectTransform.gameObject.SetActive(false);
	}

	void Update(){
		if(bDeathInLevel){
			Debug.Log ("bDeathinLevel");
			foreach(Character character in charsInLevel){
				Debug.Log ("foreach loop");
				if(!character.getDead() && character.getLiability()){
					Debug.Log ("SettingLiability to true");
					character.setLiability(true);
					liabilityCounter++;
				}
			}
			//checkGameOver();
			checkWin();
			bDeathInLevel = false;
		}
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

	//check if game over
	//check if win/lose

//	public bool checkGameOver(){
//		//eliminateThese.Count ==
//		
//	}

	public bool checkWin(){
		Debug.Log ("CHECKING WIIIN");
		int satisfyGoalsList = 0;
		foreach(Character elimTarget in eliminateThese){
			if(elimTarget.getDead()){
				Debug.Log ("THAT'S ONE TARGET DOWN");
				continue;
			}
			else{
				panelRectTransform.gameObject.SetActive(true);
				howdIDo.text = "LEVEL STATUS: FAILED \n\nOBJECTIVE NOT COMPLETE";
				return false;
			}
		}
		satisfyGoalsList++;
		Debug.Log("I HAVE COMPLETED THIS MANY GOALS"+ satisfyGoalsList);
		/*foreach(Character photoTarget in photoThese){
			if(!photoTarget.getPhotoed()){
				return false;
			}
		}*/
		//satisfyGoalsList++;
		if(liabilityCounter == 0){
			satisfyGoalsList++;
		}
		else{
			//Debug.Log("LEVEL STATUS: FAILED \nCAUSE: OUTSTANDING LIABILITIES");
			panelRectTransform.gameObject.SetActive(true);
			howdIDo.text = "LEVEL STATUS: FAILED \n\nCAUSE: OUTSTANDING LIABILITIES";
			return false;
		}

		if(satisfyGoalsList >= numGoalsThisLevel){
			//Debug.Log("LEVEL STATUS: PASS \n\nALL GOALS COMPLETE");
			panelRectTransform.gameObject.SetActive(true);
			howdIDo.text = "LEVEL STATUS:\nPASS\n\nALL GOALS COMPLETE";
			return true;
		}
		else{
			//Debug.Log("LEVEL STATUS: FAILED \nCAUSE: \nNOT ALL GOALS COMPLETE");
			panelRectTransform.gameObject.SetActive(true);
			howdIDo.text = "LEVEL STATUS: FAILED \n\nCAUSE: NOT ALL GOALS COMPLETE";
			return false;
		}
	}
}
