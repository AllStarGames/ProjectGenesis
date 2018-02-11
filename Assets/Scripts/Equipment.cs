using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment : MonoBehaviour 
{
	public enum Type
	{
		Arm = 1,
		Back = 2,
		Chest = 3,
		Foot = 4,
		Hand = 5,
		Head = 6,
		Leg = 7,
		Shoulder = 8,
		Waist = 9,
		NONE = 0
	}

	[SerializeField]
	private bool mIsIndestructible;
	private float mDurability;
	[SerializeField]
	private int mLevelRequirement = 1;
	[SerializeField]
	private Equipment.Type mEquipmentType = Equipment.Type.NONE;

	public virtual void Equip()
	{

	}
	public virtual void Unequip()
	{

	}

	public bool GetIndestructibleFlag()
	{
		return mIsIndestructible;
	}
	public float GetDurability()
	{
		return mDurability;
	}
	public int GetLevelRequirement()
	{
		return mLevelRequirement;
	}
	public Equipment.Type GetEquipmentType()
	{
		return mEquipmentType;
	}
	public void Break()
	{
		if(GameManager.DebugMode())
		{
			Debug.Log("[Equipment.cs] " + gameObject.name + " has broken!");
		}
		//Unequip and remove it from the player's inventory
		Unequip();

		//Destroy the object
		Destroy(gameObject);
	}
	public void SetDurability(float value)
	{
		mDurability = value;
	}
	public void SetIndestructibleFlag(bool value)
	{
		mIsIndestructible = value;
	}
	public void SetEquipmentType(Equipment.Type type)
	{
		mEquipmentType = type;
	}
	public void SetLevelRequirement(int level)
	{
		mLevelRequirement = level;
	}
	public void Strengthen(float value)
	{
		if(!mIsIndestructible)
		{
			mDurability += value;
			if(mDurability > 100.0f)
			{
				mDurability = 100.0f;
			}
		}
	}
	public void Weaken(float value)
	{
		if(!mIsIndestructible)
		{
			mDurability -= value;
			if(mDurability <= 0.0f)
			{
				Break();
			}
		}
	}

	void OnEnable()
	{
		mDurability = Random.Range(10.0f, 100.0f);
	}
}