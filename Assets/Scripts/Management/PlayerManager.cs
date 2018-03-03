using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager instance { get; private set; }

	private Dictionary<string, Player> mPlayerList = new Dictionary<string, Player>();

	public static Dictionary<string, Player> GetPlayerList()
	{
		return instance.mPlayerList;
	}
	public static Player GetLocalPlayer()
	{
		foreach (KeyValuePair<string, Player> player in instance.mPlayerList)
		{
			if(player.Value.gameObject.layer == LayerMask.NameToLayer("Local"))
			{
				return player.Value;
			}
		}

		Debug.LogError("[PlayerManager.cs] No local player found! Make sure Player is being initialized correctly!");
		return null;
	}
	public static void RegisterPlayer(string playerID, Player playerObject)
	{
		string ID = "PLYR" + playerID;
		instance.mPlayerList.Add(ID, playerObject);
	}
	public static void UnregisterPlayer(string playerID)
	{
		instance.mPlayerList.Remove(playerID);
	}

	// Use this for initialization
	void Awake()
	{
		if(!instance)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else if(instance != this)
		{
			DestroyImmediate(gameObject);
			return;
		}
	}
}