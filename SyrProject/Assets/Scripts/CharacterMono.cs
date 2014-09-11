using UnityEngine;
using System.Collections.Generic;

public class CharacterMono : MonoBehaviour {


	public enum CharacterColor {Null, Blue, Yellow, Orange, Purple, Red, Black, Green, White, Aqua, Beige};
	//public enum NPCType {ColorChar, Main, Splitter, Photographer, Cleaner, Runner};
	public enum TargetType {None, BlackStabOnce, BlackStabTwice, Suicide, CockTail, BlackShootOnce, BlackShootTwice, Forget, Picture, Love, Inception, Implicate, Crazy, DoubleInception, Empty};
	public enum Resilience {None, ColorSyringe, BlackSyringe, Photo, Forget, Inception, GunShot, Pill, Love, Crazy, Empty};
	public enum CharacterNum {None, character1,character2, character3, character4, character5,character6, character7, character8, character9, character10};

	public CharacterColor myColor;
	//public NPCType myType;
	public TargetType myCurrentTarget;
	public Resilience myResilience;
	public CharacterNum characterNum;

	public List<Item> myItems = new List<Item>();

	//public int num;


		void moveToTarget(GameObject myTarget){}
	//void getStabbed(Syringe syringeType);
	//void getShot(Shot shotType);
	//void stab(Syringe syringeType);
		void die(){}
		void freeze(){}
		void forget(){}
		void stabBack(){}
		void returnToStartPosition(){}
		void returnToPreviousLocation(){}


}
