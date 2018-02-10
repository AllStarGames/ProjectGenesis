using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponStats
{
	private float mAccuracyBonus;
	private float mBaseAccuracyBonus;
	private float mBaseCriticalChanceBonus;
	private float mBaseDamageBonus;
	private float mBaseSpeedBonus;
	private float mCriticalChanceBonus;
	private float mDamageBonus;
	private float mSpeedBonus;
	private int mExperience;
	private int mExperienceToNextLevel;
	private int mLevel;

	public float GetAccuracyBonus()
	{
		return mAccuracyBonus;
	}
	public float GetBaseAccuracyBonus()
	{
		return mBaseAccuracyBonus;
	}
	public float GetBaseCriticalChanceBonus()
	{
		return mBaseCriticalChanceBonus;
	}
	public float GetBaseDamageBonus()
	{
		return mBaseDamageBonus;
	}
	public float GetBaseSpeedBonus()
	{
		return mBaseSpeedBonus;
	}
	public float GetCriticalChanceBonus()
	{
		return mCriticalChanceBonus;
	}
	public float GetDamageBonus()
	{
		return mDamageBonus;
	}
	public float GetSpeedBonus()
	{
		return mSpeedBonus;
	}
	public int GetExperience()
	{
		return mExperience;
	}
	public int GetExperienceToNextLevel()
	{
		return mExperienceToNextLevel;
	}
	public int GetLevel()
	{
		return mLevel;
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
		//Set level to 1
		mLevel = 1;
		//Set experience and experience to next level
		mExperienceToNextLevel = 100;
		mExperience = 0;

		//Set bonus base values
		mBaseAccuracyBonus = 0.0f;
		mBaseCriticalChanceBonus = 0.0f;
		mBaseDamageBonus = 0.0f;
		mBaseSpeedBonus = 0.0f;

		//Set the bonuses to their base values
		mAccuracyBonus = mBaseAccuracyBonus;
		mCriticalChanceBonus = mBaseCriticalChanceBonus;
		mDamageBonus = mBaseDamageBonus;
		mSpeedBonus = mBaseSpeedBonus;
	}
	public void LevelUp()
	{
		//Reset experience
		mExperience = 0;
		mExperienceToNextLevel += Mathf.RoundToInt(mExperienceToNextLevel * 0.1f);

		//Increase level
		++mLevel;

		//Increase bonuses
		mAccuracyBonus += (mLevel * 0.5f);
		mCriticalChanceBonus += (mLevel * 0.5f);
		mDamageBonus += (mLevel * 0.5f);
		mSpeedBonus += (mLevel * 0.5f);
	}
	public void SetAccuracyBonus(float value)
	{
		mAccuracyBonus = value;
	}
	public void SetBaseAccuracyBonus(float value)
	{
		mBaseAccuracyBonus = value;
	}
	public void SetBaseCriticalChanceBonus(float value)
	{
		mBaseCriticalChanceBonus = value;
	}
	public void SetBaseDamageBonus(float value)
	{
		mBaseDamageBonus = value;
	}
	public void SetBaseSpeedBonus(float value)
	{
		mBaseSpeedBonus = value;
	}
	public void SetCriticalChanceBonus(float value)
	{
		mCriticalChanceBonus = value;
	}
	public void SetDamageBonus(float value)
	{
		mDamageBonus = value;
	}
	public void SetExperience(int value)
	{
		mExperience = value;
	}
	public void SetExperienceToNextLevel(int value)
	{
		mExperienceToNextLevel = value;
	}
	public void SetLevel(int value)
	{
		mLevel = value;
	}
	public void SetSpeedBonus(float value)
	{
		mSpeedBonus = value;
	}
}