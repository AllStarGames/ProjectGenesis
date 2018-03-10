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
        Knife = 4,
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
		Melee = 1,
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
	public Damage CalculateDamage()
	{
        Damage totalDamage = new Damage();

		//Do a mode check
		if(mIsSecondaryModeActive)
		{
            totalDamage.SetDamageType(mSecondaryDamage.GetDamageType());

            //Check for a critical hit
            float critChance = Random.Range(0.0f, 100.0f);
            if(mNPCObject)
            {
                switch(mSecondaryClass)
                {
                    case Classification.Axe:
                        if(critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetAxeStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Bow:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetBowStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetBowStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetBowStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Cannon:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetCannonStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetCannonStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetCannonStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Knife:
                        if(critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetKnifeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Mace:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetMaceStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Pistol:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetPistolStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPistolStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPistolStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Polearm:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetPolearmStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Rifle:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetRifleStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetRifleStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetRifleStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Staff:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetStaffStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetStaffStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetStaffStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Sword:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetSwordStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Unarmed:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Wand:
                        if (critChance <= mSecondaryCriticalChance + mNPCObject.GetWeaponSkills().GetWandStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetWandStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetWandStats().GetDamageBonus());
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no secondary classification! Either the weapon isn't hybrid or hasn't been initialized correctly!");
                        break;
                }
            }
            else if(mPlayerObject)
            {
                switch (mSecondaryClass)
                {
                    case Classification.Axe:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetAxeStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Bow:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetBowStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetBowStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetBowStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Cannon:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetCannonStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetCannonStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetCannonStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Knife:
                        if(critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetKnifeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Mace:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetMaceStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Pistol:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetPistolStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPistolStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPistolStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Polearm:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Rifle:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetRifleStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetRifleStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetRifleStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Staff:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetStaffStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetStaffStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetStaffStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Sword:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetSwordStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Unarmed:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Wand:
                        if (critChance <= mSecondaryCriticalChance + mPlayerObject.GetWeaponSkills().GetWandStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetWandStats().GetDamageBonus()) * mSecondaryCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mSecondaryDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetWandStats().GetDamageBonus());
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no secondary classification! Either the weapon isn't hybrid or hasn't been initialized correctly!");
                        break;
                }
            }
            else
            {
                Debug.LogError("[Weapon.cs] " + gameObject.name + " could not find a NPC or Player script attached to object!");
            }

            //Check for a miss
            float hitChance = Random.Range(0.0f, 100.0f);
            if (mNPCObject)
            {
                switch (mSecondaryClass)
                {
                    case Classification.Axe:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Bow:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetBowStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Cannon:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetCannonStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Knife:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetKnifeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Mace:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Pistol:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetPistolStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Polearm:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetPolearmStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Rifle:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetRifleStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Staff:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetStaffStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Sword:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Unarmed:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Wand:
                        if (hitChance > mSecondaryAccuracy + mNPCObject.GetWeaponSkills().GetWandStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no secondary classification! Either the weapon isn't hybrid or hasn't been initialized correctly!");
                        break;
                }
            }
            else if (mPlayerObject)
            {
                switch (mSecondaryClass)
                {
                    case Classification.Axe:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Bow:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetBowStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Cannon:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetCannonStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Knife:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetKnifeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Mace:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Pistol:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetPistolStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Polearm:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Rifle:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetRifleStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Staff:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetStaffStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Sword:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Unarmed:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Wand:
                        if (hitChance > mSecondaryAccuracy + mPlayerObject.GetWeaponSkills().GetWandStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no secondary classification! Either the weapon isn't hybrid or hasn't been initialized correctly!");
                        break;
                }
            }
            else
            {
                Debug.LogError("[Weapon.cs] " + gameObject.name + " could not find a NPC or Player script attached to object!");
            }
        }
		else
		{
            totalDamage.SetDamageType(mMainDamage.GetDamageType());

            //Check for a critical hit
            float critChance = Random.Range(0.0f, 100.0f);
            if (mNPCObject)
            {
                switch (mMainClass)
                {
                    case Classification.Axe:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetAxeStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Bow:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetBowStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetBowStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetBowStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Cannon:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetCannonStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetCannonStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetCannonStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Knife:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetKnifeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Mace:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetMaceStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Pistol:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetPistolStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPistolStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPistolStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Polearm:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetPolearmStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Rifle:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetRifleStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetRifleStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetRifleStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Staff:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetStaffStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetStaffStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetStaffStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Sword:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetSwordStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Unarmed:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Wand:
                        if (critChance <= mMainCriticalChance + mNPCObject.GetWeaponSkills().GetWandStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetWandStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mNPCObject.GetWeaponSkills().GetWandStats().GetDamageBonus());
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no classification! Check that the weapon has been initialized correctly!");
                        break;
                }
            }
            else if (mPlayerObject)
            {
                switch (mMainClass)
                {
                    case Classification.Axe:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetAxeStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Bow:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetBowStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetBowStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetBowStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Cannon:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetCannonStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetCannonStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetCannonStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Knife:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetKnifeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetKnifeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Mace:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetMaceStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Pistol:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetPistolStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPistolStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPistolStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Polearm:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Rifle:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetRifleStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetRifleStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetRifleStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Staff:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetStaffStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetStaffStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetStaffStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Sword:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetSwordStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetDamageBonus());
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Unarmed:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetDamageBonus());
                        }
                        break;
                    case Classification.Wand:
                        if (critChance <= mMainCriticalChance + mPlayerObject.GetWeaponSkills().GetWandStats().GetCriticalChanceBonus())
                        {
                            totalDamage.SetAmount((mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetWandStats().GetDamageBonus()) * mMainCriticalMultiplier);
                        }
                        else
                        {
                            totalDamage.SetAmount(mMainDamage.GetAmount() + mPlayerObject.GetWeaponSkills().GetWandStats().GetDamageBonus());
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no classification! Check that the weapon has been initialized correctly!");
                        break;
                }
            }
            else
            {
                Debug.LogError("[Weapon.cs] " + gameObject.name + " could not find a NPC or Player script attached to object!");
            }

            //Check for a miss
            float hitChance = Random.Range(0.0f, 100.0f);
            if (mNPCObject)
            {
                switch (mMainClass)
                {
                    case Classification.Axe:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Bow:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetBowStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Cannon:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetCannonStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Knife:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetKnifeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Mace:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Pistol:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetPistolStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Polearm:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetPolearmStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Rifle:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetRifleStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Staff:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetStaffStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Sword:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Unarmed:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetUnarmedStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Wand:
                        if (hitChance > mMainAccuracy + mNPCObject.GetWeaponSkills().GetWandStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no classification! Check that the weapon has been initialized correctly!");
                        break;
                }
            }
            else if (mPlayerObject)
            {
                switch (mMainClass)
                {
                    case Classification.Axe:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Bow:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetBowStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Cannon:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetCannonStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Knife:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetKnifeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Mace:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Pistol:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetPistolStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Polearm:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetPolearmStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Rifle:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetRifleStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Staff:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetStaffStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Sword:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedAxe:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedMace:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.TwoHandedSword:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Unarmed:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.Wand:
                        if (hitChance > mMainAccuracy + mPlayerObject.GetWeaponSkills().GetWandStats().GetAccuracyBonus())
                        {
                            totalDamage.SetAmount(0.0f);
                        }
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] " + gameObject.name + " has no classification! Check that the weapon has been initialized correctly!");
                        break;
                }
            }
            else
            {
                Debug.LogError("[Weapon.cs] " + gameObject.name + " could not find a NPC or Player script attached to object!");
            }
        }

        return totalDamage;
	}
	public Damage GetMainDamage()
	{
		return mMainDamage;
	}
	public Damage GetSecondaryDamage()
	{
		return mSecondaryDamage;
	}
	public float CalculateSpeed()
	{
		float totalSpeed = 0.0f;

		//Do a mode check
		if(mIsSecondaryModeActive)
		{
			totalSpeed = mSecondarySpeed;
            if(mNPCObject)
            {
                switch (mSecondaryClass)
                {
                    case Classification.Axe:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetAxeStats().GetSpeedBonus();
                        break;
                    case Classification.Bow:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetBowStats().GetSpeedBonus();
                        break;
                    case Classification.Cannon:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetCannonStats().GetSpeedBonus();
                        break;
                    case Classification.Knife:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetKnifeStats().GetSpeedBonus();
                        break;
                    case Classification.Mace:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetMaceStats().GetSpeedBonus();
                        break;
                    case Classification.Pistol:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetPistolStats().GetSpeedBonus();
                        break;
                    case Classification.Polearm:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetPolearmStats().GetSpeedBonus();
                        break;
                    case Classification.Rifle:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetRifleStats().GetSpeedBonus();
                        break;
                    case Classification.Staff:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetStaffStats().GetSpeedBonus();
                        break;
                    case Classification.Sword:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetSwordStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedAxe:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedMace:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedSword:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetSpeedBonus();
                        break;
                    case Classification.Unarmed:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetUnarmedStats().GetSpeedBonus();
                        break;
                    case Classification.Wand:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetWandStats().GetSpeedBonus();
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] No secondary class assigned to the weapon " + gameObject.name + ". Either weapon isn't a hybrid or hasn't been initialized correctly!");
                        break;
                }
            }
            else if(mPlayerObject)
            {
                switch (mSecondaryClass)
                {
                    case Classification.Axe:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetAxeStats().GetSpeedBonus();
                        break;
                    case Classification.Bow:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetBowStats().GetSpeedBonus();
                        break;
                    case Classification.Cannon:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetCannonStats().GetSpeedBonus();
                        break;
                    case Classification.Knife:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetKnifeStats().GetSpeedBonus();
                        break;
                    case Classification.Mace:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetMaceStats().GetSpeedBonus();
                        break;
                    case Classification.Pistol:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetPistolStats().GetSpeedBonus();
                        break;
                    case Classification.Polearm:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetPolearmStats().GetSpeedBonus();
                        break;
                    case Classification.Rifle:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetRifleStats().GetSpeedBonus();
                        break;
                    case Classification.Staff:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetStaffStats().GetSpeedBonus();
                        break;
                    case Classification.Sword:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetSwordStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedAxe:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedMace:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedSword:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetSpeedBonus();
                        break;
                    case Classification.Unarmed:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetSpeedBonus();
                        break;
                    case Classification.Wand:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetWandStats().GetSpeedBonus();
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] No secondary class assigned to the weapon " + gameObject.name + ". Either weapon isn't a hybrid or hasn't been initialized correctly!");
                        break;
                }
            }
            else
            {
                Debug.LogError("[Weapon.cs] " + gameObject.name + " could not find NPC or Player script on parent object!");
            }
		}
		else
		{
            totalSpeed = mMainSpeed;
            if (mNPCObject)
            {
                switch (mMainClass)
                {
                    case Classification.Axe:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetAxeStats().GetSpeedBonus();
                        break;
                    case Classification.Bow:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetBowStats().GetSpeedBonus();
                        break;
                    case Classification.Cannon:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetCannonStats().GetSpeedBonus();
                        break;
                    case Classification.Knife:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetKnifeStats().GetSpeedBonus();
                        break;
                    case Classification.Mace:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetMaceStats().GetSpeedBonus();
                        break;
                    case Classification.Pistol:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetPistolStats().GetSpeedBonus();
                        break;
                    case Classification.Polearm:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetPolearmStats().GetSpeedBonus();
                        break;
                    case Classification.Rifle:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetRifleStats().GetSpeedBonus();
                        break;
                    case Classification.Staff:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetStaffStats().GetSpeedBonus();
                        break;
                    case Classification.Sword:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetSwordStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedAxe:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetTwoHandedAxeStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedMace:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetTwoHandedMaceStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedSword:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetTwoHandedSwordStats().GetSpeedBonus();
                        break;
                    case Classification.Unarmed:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetUnarmedStats().GetSpeedBonus();
                        break;
                    case Classification.Wand:
                        totalSpeed += mNPCObject.GetWeaponSkills().GetWandStats().GetSpeedBonus();
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] No secondary class assigned to the weapon " + gameObject.name + ". Either weapon isn't a hybrid or hasn't been initialized correctly!");
                        break;
                }
            }
            else if (mPlayerObject)
            {
                switch (mMainClass)
                {
                    case Classification.Axe:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetAxeStats().GetSpeedBonus();
                        break;
                    case Classification.Bow:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetBowStats().GetSpeedBonus();
                        break;
                    case Classification.Cannon:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetCannonStats().GetSpeedBonus();
                        break;
                    case Classification.Knife:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetKnifeStats().GetSpeedBonus();
                        break;
                    case Classification.Mace:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetMaceStats().GetSpeedBonus();
                        break;
                    case Classification.Pistol:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetPistolStats().GetSpeedBonus();
                        break;
                    case Classification.Polearm:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetPolearmStats().GetSpeedBonus();
                        break;
                    case Classification.Rifle:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetRifleStats().GetSpeedBonus();
                        break;
                    case Classification.Staff:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetStaffStats().GetSpeedBonus();
                        break;
                    case Classification.Sword:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetSwordStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedAxe:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetTwoHandedAxeStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedMace:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetTwoHandedMaceStats().GetSpeedBonus();
                        break;
                    case Classification.TwoHandedSword:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetTwoHandedSwordStats().GetSpeedBonus();
                        break;
                    case Classification.Unarmed:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetUnarmedStats().GetSpeedBonus();
                        break;
                    case Classification.Wand:
                        totalSpeed += mPlayerObject.GetWeaponSkills().GetWandStats().GetSpeedBonus();
                        break;
                    case Classification.NONE:
                        Debug.LogError("[Weapon.cs] No class assigned to the weapon " + gameObject.name + ". Check that weapon has been initialized correctly!");
                        break;
                }
            }
            else
            {
                Debug.LogError("[Weapon.cs] " + gameObject.name + " could not find NPC or Player script on parent object!");
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