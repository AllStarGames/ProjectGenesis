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
    private int mNumAugmentSlots;
    private int mNumEnchantmentSlots;
    [SerializeField]
	private Equipment.Type mEquipmentType = Equipment.Type.NONE;

    protected NPC mNPCObject;
    protected Player mPlayerObject;

    public virtual void Equip()
	{
		switch(mEquipmentType)
		{
			case Equipment.Type.NONE:
				Debug.LogError("[Equipment.cs] Unable to equip " + gameObject.name + ". No equipment type");
				break;
		}
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
    public int GetNumAugmentSlots()
    {
        return mNumAugmentSlots;
    }
    public int GetNumEnchantmentSlots()
    {
        return mNumEnchantmentSlots;
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
    public void SetNumAugmentSlots(int value)
    {
        mNumAugmentSlots = value;
    }
    public void SetNumEnchantmentSlots(int value)
    {
        mNumEnchantmentSlots = value;
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

    void Awake()
    {
        mNPCObject = GetComponentInParent<NPC>();
        mPlayerObject = GetComponentInParent<Player>();
    }
	void OnEnable()
	{
		mDurability = Random.Range(10.0f, 100.0f);
	}
}