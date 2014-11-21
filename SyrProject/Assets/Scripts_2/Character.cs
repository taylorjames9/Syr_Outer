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
		}
		else
			attacking = false;
	}

	public bool getAttacking(){
		return attacking;
	}


	public void setTarget(ItemParams.ITEM_COLOR clr){ 
		List<Character> chrsInLev = levelManScript.charsInLevel;
		foreach(Character chr in chrsInLev){
			//Debug.Log ("int of enum chr "+chr.charParamet.myColor.ToString ());
			//Debug.Log ("int of enum clr"+clr.ToString());
			if(chr.charParamet.myColor.ToString () == clr.ToString()){
				//Debug.Log ("chr = "+chr);
				myCurrTarget = chr;
				myCurrTarget.GetComponent<Character>().setAssailant((Character)this);
				//Debug.Log (" !!!!!!!!  My name is "+gameObject.name+" and my assailant is: "+getAssailant());
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
		if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
			Debug.Log ("Victim drops dead");
		} 
		else if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
			Debug.Log ("THE FUCNTION OF THE SYRINGE IS SET TARGET");
			levelManScript.myGameState = GAME_STATE.CHAIN_REACTION;
			setTarget(item.paramet.itemColor);
			arrived = false;
			setAttacking(true);
		}
	}
	public void sicTarget(Transform sicTarget, Item_Set item){
		//Debug.Log ("arrived = "+arrived);
		if(!arrived ){
			switchAnim(anim, 1);
			transform.position = Vector2.MoveTowards(this.transform.position, sicTarget.position, 0.02f);
		}
		else if(arrived && attacking){
				switchAnim(anim, 2);
				setAttacking(false);
			}

	}  //this can be walk to or aim
	public void hitTarget(){ }
	public void returnToOrigPosition( ){ }
	public void setLiability (bool lia) { }
	public void switchAnim(Animator anim0, int anim_state){
		anim0.SetInteger("MainInt", anim_state);
	}
	
	public virtual void OnTriggerEnter2D(Collider2D  other){
		//Debug.Log ("OTHER NAME "+other.name);
		//Debug.Log ("ATTACKING = "+attacking);
		if (attacking){
			if( other.name == myCurrTarget.name && levelManScript.myGameState == GAME_STATE.MAINCHAR_ACTIVE ){
				//Debug.Log ("INSIDE OF ATTACKING PORTION. game state main active");
				levelManScript.setGameState(GAME_STATE.CHAIN_REACTION);
				switchAnim(anim, 2);	
				setAttacking(false);
				arrived = true;
				Debug.Log ("Assailant's objects = "+myQueue_Script.myItemObjects);

				//return;
			}
			else if (other.name == myCurrTarget.name && levelManScript.myGameState == GAME_STATE.CHAIN_REACTION){
				//Debug.Log ("INSIDE OF ATTACKING PORTION. gamestate chain reaction");
			}
		}
		else if (!attacking){
			Debug.Log ("Assailant name "+myAssailant.name);
			Debug.Log ("myAssailant's objects = "+myAssailant.myQueue_Script.myItemObjects);
			Debug.Log ("other.name = "+other.name);
			Debug.Log ("other.name.Equals(myAssailant.name "+other.name.Equals(myAssailant.name));
			if (other.name.Equals(myAssailant.name)){
				Debug.Log ("BINGO");
				reactToGetHit(myAssailant.myQueue_Script.myItemObjects[0]);
			}
		}
	}

	public void walkBackToStartPosition(Vector2 startPosition){
		//turn to face origin position
		//transform.position = Vector2.MoveTowards(transform.position, target, 0.02f);
		//play walk animation
	}
}
