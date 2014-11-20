using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

	public enum MYCOLOR {Null, Blue, Yellow, Orange, Purple, Red, Black, Green, White, Aqua, Beige};
	public MYCOLOR myColor;
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

	public Character getTarget(){
		return myCurrTarget;
		
	}
	public void setTarget(Character chr){ }
	public void hitTarget(Character chr, Item Item_Set){ }
	public void dropItem(){ }
	public void reactToGetHit (Item_Set item){ 
		if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.DEATH){
			Debug.Log ("Victim drops dead");
		} else if(item.paramet.itemFunction == ItemParams.ITEM_FUNCTION.SETTARGET){
			Debug.Log ("Victim just set his target");
		}
	}
	public void sicTarget(Transform sicTarget, Item_Set itemToUSe){
		if(!arrived){
			transform.position = Vector2.MoveTowards(this.transform.position, sicTarget.position, 0.02f);
			anim.SetInteger("MainInt", 1);
			//yield;
		}

	}  //this can be walk to or aim
	public void hitTarget(){ }
	public void returnToOrigPosition( ){ }
	public void setLiability (bool lia) { }
	
}
