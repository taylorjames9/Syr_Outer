using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

	public enum MYCOLOR {Null, Blue, Yellow, Orange, Purple, Red, Black, Green, White, Aqua, Beige};
	public MYCOLOR myColor;
	public GameObject myQueueOBJ;
	public enum FACINGDIR {UP, DOWN, LEFT, RIGHT};


	public void dropObject(){

	}

}
