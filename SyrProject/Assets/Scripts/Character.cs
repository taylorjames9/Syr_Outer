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
	public void hitTarget(Character chr, Item Item_Set){ }
	public void dropItem(){
		myQueue_Script.myItemObjects.RemoveAt(0);
	}
	public void reactToGetHit (Item_Set item){ 
		if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
			Debug.Log ("Victim drops dead");
			setDead(true);
			switchAnim(anim, 3);
			LevelManager.bDeathInLevel = true;
		} 
		else if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
			//if the thing that I go hit with is not my color. 
			Debug.Log ("I JUST GOT STUCK WITH A SYRINGE TO SET TARGET");
			if (!item.paramet.itemColor.ToString().Equals(charParamet.myColor.ToString())){
				setTarget(item.paramet.itemColor);
				arrived = false;
				setAttacking(true);
			}
		}
	}
	public void sicTarget(Transform sicTarget){
		Debug.Log("INSIDE OF SIC TARGET");
		switchAnim(anim, 1);
		if(!arrived && myQueue_Script.myItemObjects.Count > 0){
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
								Debug.Log ("WE ARE CURRENTLY INSIDE TRIGGER");
								myCurrTarget = null;
								walkBackToStartPosition (myStartPosition);
								switchAnim (anim, 2);
								setAttacking (false);
								other.gameObject.GetComponent<Character> ().reactToGetHit (myQueue_Script.myItemObjects [0]);
								//removeUsedItem from queue
								//rearrange queue
								myQueue_Script.removeUsedObjectFromOwnerQueue (); 
								myQueue_Script.displayNewQueueVisualFromOwnerQueueList ();
								setLiability (false);
						}
				}
		}

	public void walkBackToStartPosition(Vector2 startPosition){
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
		}
		else
			return false; 
	}


}
