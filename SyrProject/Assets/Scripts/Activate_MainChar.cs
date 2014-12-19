using UnityEngine;
using System.Collections;

public class Activate_MainChar : MonoBehaviour {


	private GameObject activeMainPlayerOBJ;
	private MainChar activeMainPlayerScript;

	private GameObject levelManagerOBJ;
	private LevelManager levelManScript;

	void Start(){
		levelManagerOBJ = GameObject.Find("LevelManager_OBJ");
		levelManScript = levelManagerOBJ.GetComponent <LevelManager>();
	}

	void OnMouseDown(){
		activeMainPlayerOBJ = GameObject.FindGameObjectWithTag ("ActiveMain");
		activeMainPlayerScript = activeMainPlayerOBJ.GetComponent <MainChar>();
		//GameObject qObject = activeMainPlayerOBJ.
		QueueScript1 qScript = activeMainPlayerOBJ.GetComponentInChildren<QueueScript1>();
		if(qScript.myItemObjects.Count >0){
			activeMainPlayerScript.setMainTarget (activeMainPlayerScript.getTargetUnderConsideration());
			activeMainPlayerScript.getTargetUnderConsideration().setAssailant(activeMainPlayerScript);
			activeMainPlayerScript.setAttacking(true);
			activeMainPlayerScript.myArrow.SetActive(false);
			//uncomment the code below to hide all character queues when character first starts moving
			/*activeMainPlayerScript.myQueueOBJ.SetActive(false);
			foreach(Character chr in levelManScript.charsInLevel){
				chr.myQueueOBJ.SetActive(false);
			}*/
			levelManScript.setGameState(GAME_STATE.MAINCHAR_ACTIVE);
		}
	}

}
