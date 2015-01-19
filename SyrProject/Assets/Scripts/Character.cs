﻿using UnityEngine;
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
	public enum FACINGDIR {UP, DOWN, LEFT, RIGHT};

	protected QueueScript1 myQueue_Script;
	protected Character myCurrTarget;
	protected Vector2 myStartPosition;
	protected List<Transform> myCurrentItems = new List<Transform>();
	protected Character myAssailant;
	protected List<Character> myTargetList = new List<Character>();
	protected GameObject levelManagerOBJ;
	protected LevelManager levelManScript;
	protected int tapOnMeCounter;
	protected bool attacking = false;
	protected Item_Set itemToUse;
	protected bool arrived;
	protected bool iAmDead; 
	protected bool potentialLiability;
	protected bool stabBackON;

	protected Animator anim;

	public virtual void Start(){
		myStartPosition = new Vector2(this.transform.position.x, this.transform.position.y);
		anim = GetComponent<Animator>();
		levelManagerOBJ = GameObject.Find("LevelManager_OBJ");
		levelManScript = levelManagerOBJ.GetComponent <LevelManager>();
		myQueue_Script = myQueueOBJ.GetComponent<QueueScript1>();
		potentialLiability = true;
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
		List<Character> chrsInLev = levelManScript.charsInLevel;
		foreach(Character chr in chrsInLev){
			if(chr.charParamet.myColor.ToString () == clr.ToString()){
				myCurrTarget = chr;
				myCurrTarget.GetComponent<Character>().setAssailant(this);
			}
		}
	}

	public void setTarget(Character chara){ 
		myCurrTarget = chara;
	}

	public void hitTarget(Character chr, Item Item_Set){ }
	public void dropItem(){
		myQueue_Script.myItemObjects.RemoveAt(0);
	}

	IEnumerator reactToGetHit (Collider2D origStabber, Item_Set item){ 

		Debug.Log ("INside of react to get hit");
		if(getStabBack()){
			Debug.Log ("WE ARE IN A TRUE STAB BACK");

			if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
				//Debug.Log ("HE who has stab back on SHOULD be dropping dead");
				setDead(true);
				switchAnim(anim, 3);
				LevelManager.bDeathInLevel = true;
			} 
			StartCoroutine(stabBack(origStabber, 1.5f));
//			else if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
//				//if the thing that I go hit with is not my color. 
//				Debug.Log ("I JUST GOT STUCK WITH A SYRINGE TO SET TARGET");
//				if (!item.paramet.itemColor.ToString().Equals(charParamet.myColor.ToString())){
//					setTarget(item.paramet.itemColor);
//					arrived = false;
//					setAttacking(true);
//				}
//			}
			yield return new WaitForSeconds(0.0f);
		}

		if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
			Debug.Log ("Person who got BACK stabbed droppps dead.");
			setDead(true);
			switchAnim(anim, 3);
			LevelManager.bDeathInLevel = true;
			yield return new WaitForSeconds(0.0f);
		} 
		else if(!stabBackON && item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
			//if the thing that I go hit with is not my color. 
			Debug.Log ("I JUST GOT STUCK WITH A SYRINGE TO SET TARGET");
			if (!item.paramet.itemColor.ToString().Equals(charParamet.myColor.ToString())){
				setTarget(item.paramet.itemColor);
				arrived = false;
				setAttacking(true);
			}
		}
		yield return new WaitForSeconds(0.0f);
	}
	public void sicTarget(Transform sicTarget){
		Debug.Log("INSIDE OF SIC TARGET");
		if(!arrived && myQueue_Script.myItemObjects.Count > 0){
			switchAnim(anim, 1);
			transform.position = Vector2.MoveTowards(this.transform.position, sicTarget.position, 0.02f);
		}
		else if(arrived && getAttacking()){

		}
	}  //this can be walk to or aim
	public void hitTarget(){ }
	public void returnToOrigPosition( ){ }
	public void setLiability (bool lia) { 
		potentialLiability = lia;
		if(lia){
			Debug.Log("Should be activating liability marker");
			Transform liabilityVisual = this.transform.FindChild("LiabilityMarkers");
			liabilityVisual.gameObject.SetActive(true);
			liabilityVisual.transform.renderer.enabled = true;
		}
	}
	public bool getLiability () { 
		return potentialLiability;
	}

	public void setDead(bool dead){
		iAmDead = dead;
		LevelManager.bDeathInLevel = true;
	}

	public bool getDead(){
		return iAmDead;
	}


	public void switchAnim(Animator anim0, int anim_state){
		anim0.SetInteger("MainInt", anim_state);
	}
	
	public virtual void OnTriggerEnter2D (Collider2D  other)
		{
			//if I am the attacker
			if (getAttacking ()) {
				if (other.name == myCurrTarget.name && levelManScript.myGameState == GAME_STATE.CHAIN_REACTION) {
						arrived = true;
						StartCoroutine (stabTarget (other));
						Debug.Log("iamDead = "+iAmDead);
						if(!iAmDead){
							StartCoroutine (walkBackToStartPosition (myStartPosition, 1.0f));
						}
						
						else if(iAmDead){
							Debug.Log ("INSIDE OF IAMDEAD IN TRIGGERENTER");
							switchAnim(anim, 0);
							//switchAnim(anim, 3);
						}
						myCurrTarget = null;
				//switchAnim (anim, );
				}
			}
		}

	IEnumerator stabTarget(Collider2D  other){

		Debug.Log("TRYING TO STAB THIS F'ING TARGET");
		switchAnim (anim, 2);
		myCurrTarget = null;
		setAttacking (false);
		StartCoroutine(other.gameObject.GetComponent<Character> ().reactToGetHit (this.gameObject.GetComponent<Collider2D>(), myQueue_Script.myItemObjects [0]));
		myQueue_Script.removeUsedObjectFromOwnerQueue (); 
		myQueue_Script.displayNewQueueVisualFromOwnerQueueList ();
		setLiability (false);
		Debug.Log("TRYING TO STAB THIS F'ING TARGET 222");
		yield return new WaitForSeconds(0.0f);
	}

	IEnumerator walkBackToStartPosition(Vector2 startPosition, float delay){
		yield return new WaitForSeconds(delay);
		this.transform.position = myStartPosition;
		if(inStartPosition()){
			switchAnim(anim, 0);
		}
	}

	public bool inStartPosition(){
		Debug.Log ("I "+this+" back in START POSITION");
		float dist = Vector3.Distance(transform.position, myStartPosition);
		if(dist <= 0.1){
			return true;
			if(allCharactersAreStationaryCheck()){
				Debug.Log("SHOULD BE BACK TO LEVEL START STATE");
				levelManScript.setGameState(GAME_STATE.LEVEL_START);
			}
		}
		else
			return false; 
	}

	public bool allCharactersAreStationaryCheck(){
		List<Character> allCharsInLevel = levelManScript.charsInLevel;
		foreach(Character character in allCharsInLevel){
			if(character.myCurrTarget != null){
				return false;
			}
		}
		return true;
	}

	public bool setStabBack(bool tf){
		if(tf){
			stabBackON = true;
			return true;
		}
		else{
			stabBackON = false;
			return false;
		}
	}

	public bool getStabBack(){
		return stabBackON;
	}

	IEnumerator stabBack(Collider2D origStabber, float stabBackDelay){
		yield return new WaitForSeconds(stabBackDelay);
		Debug.Log ("We are inside of stab back function.");
		switchAnim (anim, 2);
		setAttacking (false);
		StartCoroutine(origStabber.gameObject.GetComponent<Character> ().reactToGetHit ((Collider2D)this.GetComponent<Collider2D>(), myQueue_Script.myItemObjects [0]));
		myQueue_Script.removeUsedObjectFromOwnerQueue (); 
		myQueue_Script.displayNewQueueVisualFromOwnerQueueList ();
		setLiability (false);
		myCurrTarget = null;
		yield return new WaitForSeconds(stabBackDelay);
		switchAnim (anim, 0);
	}
}
