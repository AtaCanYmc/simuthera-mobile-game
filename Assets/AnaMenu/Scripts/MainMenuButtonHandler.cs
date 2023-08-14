using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandler : MonoBehaviour
{
    public void ChangeScene(int sceneNumber) {
		if (Mathf.Abs(GamePanelController.touchDelta.x) <= Screen.currentResolution.width*GamePanelController.swipeRegFactor) {
			SceneManager.LoadScene(sceneNumber);
		}
	}
	
}
