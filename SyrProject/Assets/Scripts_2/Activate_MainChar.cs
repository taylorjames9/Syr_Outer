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

		activeMainPlayerScript.mainSetTarget (activeMainPlayerScript.getTarget());

		levelManScript.setGameState (GAME_STATE.MAINCHAR_ACTIVE);
	}

}
