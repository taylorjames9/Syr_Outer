using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NonMainChar : Character {


	//These will appear in inspector because they are part of the Character parent class
	//	*public enum MYCOLOR {Null, Blue, Yellow, Orange, Purple, Red, Black, Green, White, Aqua, Beige};
	//	*public Texture2D myTexture;
	//	*public GameObject myQueueOBJ;

	private Vector2 myStartPosition;

	private List<Item> myCurrentItems = new List<Item>();

	//myCurrentItems.addRange.findObjectsOfType<Item>();

	private Character myAssailant;
	private bool attacking = false;
	private List<Character> myTargetList = new List<Character>();
	private Character myCurrTarget;
	private int tapOnMeCounter;

	private GameObject levelManagerOBJ;
	private LevelManager levelManScript;

	private GameObject activeMainPlayerOBJ; 
	private MainChar activeMainPlayerScript;

	// Use this for initialization
	void Start () {

		levelManagerOBJ = GameObject.Find("LevelManager_OBJ");
		levelManScript = levelManagerOBJ.GetComponent <LevelManager>();

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
}
