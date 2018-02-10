using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour 
{
	public enum Type
	{
		Arm,
		Back,
		Chest,
		Foot,
		Hand,
		Head,
		Leg,
		Shoulder,
		Waist
	}

	[SerializeField]
	private int mLevelRequirement;
	[SerializeField]
	private Equipment.Type mType;

	public int GetLevelRequirement()
	{
		return mLevelRequirement;
	}
	public Equipment.Type GetEquipmentType()
	{
		return mType;
	}
	public void SetEquipmentType(Equipment.Type type)
	{
		mType = type;
	}
	public void SetLevelRequirement(int level)
	{
		mLevelRequirement = level;
	}
}