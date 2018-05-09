using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	public enum Behaviour
	{
		Swarm = 1,
		NONE = 0
	}

	[SerializeField]
	private Behaviour mBehaviour;
	private List<GameObject> mSurroundings;

	public Behaviour Behavior()
	{
		return mBehaviour;
	}
	public List<GameObject> Surroundings()
	{
		return mSurroundings;
	}
	public void AddToSurroundings(GameObject obj)
	{
		mSurroundings.Add(obj);
	}
	public void SwitchBehaviours(Behaviour newBehaviour)
	{
		mBehaviour = newBehaviour;
	}

	//Method to get all objects within this NPC's sight
	void GetSurrondings()
	{
		
	}
	//Unity initialization method
	void Start ()
	{
		mSurroundings = new List<GameObject>();
	}
	
	//Unity update method
	void Update ()
	{
		
	}
}