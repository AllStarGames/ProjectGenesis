using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatSystem : MonoBehaviour
{
	private float mMaxThreat;
	private float mThreat;
	private float mThreatDecayTimer;
	private NPC mNPCObject;
	private Player mPlayerObject;

	public float GetMaxThreat()
	{
		return mMaxThreat;
	}
	public float GetThreatDecayTimer()
	{
		return mThreatDecayTimer;
	}
	public float GetThreatLevel()
	{
		return mThreat;
	}
	public void DecreaseThreat(float value)
	{
		mThreat -= value;
		if(mThreat < 0.0f)
		{
			mThreat = 0.0f;
		}
	}
	public void IncreaseThreat(float value)
	{
		mThreat += value;
		if(mThreat > mMaxThreat)
		{
			mThreat = mMaxThreat;
		}
	}
	public void SetThreatDecayTimer(float time)
	{
		mThreatDecayTimer = time;
	}
	public void SetThreatLevel(float value)
	{
		mThreat = value;
	}

	//Unity initialization method
	void Start ()
	{
		mMaxThreat = 100.0f;
		mThreat = 0.0f;
		mThreatDecayTimer = 1.0f;

		mNPCObject = GetComponent<NPC>();
		mPlayerObject = GetComponent<Player>();
	}
	//Unity update method
	void Update ()
	{
		if(mPlayerObject)
		{
			if(mPlayerObject.IsInCombat())
			{
				mThreatDecayTimer -= Time.deltaTime;
				if(mThreatDecayTimer < 0.0f)
				{
					DecreaseThreat(1.0f);
				}
			}
			else
			{
				mThreat = 0.0f;
			}
		}
		else if(mNPCObject)
		{
			if(mNPCObject.IsInCombat())
			{
				mThreatDecayTimer -= Time.deltaTime;
				if(mThreatDecayTimer < 0.0f)
				{
					DecreaseThreat(1.0f);
				}
			}
			else
			{
				mThreat = 0.0f;
			}
		}
	}
}