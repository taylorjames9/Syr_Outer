using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tutorial_1 : MonoBehaviour
{

		public List<Transform> tutorialPanels = new List<Transform> ();
		private int nTutState;
		//public GameObject mainCharacterOBJ;
		public MainChar mainPlayerScript;

		void Update ()
		{
				switch (nTutState) {
				case 0:
						tutorialPanels [nTutState].gameObject.SetActive (true);
						for (int i=0; i< tutorialPanels.Count; i++) {
								if (i != nTutState) {
										tutorialPanels [i].gameObject.SetActive (false);
								}
						}
						break;
				case 1:
						tutorialPanels [nTutState].gameObject.SetActive (true);
						for (int i=0; i< tutorialPanels.Count; i++) {
							if (i != nTutState) {
								tutorialPanels [i].gameObject.SetActive (false);
							}
						}
						break;
				case 2:
						tutorialPanels [nTutState].gameObject.SetActive (true);
						for (int i=0; i< tutorialPanels.Count; i++) {
							if (i != nTutState) {
								tutorialPanels [i].gameObject.SetActive (false);
							}
						}
						if(mainPlayerScript.getTapOnMeCounter() == 1){
							increaseTutStateBy1(1);
						}
			
						break;
				case 3:
						tutorialPanels [nTutState].gameObject.SetActive (true);
						for (int i=0; i< tutorialPanels.Count; i++) {
							if (i != nTutState) {
								tutorialPanels [i].gameObject.SetActive (false);
							}
						}
						if(Drag_Item.tapOnSyringeCounter > 0){
							increaseTutStateBy1(1);
						}

						break;
				case 4:
					tutorialPanels [nTutState].gameObject.SetActive (true);
					for (int i=0; i< tutorialPanels.Count; i++) {
						if (i != nTutState) {
							tutorialPanels [i].gameObject.SetActive (false);
						}
					}
					break;

				default:

						break;
				}
		}

	public void increaseTutStateBy1(int thisNum){
		nTutState += thisNum;
	}


}
