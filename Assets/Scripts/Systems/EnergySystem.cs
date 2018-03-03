using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
	[SerializeField]
	private bool mCanRecharge;
	private float mDrainTimer;
	private float mEnergy;
	private float mEnergyRegenTimer;
	private NPC mNPCObject;
	private Player mPlayerObject;

	public bool CanRecharge()
	{
		return mCanRecharge;
	}
	public float GetEnergy()
	{
		return mEnergy;
	}
	public float GetEnergyRegenTimer()
	{
		return mEnergyRegenTimer;
	}
	public void DecreaseEnergy(float value)
	{
		mEnergy -= value;
		if(mEnergy < 0.0f)
		{
			mEnergy = 0.0f;
		}
	}
	public void Drain()
	{
		mDrainTimer -= Time.deltaTime;
		if(mDrainTimer <= 0.0f)
		{
			mDrainTimer = 1.0f;
		}
	}
	public void IncreaseEnergy(float value)
	{
		mEnergy += value;
		if(mPlayerObject)
		{
			if(mEnergy > mPlayerObject.GetStats().GetMaxEnergy())
			{
				mEnergy = mPlayerObject.GetStats().GetMaxEnergy();
			}
		}
		else if(mNPCObject)
		{
			if(mEnergy > mNPCObject.GetStats().GetMaxEnergy())
			{
				mEnergy = mNPCObject.GetStats().GetMaxEnergy();
			}
		}
	}
	public void Recharge()
	{
		if(mCanRecharge)
		{
			mEnergyRegenTimer -= Time.deltaTime;
			if(mEnergyRegenTimer <= 0.0f)
			{
				if(mPlayerObject)
				{
					mEnergyRegenTimer = mPlayerObject.GetStats().GetEnergyRegenRate();
					IncreaseEnergy(1.0f);
				}
				else if(mNPCObject)
				{
					mEnergyRegenTimer = mNPCObject.GetStats().GetEnergyRegenRate();
					IncreaseEnergy(1.0f);
				}
			}
		}
	}
	public void SetCanRechargeFlag(bool value)
	{
		mCanRecharge = value;
	}
	public void SetEnergy(float value)
	{
		mEnergy = value;
	}
	public void SetEnergyRegenTimer(float time)
	{
		mEnergyRegenTimer = time;
	}

	//Unity initialize method
	void Start ()
	{
		//Set the drain timer
		mDrainTimer = 1.0f;

		//Reference the object script
		mPlayerObject = GetComponent<Player>();
		mNPCObject = GetComponent<NPC>();

		if(mPlayerObject)
		{
			//This is a player
			//Set energy value
			mEnergy = mPlayerObject.GetStats().GetMaxEnergy();

			//Set regen timer
			mEnergyRegenTimer = mPlayerObject.GetStats().GetEnergyRegenRate();
		}
		else if(mNPCObject)
		{
			//This is an enemy
			//Set energy value
			mEnergy = mNPCObject.GetStats().GetMaxEnergy();

			//Set regen timer
			mEnergyRegenTimer = mNPCObject.GetStats().GetEnergyRegenRate();
		}
		else
		{
			Debug.LogError("[EnergySystem.cs] Could not find the NPC or Player script on " + gameObject.name + "!");
		}
	}
	//Untiy update method
	void Update ()
	{
		if(!GameManager.GamePaused())
		{
			Drain();
			Recharge();
		}
	}
}
