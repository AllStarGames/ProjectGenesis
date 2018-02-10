﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	private float mHealth;
	private float mHealthRegenTimer;
	private float mShieldRegenTimer;
	private float mShields;
	private Player mPlayerObject;

	public float GetHealth()
	{
		return mHealth;
	}
	public float GetHealthRegenTimer()
	{
		return mHealthRegenTimer;
	}
	public float GetShieldRegenTimer()
	{
		return mShieldRegenTimer;
	}
	public float GetShields()
	{
		return mShields;
	}
	public void IncreaseHealth(float value)
	{
		mHealth += value;
		if(mHealth > mPlayerObject.GetStats().GetMaxHealth())
		{
			mHealth = mPlayerObject.GetStats().GetMaxHealth();
		}
	}
	public void IncreaseShields(float value)
	{
		mShields += value;
		if(mShields > mPlayerObject.GetStats().GetMaxShields())
		{
			mShields = mPlayerObject.GetStats().GetMaxShields();
		}
	}
	public void SetHealth(float value)
	{
		mHealth = value;
	}
	public void SetHealthRegenTimer(float time)
	{
		mHealthRegenTimer = time;
	}
	public void SetShieldRegenTimer(float time)
	{
		mShieldRegenTimer = time;
	}
	public void SetShields(float value)
	{
		mShields = value;
	}
	public void TakeDamage(DamageType type, float damage)
	{
		mPlayerObject.SetNumTimesHit(mPlayerObject.GetNumTimesHit() + 1);
		float finalDamage = damage;

		mHealth -= finalDamage;
		if(mHealth <= 0.0f)
		{
			Death();
		}
	}

	void Death()
	{

	}
	void RegenerateHealth()
	{
		if(!mPlayerObject.GetInCombatFlag())
		{
			mHealthRegenTimer -= Time.deltaTime;
			if(mHealthRegenTimer <= 0.0f)
			{
				mHealthRegenTimer = mPlayerObject.GetStats().GetHealthRegenRate();
				IncreaseHealth(1.0f);
			}
		}
	}
	void RegenerateShields()
	{
		if(!mPlayerObject.GetInCombatFlag())
		{
			mShieldRegenTimer -= Time.deltaTime;
			if(mShieldRegenTimer <= 0.0f)
			{
				mShieldRegenTimer = mPlayerObject.GetStats().GetShieldRegenRate();
				IncreaseShields(1.0f);
			}
		}
	}
	// Use this for initialization
	void Start ()
	{
		//Reference the player script
		mPlayerObject = GetComponent<Player>();

		//Set health and shield values
		mHealth = mPlayerObject.GetStats().GetMaxHealth();
		mShields = mPlayerObject.GetStats().GetMaxShields();

		//Set regen timers
		mHealthRegenTimer = mPlayerObject.GetStats().GetHealthRegenRate();
		mShieldRegenTimer = mPlayerObject.GetStats().GetShieldRegenRate();
	}
	
	// Update is called once per frame
	void Update ()
	{
		RegenerateHealth();
		RegenerateShields();
	}
}