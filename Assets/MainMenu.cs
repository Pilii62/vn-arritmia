using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {


	[Tooltip("The string key used to store save game data in Player Prefs. If you have multiple games defined in the same Unity project, use a unique key for each one.")]
	[SerializeField] protected string saveDataKey = FungusConstants.DefaultSaveDataKey;


	public Button loadButton;

	public string gameSceneName = "arritmia";
	// Use this for initialization
	void Start () {
		var saveManager = FungusManager.Instance.SaveManager;
		// Reset the Save History for a new game
		var exists = saveManager.SaveDataExists(saveDataKey);
		Debug.Log(exists ? "SaveGame exists" : "SaveGame does not exists");
		loadButton.gameObject.SetActive(exists);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public virtual void AsyncLoad()
	{
		StartCoroutine(DoAsyncLoad());
	}

	IEnumerator DoAsyncLoad()
	{
		yield return new WaitForSeconds(.1f);
		Save();
	}

	public virtual void AsyncReset()
	{
		StartCoroutine(DoAsyncReset());
	}

	IEnumerator DoAsyncReset()
	{
		yield return new WaitForSeconds(.1f);
		Restart();
	}

	public virtual void Save()
	{
		var saveManager = FungusManager.Instance.SaveManager;

		if (saveManager.NumSavePoints > 0)
		{
			//PlayClickSound();
			saveManager.Save(saveDataKey);
		}
	}

	/// <summary>
	/// Handler function called when the Load button is pressed.
	/// </summary>
	public virtual void Load()
	{
		var saveManager = FungusManager.Instance.SaveManager;

		if (saveManager.SaveDataExists(saveDataKey))
		{
			//PlayClickSound();
			saveManager.Load(saveDataKey);
		}
	}

	public virtual void Restart()
	{
		var saveManager = FungusManager.Instance.SaveManager;

		// Reset the Save History for a new game
		saveManager.ClearHistory();
		saveManager.Delete(saveDataKey);

		// PlayClickSound();
		SceneManager.LoadScene(gameSceneName);
	}
}
