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
		Debug.Log("[Equipment.cs] Equipping " + gameObject.name);
		if(mPlayerObject)
		{
			Gear gear = mPlayerObject.GetGear();
			switch(mEquipmentType)
			{
				case Equipment.Type.Arm:
					if(gear.GetArmSlot().GetSlotEquipment())
					{
						gear.GetArmSlot().GetSlotEquipment().Unequip();
					}

					gear.GetArmSlot().SetSlotEquipment(this);
					transform.position = gear.GetArmSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Back:
					if(gear.GetBackSlot().GetSlotEquipment())
					{
						gear.GetBackSlot().GetSlotEquipment().Unequip();
					}

					gear.GetBackSlot().SetSlotEquipment(this);
					transform.position = gear.GetBackSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Chest:
					if(gear.GetChestSlot().GetSlotEquipment())
					{
						gear.GetChestSlot().GetSlotEquipment().Unequip();
					}

					gear.GetChestSlot().SetSlotEquipment(this);
					transform.position = gear.GetChestSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Foot:
					if(gear.GetFootSlot().GetSlotEquipment())
					{
						gear.GetFootSlot().GetSlotEquipment().Unequip();
					}

					gear.GetFootSlot().SetSlotEquipment(this);
					transform.position = gear.GetFootSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Hand:
					if(mPlayerObject.IsLeftHanded())
					{
						if(gear.GetLeftHandSlot().GetSlotEquipment())
						{
							if(gear.GetRightHandSlot().GetSlotEquipment())
							{
								gear.GetLeftHandSlot().GetSlotEquipment().Unequip();
								gear.GetLeftHandSlot().SetSlotEquipment(this);
								transform.position = gear.GetLeftHandSlot().GetSlotPosition().position;
							}
							else
							{
								gear.GetRightHandSlot().SetSlotEquipment(this);
								transform.position = gear.GetRightHandSlot().GetSlotPosition().position;
							}
						}
						else
						{
							gear.GetLeftHandSlot().SetSlotEquipment(this);
							transform.position = gear.GetLeftHandSlot().GetSlotPosition().position;
						}
					}
					else
					{
						if(mPlayerObject.GetGear().GetRightHandSlot().GetSlotEquipment())
						{
							if(mPlayerObject.GetGear().GetLeftHandSlot().GetSlotEquipment())
							{
								mPlayerObject.GetGear().GetRightHandSlot().GetSlotEquipment().Unequip();
								mPlayerObject.GetGear().GetRightHandSlot().SetSlotEquipment(this);
								transform.position = mPlayerObject.GetGear().GetRightHandSlot().GetSlotPosition().position;
							}
							else
							{
								mPlayerObject.GetGear().GetLeftHandSlot().SetSlotEquipment(this);
								transform.position = mPlayerObject.GetGear().GetLeftHandSlot().GetSlotPosition().position;
							}
						}
						else
						{
							mPlayerObject.GetGear().GetRightHandSlot().SetSlotEquipment(this);
							transform.position = mPlayerObject.GetGear().GetRightHandSlot().GetSlotPosition().position;
						}
					}
					break;
				case Equipment.Type.Head:
					if(gear.GetHeadSlot().GetSlotEquipment())
					{
						gear.GetHeadSlot().GetSlotEquipment().Unequip();
					}

					gear.GetHeadSlot().SetSlotEquipment(this);
					transform.position = gear.GetHeadSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Leg:
					if(gear.GetLegSlot().GetSlotEquipment())
					{
						gear.GetLegSlot().GetSlotEquipment().Unequip();
					}

					gear.GetLegSlot().SetSlotEquipment(this);
					transform.position = gear.GetLegSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Shoulder:
					if(gear.GetShoulderSlot().GetSlotEquipment())
					{
						gear.GetShoulderSlot().GetSlotEquipment().Unequip();
					}

					gear.GetShoulderSlot().SetSlotEquipment(this);
					transform.position = gear.GetShoulderSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Waist:
					if(gear.GetWaistSlot().GetSlotEquipment())
					{
						gear.GetWaistSlot().GetSlotEquipment().Unequip();
					}

					gear.GetWaistSlot().SetSlotEquipment(this);
					transform.position = gear.GetWaistSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.NONE:
					Debug.LogError("[Equipment.cs] Unable to equip " + gameObject.name + ". No equipment type");
					break;
			}
		}
		else if(mNPCObject)
		{
			Gear gear = mNPCObject.GetGear();
			switch(mEquipmentType)
			{
				case Equipment.Type.Arm:
					if(gear.GetArmSlot().GetSlotEquipment())
					{
						gear.GetArmSlot().GetSlotEquipment().Unequip();
					}

					gear.GetArmSlot().SetSlotEquipment(this);
					transform.position = gear.GetArmSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Back:
					if(gear.GetBackSlot().GetSlotEquipment())
					{
						gear.GetBackSlot().GetSlotEquipment().Unequip();
					}

					gear.GetBackSlot().SetSlotEquipment(this);
					transform.position = gear.GetBackSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Chest:
					if(gear.GetChestSlot().GetSlotEquipment())
					{
						gear.GetChestSlot().GetSlotEquipment().Unequip();
					}

					gear.GetChestSlot().SetSlotEquipment(this);
					transform.position = gear.GetChestSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Foot:
					if(gear.GetFootSlot().GetSlotEquipment())
					{
						gear.GetFootSlot().GetSlotEquipment().Unequip();
					}

					gear.GetFootSlot().SetSlotEquipment(this);
					transform.position = gear.GetFootSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Hand:
					if(mNPCObject.GetGear().GetRightHandSlot().GetSlotEquipment())
					{
						if(mNPCObject.GetGear().GetLeftHandSlot().GetSlotEquipment())
						{
							mNPCObject.GetGear().GetRightHandSlot().GetSlotEquipment().Unequip();
							mNPCObject.GetGear().GetRightHandSlot().SetSlotEquipment(this);
							transform.position = mNPCObject.GetGear().GetRightHandSlot().GetSlotPosition().position;
						}
						else
						{
							mNPCObject.GetGear().GetLeftHandSlot().SetSlotEquipment(this);
							transform.position = mNPCObject.GetGear().GetLeftHandSlot().GetSlotPosition().position;
						}
					}
					else
					{
						mNPCObject.GetGear().GetRightHandSlot().SetSlotEquipment(this);
						transform.position = mNPCObject.GetGear().GetRightHandSlot().GetSlotPosition().position;
					}
					break;
				case Equipment.Type.Head:
					if(gear.GetHeadSlot().GetSlotEquipment())
					{
						gear.GetHeadSlot().GetSlotEquipment().Unequip();
					}

					gear.GetHeadSlot().SetSlotEquipment(this);
					transform.position = gear.GetHeadSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Leg:
					if(gear.GetLegSlot().GetSlotEquipment())
					{
						gear.GetLegSlot().GetSlotEquipment().Unequip();
					}

					gear.GetLegSlot().SetSlotEquipment(this);
					transform.position = gear.GetLegSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Shoulder:
					if(gear.GetShoulderSlot().GetSlotEquipment())
					{
						gear.GetShoulderSlot().GetSlotEquipment().Unequip();
					}

					gear.GetShoulderSlot().SetSlotEquipment(this);
					transform.position = gear.GetShoulderSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.Waist:
					if(gear.GetWaistSlot().GetSlotEquipment())
					{
						gear.GetWaistSlot().GetSlotEquipment().Unequip();
					}

					gear.GetWaistSlot().SetSlotEquipment(this);
					transform.position = gear.GetWaistSlot().GetSlotPosition().position;
					break;
				case Equipment.Type.NONE:
					Debug.LogError("[Equipment.cs] Unable to equip " + gameObject.name + ". No equipment type");
					break;
			}
		}
	}
	public virtual void Unequip()
	{
		Debug.Log("[Equipment.cs] Unequipping " + gameObject.name);
		Gear gear = new Gear();
		if(mPlayerObject)
		{
			gear = mPlayerObject.GetGear();
		}
		else if(mNPCObject)
		{
			gear = mNPCObject.GetGear();
		}
		
		
		switch(mEquipmentType)
		{
			case Equipment.Type.Arm:
				gear.GetArmSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.Back:
				gear.GetBackSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.Chest:
				gear.GetChestSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.Foot:
				gear.GetFootSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.Hand:
				if(gear.GetLeftHandSlot().GetSlotEquipment() == this)
				{
					gear.GetLeftHandSlot().SetSlotEquipment(null);
				}
				else
				{
					gear.GetRightHandSlot().SetSlotEquipment(null);
				}
				break;
			case Equipment.Type.Head:
				gear.GetHeadSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.Leg:
				gear.GetLegSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.Shoulder:
				gear.GetShoulderSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.Waist:
				gear.GetWaistSlot().SetSlotEquipment(null);
				break;
			case Equipment.Type.NONE:
				Debug.LogError("[Equipment.cs] Unable to unequip " + gameObject.name + ". No equipment type");
				break;
		}
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