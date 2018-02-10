using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance {get; private set;}

	private bool mPauseFlag;

	public static bool GamePaused()
	{
		return instance.mPauseFlag;
	}
	public static void PauseGame(bool value)
	{
		instance.mPauseFlag = value;
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
}
