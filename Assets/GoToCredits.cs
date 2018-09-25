using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToCredits : MonoBehaviour {

	// Use this for initialization
	public string SceneName = "creditos";

	// Update is called once per frame
	void GotoCreditsScene()
	{
		SceneManager.LoadScene(SceneName);
	}
}
