using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkills : MonoBehaviour
{
	private WeaponStats mAxeSkill;
	private WeaponStats mBowSkill;
	private WeaponStats mCannonSkill;
	private WeaponStats mFistSkill;
	private WeaponStats mKnifeSkill;
	private WeaponStats mMaceSkill;
	private WeaponStats mPistolSkill;
	private WeaponStats mPolearmSkill;
	private WeaponStats mRifleSkill;
	private WeaponStats mStaffSkill;
	private WeaponStats mSwordSkill;
	private WeaponStats mTwoHandedAxeSkill;
	private WeaponStats mTwoHandedMaceSkill;
	private WeaponStats mTwoHandedSwordSkill;
	private WeaponStats mWandSkill;

	public WeaponStats GetAxeStats()
	{
		return mAxeSkill;
	}
	public WeaponStats GetBowStats()
	{
		return mBowSkill;
	}
	public WeaponStats GetCannonStats()
	{
		return mCannonSkill;
	}
	public WeaponStats GetFistStats()
	{
		return mFistSkill;
	}
	public WeaponStats GetKnifeStats()
	{
		return mKnifeSkill;
	}
	public WeaponStats GetMaceStats()
	{
		return mMaceSkill;
	}
	public WeaponStats GetPistolStats()
	{
		return mPistolSkill;
	}
	public WeaponStats GetPolearmStats()
	{
		return mPolearmSkill;
	}
	public WeaponStats GetRifleStats()
	{
		return mRifleSkill;
	}
	public WeaponStats GetStaffStats()
	{
		return mStaffSkill;
	}
	public WeaponStats GetSwordStats()
	{
		return mSwordSkill;
	}
	public WeaponStats GetTwoHandedAxeStats()
	{
		return mTwoHandedAxeSkill;
	}
	public WeaponStats GetTwoHandedMaceStats()
	{
		return mTwoHandedMaceSkill;
	}
	public WeaponStats GetTwoHandedSwordStats()
	{
		return mTwoHandedSwordSkill;
	}
	public WeaponStats GetWandStats()
	{
		return mWandSkill;
	}
	public void Initialize()
	{
		mAxeSkill = new WeaponStats();
		mAxeSkill.Initialize();

		mBowSkill = new WeaponStats();
		mBowSkill.Initialize();
		
		mCannonSkill = new WeaponStats();
		mCannonSkill.Initialize();

		mFistSkill = new WeaponStats();
		mFistSkill.Initialize();

		mKnifeSkill = new WeaponStats();
		mKnifeSkill.Initialize();

		mMaceSkill = new WeaponStats();
		mMaceSkill.Initialize();

		mPistolSkill = new WeaponStats();
		mPistolSkill.Initialize();
		
		mPolearmSkill = new WeaponStats();
		mPolearmSkill.Initialize();

		mRifleSkill = new WeaponStats();
		mRifleSkill.Initialize();

		mStaffSkill = new WeaponStats();
		mStaffSkill.Initialize();

		mSwordSkill = new WeaponStats();
		mSwordSkill.Initialize();

		mTwoHandedAxeSkill = new WeaponStats();
		mTwoHandedAxeSkill.Initialize();

		mTwoHandedMaceSkill = new WeaponStats();
		mTwoHandedMaceSkill.Initialize();

		mTwoHandedSwordSkill = new WeaponStats();
		mTwoHandedSwordSkill.Initialize();

		mWandSkill = new WeaponStats();
		mWandSkill.Initialize();
	}
	public void SetAxeStats(WeaponStats axeStats)
	{
		mAxeSkill = axeStats;
	}
	public void SetBowStats(WeaponStats bowStats)
	{
		mBowSkill = bowStats;
	}
	public void SetCannonStats(WeaponStats cannonStats)
	{
		mCannonSkill = cannonStats;
	}
	public void SetFistStats(WeaponStats FistStats)
	{
		mFistSkill = FistStats;
	}
	public void SetKnifeStats(WeaponStats knifeStats)
	{
		mKnifeSkill = knifeStats;
	}
	public void SetMaceStats(WeaponStats maceStats)
	{
		mMaceSkill = maceStats;
	}
	public void SetPistolStats(WeaponStats pistolStats)
	{
		mPistolSkill = pistolStats;
	}
	public void SetPolearmStats(WeaponStats polearmStats)
	{
		mPolearmSkill = polearmStats;
	}
	public void SetRifleStats(WeaponStats rifleStats)
	{
		mRifleSkill = rifleStats;
	}
	public void SetStaffStats(WeaponStats staffStats)
	{
		mStaffSkill = staffStats;
	}
	public void SetSwordStats(WeaponStats swordStats)
	{
		mSwordSkill = swordStats;
	}
	public void SetTwoHandedAxeStats(WeaponStats twoHandedAxeStats)
	{
		mTwoHandedAxeSkill = twoHandedAxeStats;
	}
	public void SetTwoHandedMaceStats(WeaponStats twoHandedMaceStats)
	{
		mTwoHandedMaceSkill = twoHandedMaceStats;
	}
	public void SetTwoHandedSwordStats(WeaponStats twoHandedSwordStats)
	{
		mTwoHandedSwordSkill = twoHandedSwordStats;
	}
	public void SetWandStats(WeaponStats wandStats)
	{
		mWandSkill = wandStats;
	}
}