using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

	public enum MYCOLOR {Null, Blue, Yellow, Orange, Purple, Red, Black, Green, White, Aqua, Beige};
	public MYCOLOR myColor;
	public GameObject myQueueOBJ;
	public enum FACINGDIR {UP, DOWN, LEFT, RIGHT};

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

	protected Animator anim;

	public void Start(){
		myStartPosition = new Vector2(this.transform.position.x, this.transform.position.y);
		Debug.Log ("Set everyone's positions.");
	}



	public void setAssailant(Character myAssailant){ }
	public void setTarget(Character chr){ }
	public void hitTarget(Character chr, Item Item_Set){ }
	public void dropItem(){ }
	public void reactToGetHit (Item item){ }
	public void sicTarget(Character sicTarget, Item_Set itemToUSe){}  //this can be walk to or aim
	public void hitTarget(){ }
	public void returnToOrigPosition( ){ }
	public void setLiability (bool lia) { }
	
}
