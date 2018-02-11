using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : Equipment
{
	public enum Classification
	{
		Axe = 1,
		Bow = 2,
		Cannon = 3,
		Fist = 4,
		Mace = 5,
		Pistol = 6,
		Polearm = 7,
		Rifle = 8,
		Staff = 9,
		Sword = 10,
		TwoHandedAxe = 11,
		TwoHandedMace = 12,
		TwoHandedSword = 13,
		Unarmed = 14,
		Wand = 15,
		NONE = 0
	}
	public enum Type
	{
		Meele = 1,
		Ranged = 2,
		NONE = 0
	}

	[SerializeField]
	private bool mIsHybrid;
	private bool mIsSecondaryModeActive;
	[SerializeField]
	private Classification mMainClass = Classification.NONE;
	[SerializeField]
	private Classification mSecondaryClass = Classification.NONE;
	[SerializeField]
	private Damage mMainDamage;
	[SerializeField]
	private Damage mSecondaryDamage;
	[SerializeField]
	private float mMainAccuracy;
	[SerializeField]
	private float mMainCriticalChance;
	[SerializeField]
	private float mMainCriticalMultiplier;
	[SerializeField]
	private float mMainRange;
	[SerializeField]
	private float mMainSpeed;
	[SerializeField]
	private float mSecondaryAccuracy;
	[SerializeField]
	private float mSecondaryCriticalChance;
	[SerializeField]
	private float mSecondaryCriticalMultiplier;
	[SerializeField]
	private float mSecondaryRange;
	[SerializeField]
	private float mSecondarySpeed;
	private int mNumAugmentSlots;
	private int mNumEnchantmentSlots;
	[SerializeField]
	private Weapon.Type mMainWeaponType = Weapon.Type.NONE;
	[SerializeField]
	private Weapon.Type	 mSecondaryWeaponType = Weapon.Type.NONE;
	
	public bool InRange(Transform me, Transform target)
	{
		UpdateMode(Vector3.Distance(me.position, target.position));
		if(mIsSecondaryModeActive)
		{
			return Vector3.Distance(me.position, target.position) <= mSecondaryRange;
		}
		return Vector3.Distance(me.position, target.position) <= mMainRange;
	}
	public bool IsHybrid()
	{
		return mIsHybrid;
	}
	public bool IsSecondaryModeActive()
	{
		return mIsSecondaryModeActive;
	}
	public Classification GetMainClassification()
	{
		return mMainClass;
	}
	public Classification GetSecondaryClassification()
	{
		return mSecondaryClass;
	}
	public Damage GetMainDamage()
	{
		return mMainDamage;
	}
	public Damage GetSecondaryDamage()
	{
		return mSecondaryDamage;
	}
	public float CalculateDamage()
	{
		float totalDamage = 0.0f;

			//Do a mode check
		if(mIsSecondaryModeActive)
		{
			totalDamage = mSecondaryDamage.GetAmount();
		}
		else
		{
			totalDamage = mMainDamage.GetAmount();
		}

		return totalDamage;
	}
	public float CalculateSpeed()
	{
		float totalSpeed = 0.0f;

		//Do a mode check
		if(mIsSecondaryModeActive)
		{
			totalSpeed = mSecondarySpeed;

			//Add the weapon's secondary class speed bonus to base
			switch(mSecondaryClass)
			{
				case Classification.NONE:
					Debug.LogError("[Weapon.cs] No secondary class assigned to the weapon " + gameObject.name +  ". Either weapon isn't a hybrid or hasn't been initialized correctly!");
					break;
			}
		}
		else
		{
			totalSpeed = mMainSpeed;

			//Add the weapon's secondary class speed bonus to base
			switch(mMainClass)
			{
				case Classification.NONE:
					Debug.LogError("[Weapon.cs] No secondary class assigned to the weapon " + gameObject.name +  ". Either weapon isn't a hybrid or hasn't been initialized correctly!");
					break;
			}
		}

		return totalSpeed;
	}
	public float GetMainAccuracy()
	{
		return mMainAccuracy;
	}
	public float GetMainCriticalChance()
	{
		return mMainCriticalChance;
	}
	public float GetMainCriticalMultiplier()
	{
		return mMainCriticalMultiplier;
	}
	public float GetMainRange()
	{
		return mMainRange;
	}
	public float GetMainSpeed()
	{
		return mMainSpeed;
	}
	public float GetSecondaryAccuracy()
	{
		return mSecondaryAccuracy;
	}
	public float GetSecondaryCriticalChance()
	{
		return mSecondaryCriticalChance;
	}
	public float GetSecondaryCriticalMultiplier()
	{
		return mSecondaryCriticalMultiplier;
	}
	public float GetSecondaryRange()
	{
		return mSecondaryRange;
	}
	public float GetSecondarySpeed()
	{
		return mSecondarySpeed;
	}
	public int GetNumAugmentSlots()
	{
		return mNumAugmentSlots;
	}
	public int GetNumEnchantmentSlots()
	{
		return mNumEnchantmentSlots;
	}
	public void GrantExperienceToClass(int experience)
	{
		//Do a mode check
		if(mIsSecondaryModeActive)
		{
			//Grant experience to weapon's secondary class
			switch(mSecondaryClass)
			{
				case Classification.NONE:
					Debug.LogError("[Weapon.cs] No secondary class assigned to the weapon " + gameObject.name +  ". Either weapon isn't a hybrid or hasn't been initialized correctly!");
					break;
			}
		}
		else
		{
			//Grant experience to weapon's main class
			switch(mMainClass)
			{
				case Classification.NONE:
					Debug.LogError("[Weapon.cs] No main class assigned to the weapon " + gameObject.name + ". Please intialize the weapon!");
					break;
			}
		}
	}
	public void SetIsHybridFlag(bool flag)
	{
		mIsHybrid = flag;
	}
	public void SetMainAccuracy(float value)
	{
		mMainAccuracy = value;
	}
	public void SetMainClassification(Classification classification)
	{
		mMainClass = classification;
	}
	public void SetMainCriticalChance(float value)
	{
		mMainCriticalChance = value;
	}
	public void SetMainCriticalMultiplier(float value)
	{
		mMainCriticalMultiplier = value;
	}
	public void SetMainDamage(Damage damage)
	{
		mMainDamage = damage;
	}
	public void SetMainRange(float value)
	{
		mMainRange = value;
	}
	public void SetMainSpeed(float value)
	{
		mMainSpeed = value;
	}
	public void SetMainWeaponType(Weapon.Type type)
	{
		mMainWeaponType = type;
	}
	public void SetNumAugmentSlots(int value)
	{
		mNumAugmentSlots = value;
	}
	public void SetNumEnchantmentSlots(int value)
	{
		mNumEnchantmentSlots = value;
	}
	public void SetSecondaryAccuracy(float value)
	{
		mSecondaryAccuracy = value;
	}
	public void SetSecondaryClassification(Classification classification)
	{
		mSecondaryClass = classification;
	}
	public void SetSecondaryCriticalChance(float value)
	{
		mSecondaryCriticalChance = value;
	}
	public void SetSecondaryCriticalMultiplier(float value)
	{
		mSecondaryCriticalMultiplier = value;
	}
	public void SetSecondaryDamage(Damage damage)
	{
		mSecondaryDamage = damage;
	}
	public void SetSecondaryRange(float value)
	{
		mSecondaryRange = value;
	}
	public void SetSecondarySpeed(float value)
	{
		mSecondarySpeed = value;
	}
	public void SetSecondaryWeaponType(Weapon.Type type)
	{
		mSecondaryWeaponType = type;
	}
	public void UpdateMode(float distance)
	{
		if(mIsHybrid)
		{
			//Check if the primary range is greater than the secondary range
			if(mMainRange >= mSecondaryRange)
			{
				//Do a range check
				if(distance <= mMainRange && distance > mSecondaryRange)
				{
					//Switch to the primary mode
					mIsSecondaryModeActive = false;
				}
				else
				{
					//Switch to the secondary mode
					mIsSecondaryModeActive = true;
				}
			}
			else
			{
				//Do a range check
				if(distance <= mSecondaryRange && distance > mMainRange)
				{
					//Switch to the secondary mode
					mIsSecondaryModeActive = true;
				}
				else
				{
					//Switch to the primary mode
					mIsSecondaryModeActive = false;
				}
			}
		}
		else
		{
			mIsSecondaryModeActive = false;
		}
	}
	public Weapon.Type GetMainWeaponType()
	{
		return mMainWeaponType;
	}
	public Weapon.Type GetSecondaryWeaponType()
	{
		return mSecondaryWeaponType;
	}
}