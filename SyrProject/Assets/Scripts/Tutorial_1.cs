using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tutorial_1 : MonoBehaviour
{

		public List<Transform> tutorialPanels = new List<Transform> ();
		private int nTutState;
		//public GameObject mainCharacterOBJ;
		public MainChar mainPlayerScript;
		public NonMainChar nonMain1;
		public NonMainChar nonMain2;

		void Update ()
		{
		Debug.Log ("tutorial State is: "+nTutState);
				switch (nTutState) {
				//This is the main
				case 0:
						openRelevantTutCloseOthers();
						break;
				case 1:
				//This is the non-main
						openRelevantTutCloseOthers();
						break;
				case 2:
				//Tap to see items
						openRelevantTutCloseOthers();
						if(mainPlayerScript.getTapOnMeCounter() == 1){
							increaseTutStateBy1(1);
						}
			
						break;
				case 3:
				//Try Moving
						openRelevantTutCloseOthers();
						if(Drag_Item.tapOnSyringeCounter > 0){
							increaseTutStateBy1(1);
						}

						break;
				case 4:
				//Syringe Order
						openRelevantTutCloseOthers();
					break;
				case 5:
				//Color Syringes do this...black syringes do that. 
						openRelevantTutCloseOthers();
					break;
				case 6:
				//See Arrow
					openRelevantTutCloseOthers();
					if(mainPlayerScript.getTapOnMeCounter() > 1){
						increaseTutStateBy1(1);
					}

					break;
				case 7:
				//Tap to change target
					openRelevantTutCloseOthers();
//					if(nonMain1.OnMouseDown() || nonMain2.OnMouseDown()){
//						increaseTutStateBy1(1);
//					}
					break;
				case 8:
				//tap tip of red arrow
					openRelevantTutCloseOthers();
					if(Activate_MainChar.tapRedArrowCounter > 0){
						increaseTutStateBy1(1);
					}
					break;
				case 9:
					for (int i=0; i< tutorialPanels.Count; i++) {
							tutorialPanels [i].gameObject.SetActive (false);
						}
					break;

				default:

						break;
				}
		}

	public void increaseTutStateBy1(int thisNum){
		nTutState += thisNum;
	}

	private void openRelevantTutCloseOthers(){
		tutorialPanels [nTutState].gameObject.SetActive (true);
		for (int i=0; i< tutorialPanels.Count; i++) {
			if (i != nTutState) {
				tutorialPanels [i].gameObject.SetActive (false);
			}
		}

	}


}
