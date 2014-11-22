using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class charParams
{
	public enum CHARACTER_COLOR {NULL, BLUE, YELLOW, ORANGE, PURPLE, RED, BLACK, GREEN, WHITE, AQUA, BEIGE};
	public enum TARGET_TYPE {None, BlackStabOnce, BlackStabTwice, Suicide, CockTail, BlackShootOnce, BlackShootTwice, Forget, Picture, Love, Inception, Implicate, Crazy, DoubleInception, Empty};
	public enum RESILIENCE {None, ColorSyringe, BlackSyringe, Photo, Forget, Inception, GunShot, Pill, Love, Crazy, Empty};
	public CHARACTER_COLOR myColor;
	public TARGET_TYPE targetType;
	public RESILIENCE myResilience;
}

public abstract class Character : MonoBehaviour {

	public charParams charParamet;
	
	public GameObject myQueueOBJ;
	protected QueueScript1 myQueue_Script;
	public enum FACINGDIR {UP, DOWN, LEFT, RIGHT};
	protected Character myCurrTarget;
	protected Vector2 myStartPosition;
	//protected 
	protected List<Transform> myCurrentItems = new List<Transform>();
	protected Character myAssailant;
	protected List<Character> myTargetList = new List<Character>();
	protected GameObject levelManagerOBJ;
	protected LevelManager levelManScript;
	protected int tapOnMeCounter;
	protected bool attacking = false;
	protected Item_Set itemToUse;
	protected bool arrived;

	protected Animator anim;

	public virtual void Start(){
		myStartPosition = new Vector2(this.transform.position.x, this.transform.position.y);
		Debug.Log ("Set everyone's positions.");
		anim = GetComponent<Animator>();
		levelManagerOBJ = GameObject.Find("LevelManager_OBJ");
		levelManScript = levelManagerOBJ.GetComponent <LevelManager>();
		myQueue_Script = myQueueOBJ.GetComponent<QueueScript1>();
	}



	public void setAssailant(Character assailor){ 
		myAssailant = assailor;
	}
	public Character getAssailant(){ 
		return myAssailant;
	}
	
	public Character getTarget(){
		return myCurrTarget;
		
	}
	public void setAttacking (bool tf){
		if(tf){
			attacking = true; 
			this.collider2D.isTrigger = true;

		}
		else{
			attacking = false;
			this.collider2D.isTrigger = false;

		}
	}

	public bool getAttacking(){
		return attacking;
	}


	public void setTarget(ItemParams.ITEM_COLOR clr){ 
		Debug.Log ("INSIDE OF SET TARGET");
		List<Character> chrsInLev = levelManScript.charsInLevel;
		foreach(Character chr in chrsInLev){
			if(chr.charParamet.myColor.ToString () == clr.ToString()){
				Debug.Log ("FOUND A MATCH _ SETTING TARGET");
				myCurrTarget = chr;
				myCurrTarget.GetComponent<Character>().setAssailant(this);
				Debug.Log (" !!!!!!!!  My name is "+gameObject.name+" and my assailant is: "+getAssailant());
				//Debug.Log ("myCurrTarget 1111= "+myCurrTarget);
			}
			//else
				//myCurrTarget = null;
		}
	}
	public void hitTarget(Character chr, Item Item_Set){ }
	public void dropItem(){
		myQueue_Script.myItemObjects.RemoveAt(0);
	
	}
	public void reactToGetHit (Item_Set item){ 
		Debug.Log ("SYRINGE ITEM to REACt TO IS: "+item);
		Debug.Log ("Someone should be reacting to getting hit");
		if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
			Debug.Log ("Victim drops dead");
			arrived = false;
		} 
		else if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
			Debug.Log ("THE FUCNTION OF THE SYRINGE IS SET TARGET");
			Debug.Log ("My name is "+gameObject.name+" and I just got hit with a set target SYRINGE");
			Debug.Log ("Color of syringe that I got hit with is: "+item.paramet.itemColor);
			setTarget(item.paramet.itemColor);
			arrived = false;
			setAttacking(true);
		}
	}
	public void sicTarget(Transform sicTarget, Item_Set item){
		if(!arrived ){
			switchAnim(anim, 1);
			transform.position = Vector2.MoveTowards(this.transform.position, sicTarget.position, 0.02f);
		}
		else if(arrived && getAttacking()){
				switchAnim(anim, 2);
		}
	}  //this can be walk to or aim
	public void hitTarget(){ }
	public void returnToOrigPosition( ){ }
	public void setLiability (bool lia) { }
	public void switchAnim(Animator anim0, int anim_state){
		anim0.SetInteger("MainInt", anim_state);
	}
	
	public virtual void OnTriggerEnter2D(Collider2D  other){
		Debug.Log ("Inside TRIGGER. This message should appear twice");
		if (getAttacking()){
			if( other.name == myCurrTarget.name && levelManScript.myGameState == GAME_STATE.MAINCHAR_ACTIVE ){
				Debug.Log ("WHERE WE WANNA BE");
				levelManScript.setGameState(GAME_STATE.CHAIN_REACTION);
				Debug.Log ("game state switched to chain reaction");
				walkBackToStartPosition(myStartPosition);
				switchAnim(anim, 2);	
				arrived = true;
				setAttacking(false); /******    ****/
			}
			else if (other.name == myCurrTarget.name && levelManScript.myGameState == GAME_STATE.CHAIN_REACTION){				arrived = true;
				walkBackToStartPosition(myStartPosition);
				arrived = true;
				setAttacking(false);  /******    ****/
			}
		}
		else if (!getAttacking()){
			Debug.Log ("BACKAKAKAKAKAKA");
			Debug.Log ("other name ="+other.name);
			Debug.Log("myAssailantName ="+myAssailant.name);
			if (other.name == myAssailant.name){
				Debug.Log ("BINGO");
				reactToGetHit(myAssailant.myQueue_Script.myItemObjects[0]);
			}
		}
	}

	public void walkBackToStartPosition(Vector2 startPosition){
		//setAttacking(false);
		transform.position = Vector2.MoveTowards(this.transform.position, startPosition, 0.02f);
	}
}
