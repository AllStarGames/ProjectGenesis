using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance {get; private set;}

	[SerializeField]
	private bool mDebugFlag;
	private bool mPauseFlag;

	public static bool DebugMode()
	{
		return instance.mDebugFlag;
	}
	public static bool GamePaused()
	{
		return instance.mPauseFlag;
	}
	public static void PauseGame(bool value)
	{
		instance.mPauseFlag = value;
	}
	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}

	// Use this for initialization
	void Awake ()
	{
		if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			QuitGame();
		}
	}
}
