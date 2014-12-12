using UnityEngine;
using System.Collections;



[System.Serializable]
public class ItemParams
{
	public enum ITEM_TYPE{NONE, SYRINGE, GUN, CAMERA, MONEY, EVIDENCE, NOTE, PICTURE, CHEMICAL_PACKET, SEQUENCE_SYRINGE, COCKTAIL};
	public ITEM_TYPE itemType;

	public enum ITEM_COLOR{ NONE, RED, YELLOW, BLUE, ORANGE, BLACK, PURPLE, GREEN};
	public ITEM_COLOR itemColor;

	public enum ITEM_FUNCTION{NONE, EMPTY, DEATH, SETTARGET, FREEZE, FORGET, QUIET, SPEEDADJUST, CHANGE_CHARACTERTYPE}
	public ITEM_FUNCTION itemFunction;


}

public class Item_Set : MonoBehaviour {
	//public Texture2D myTexture;

	public ItemParams paramet;
	
}
