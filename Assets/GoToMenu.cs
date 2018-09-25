using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToMenu : MonoBehaviour {

	// Use this for initialization
	public string SceneName = "menu";
	
	// Update is called once per frame
	void GotoMainMenu () {
		SceneManager.LoadScene(SceneName);
	}
}
