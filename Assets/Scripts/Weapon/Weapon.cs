using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : Equipment
{
	public enum Classification
	{
		Axe,
		Bow,
		Cannon,
		Fist,
		Mace,
		Pistol,
		Polearm,
		Rifle,
		Staff,
		Sword,
		TwoHandedAxe,
		TwoHandedMace,
		TwoHandedSword,
		Unarmed,
		Wand
	}
	public enum Type
	{
		Meele,
		Ranged
	}

	[SerializeField]
	private bool mIsHybrid;
	private bool mSecondaryFlag;
	[SerializeField]
	private Classification mMainClass;
	[SerializeField]
	private Classification mSecondaryClass;
	[SerializeField]
	private Damage.Type mMainDamageType;
	[SerializeField]
	private Damage.Type mSecondaryDamageType;
	private float mMainRange;
	private float mSecondaryRange;
	private int mNumAugmentSlots;
	private int mNumEnchantmentSlots;
	[SerializeField]
	private Weapon.Type mMainWeaponType;
	[SerializeField]
	private Weapon.Type	 mSecondaryWeaponType;
	
	public bool InRange(Transform me, Transform target)
	{
		UpdateMode(Vector3.Distance(me.position, target.position));
		if(mSecondaryFlag)
		{
			return Vector3.Distance(me.position, target.position) <= mSecondaryRange;
		}
		return Vector3.Distance(me.position, target.position) <= mMainRange;
	}
	public bool IsHybrid()
	{
		return mIsHybrid;
	}
	public float CalculateDamage()
	{
		float totalDamage = 0.0f;
		return totalDamage;
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
					mSecondaryFlag = false;
				}
				else
				{
					//Switch to the secondary mode
					mSecondaryFlag = true;
				}
			}
			else
			{
				//Do a range check
				if(distance <= mSecondaryRange && distance > mMainRange)
				{
					//Switch to the secondary mode
					mSecondaryFlag = true;
				}
				else
				{
					//Switch to the primary mode
					mSecondaryFlag = false;
				}
			}
		}
		else
		{
			mSecondaryFlag = false;
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}