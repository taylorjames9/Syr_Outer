using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainChar : Character {

	//These will appear in inspector because they are part of the Character parent class
//	*public enum MYCOLOR {Null, Blue, Yellow, Orange, Purple, Red, Black, Green, White, Aqua, Beige};
//	*public Texture2D myTexture;
//	*public GameObject myQueueOBJ;

	public GameObject myArrow;

	private bool isConsideringTarget;
	private Character targetUnderConsideration;
	private Character myCurrTarget;
	private Vector2 myStartPosition;
	private bool isActingAsMain = true;
	private List<Transform> myCurrentItems = new List<Transform>();
	private Character myAssailant;
	private bool attacking = false;
	private List<Character> myTargetList = new List<Character>();

	private int tapOnMeCounter;

	private GameObject myItem1;

	private GameObject levelManagerOBJ;
	private LevelManager levelManScript;


	void Start(){
		myArrow.SetActive (false);
		levelManagerOBJ = GameObject.Find("LevelManager_OBJ");
		levelManScript = levelManagerOBJ.GetComponent <LevelManager>();
		Debug.Log ("levelManScript " + levelManScript);


	}

	void Update(){

		switch(levelManScript.getGameState()){
		case GAME_STATE.NONE:

			break;
		case GAME_STATE.RED_ARROW_OUT:

			break;
		case GAME_STATE.MAINCHAR_ACTIVE:
			//hide red arrow
			//hide queue
			walkToTarget (getTarget ().transform);
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
			levelManScript.setGameState(GAME_STATE.RED_ARROW_OUT); 
			gameObject.tag="ActiveMain";
		} else if (tapOnMeCounter > 3) {
			myArrow.SetActive (false);
		}
	}


	public List<Transform> getItemsFromMyInternalQueue(){
		return myCurrentItems;

	}

	void OnTriggerEnter2D(Collider2D  other) {
		//if other's target is me...
			//wasStabbed()
			//setTarget()
			//walkToTarget()
			//stabTarget()
			//clearObjectFromQueueAfterUse( )
			//stayInKillSpot( ) or walkBackToStartPosition()
			

		//if myTarget is other && attacking is true
			//stabTarget()
			//clearObjectFromQueueAfterUse( )
			//stayInKillSpot( ) or walkBackToStartPosition()
	}


	public void displayQueue (){
		//myQueue.sectActive(true)
	}

	public void hideQueue(){
		//myQueue.sectActive(false)
	}

	public void displayArrow(){
		//myArrow.setActive(true)
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

	public void rearrangeQueue(Item item){
		//if item.owner != this.gameObject.tag
			//add new item to Queue at location where it is touching collider
			//displayQueueFromQueueList();
		//if item.owner.equals(this.gameObject.tag)
			//transfer item to Queue at location where it is touching collider
			//displayQueueFromQueueList();
	}

	public void mainSetTarget(Character char1){
			myCurrTarget = char1;
	}

	public Character getTarget (){
		return myCurrTarget;
	}

	public void executeInstructions(){
		//this function could be used to contain a series of instructions for going up to a person, effecting, clearingQueue etc
	}

	public void walkToTarget(Transform targetCharacter){
		transform.position = Vector2.MoveTowards(this.transform.position, targetCharacter.position, 0.02f);
		//play walk animation
	}

	public void stabTarget(){
		//play animation

	}

	public void walkBackToStartPosition(Vector2 startPosition){
		//turn to face origin position
		//transform.position = Vector2.MoveTowards(transform.position, target, 0.02f);
		//play walk animation
	}

	public void stayInKillSpot( ){
		//do nothing
	}

	public void clearObjectFromQueueAfterUse( ){
		//myCurrentItems.RemoveAt(0);
	}

	public void wasStabbed( ){
		//play animation

	}
}
