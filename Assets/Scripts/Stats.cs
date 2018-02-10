using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
	private bool mBatteryRechargable;
	private float mAgility;
	private float mArmour;
	private float mCarryWeight;
	private float mEnergyRegenRate;
	private float mHealthRegenRate;
	private float mIntellect;
	private float mMaxEnergy;
	private float mMaxHealth;
	private float mMaxShields;
	private float mMaxStamina;
	private float mShieldRegenRate;
	private float mStaminaRegenRate;
	private float mStrength;
	private float mWillpower;
	private int mExperience;
	private int mExperienceToNextLevel;
	private int mLevel;
	private Player mPlayerObject;
	
	public bool GetRechargableBatteryFlag()
	{
		return mBatteryRechargable;
	}
	public float GetAgilityStat()
	{
		return mAgility;
	}
	public float GetArmourStat()
	{
		return mArmour;
	}
	public float GetCarryWeight()
	{
		return mCarryWeight;
	}
	public float GetEnergyRegenRate()
	{
		return mEnergyRegenRate;
	}
	public float GetHealthRegenRate()
	{
		return mHealthRegenRate;
	}
	public float GetIntellectStat()
	{
		return mIntellect;
	}
	public float GetMaxEnergy()
	{
		return mMaxEnergy;
	}
	public float GetMaxHealth()
	{
		return mMaxHealth;
	}
	public float GetMaxShields()
	{
		return mMaxShields;
	}
	public float GetMaxStamina()
	{
		return mMaxStamina;
	}
	public float GetShieldRegenRate()
	{
		return mShieldRegenRate;
	}
	public float GetStaminaRegenRate()
	{
		return mStaminaRegenRate;
	}
	public float GetStrengthStat()
	{
		return mStrength;
	}
	public float GetWillpowerStat()
	{
		return mWillpower;
	}
	public int GetCurrentExperience()
	{
		return mExperience;
	}
	public int GetCurrentLevel()
	{
		return mLevel;
	}
	public int GetExperienceToNextLevel()
	{
		return mExperienceToNextLevel;
	}
	public void GrantExperience(int value)
	{
		mExperience += value;
		if(mExperience >= mExperienceToNextLevel)
		{
			int remaining = Mathf.Abs(mExperience - mExperienceToNextLevel);
			LevelUp();
			GrantExperience(remaining);
		}
	}
	public void Initialize()
	{
		//Set default values for the player stats
		mAgility = 0.0f;
		mIntellect = 0.0f;
		mStrength = 0.0f;
		mWillpower = 0.0f;

		//Set default values for the player level
		mLevel = 1;
		mExperienceToNextLevel = 100;
		mExperience = 0;

		//Set default values for the player health stats
		mArmour = 0.0f;
		mHealthRegenRate = 0.1f;
		mMaxHealth = 100.0f;

		//Set default values for the player shield stats
		mMaxShields = 0.0f;
		mShieldRegenRate = 0.0f;

		//Set default values for the player energy stats
		mBatteryRechargable = false;
		mEnergyRegenRate = 0.0f;
		mMaxEnergy = 100.0f;

		//Set default values for the player stamina stats
		mMaxStamina = 100.0f;
		mStaminaRegenRate = 1.0f;

		//Set default value for player carry weight
		mCarryWeight = 10.0f;
	}
	public void LevelUp()
	{
		//Reset experience
		mExperience = 0;
		
		//Increase the level
		++mLevel;

		//Increase static stats
		mAgility += 0.05f;
		mHealthRegenRate += 0.01f;
		mExperienceToNextLevel += Mathf.RoundToInt(mExperienceToNextLevel * 0.1f);

		//Increase dynamic stats
		//Increase the player's health based on the number of times they were hit
		mMaxHealth += Mathf.RoundToInt(mPlayerObject.GetNumTimesHit() * 0.1f);
		//Increase the player's intellect stat based on the number of times they used a magical ability
		mIntellect += Mathf.RoundToInt(mPlayerObject.GetNumMagicalUses() * 0.1f);
		//Increase the player's strength stat based on the number of times they used a physical ability
		mStrength += Mathf.RoundToInt(mPlayerObject.GetNumPhysicalUses() * 0.1f);
		//Increase the player's carry weight based on the strength stat
		mCarryWeight += mStrength * 0.5f;

		//Reset the counters
		mPlayerObject.SetNumTimesHit(0);
		mPlayerObject.SetNumMagicalUses(0);
		mPlayerObject.SetNumPhysicalUses(0);
	}
	public void SetAgilityStat(float value)
	{
		mAgility = value;
	}
	public void SetArmourStat(float value)
	{
		mArmour = value;
	}
	public void SetCarryWeight(float value)
	{
		mCarryWeight = value;
	}
	public void SetCurrentExperience(int value)
	{
		mExperience = value;
	}
	public void SetCurrentLevel(int value)
	{
		mLevel = value;
	}
	public void SetEnergyRegenRate(float value)
	{
		mEnergyRegenRate = value;
	}
	public void SetExperienceToNextLevel(int value)
	{
		mExperienceToNextLevel = value;
	}
	public void SetHealthRegenRate(float value)
	{
		mHealthRegenRate = value;
	}
	public void SetIntellectStat(float value)
	{
		mIntellect = value;
	}
	public void SetMaxEnergy(float value)
	{
		mMaxEnergy = value;
	}
	public void SetMaxHealth(float value)
	{
		mMaxHealth = value;
	}
	public void SetMaxShields(float value)
	{
		mMaxShields = value;
	}
	public void SetMaxStamina(float value)
	{
		mMaxStamina = value;
	}
	public void SetRechargableBatteryFlag(bool value)
	{
		mBatteryRechargable = value;
	}
	public void SetShieldRegenRate(float value)
	{
		 mShieldRegenRate = value;
	}
	public void SetStaminaRegenRate(float value)
	{
		mStaminaRegenRate = value;
	}
	public void SetStrengthStat(float value)
	{
		mStrength = value;
	}
	public void SetWillpowerStat(float value)
	{
		mWillpower = value;
	}

	void Start()
	{
		mPlayerObject = GetComponent<Player>();
	}
}