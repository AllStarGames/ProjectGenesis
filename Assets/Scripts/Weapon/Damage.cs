using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
	public enum Type
	{
		Magical = 1,
		Physical = 2,
		Tech = 3,
		NONE = 0
	}

	[SerializeField]
	private Type mDamageType = Type.NONE;
	[SerializeField]
	private float mAmount;

	public Type GetDamageType()
	{
		return mDamageType;
	}
	public float GetAmount()
	{
		return mAmount;
	}
	public void SetAmount(float value)
	{
		mAmount = value;
	}
	public void SetDamageType(Type type)
	{
		mDamageType = type;
	}
}