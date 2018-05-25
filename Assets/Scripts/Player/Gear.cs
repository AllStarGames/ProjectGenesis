using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gear : MonoBehaviour
{
	[System.Serializable]
	public struct Slot
	{
		private Equipment mEquipment;
		private Equipment.Type mType;
		[SerializeField]
		private Transform mPosition;

		public Equipment GetSlotEquipment()
		{
			return mEquipment;
		}
		public Equipment.Type GetSlotType()
		{
			return mType;
		}
		public Transform GetSlotPosition()
		{
			return mPosition;
		}
		public void SetSlotEquipment(Equipment equipment)
		{
			mEquipment = equipment;
		}
		public void SetSlotPosition(Transform transform)
		{
			mPosition = transform;
		}
		public void SetSlotType(Equipment.Type type)
		{
			mType = type;
		}
	}

	[SerializeField]
	private Slot mArmGear;
	[SerializeField]
	private Slot mBackGear;
	[SerializeField]
	private Slot mChestGear;
	[SerializeField]
	private Slot mFootGear;
	[SerializeField]
	private Slot mHeadGear;
	[SerializeField]
	private Slot mLeftHand;
	[SerializeField]
	private Slot mLegGear;
	[SerializeField]
	private Slot mRightHand;
	[SerializeField]
	private Slot mShoulderGear;
	[SerializeField]
	private Slot mWaistGear;

	public Slot GetArmSlot()
	{
		return mArmGear;
	}
	public Slot GetBackSlot()
	{
		return mBackGear;
	}
	public Slot GetChestSlot()
	{
		return mChestGear;
	}
	public Slot GetFootSlot()
	{
		return mFootGear;
	}
	public Slot GetHeadSlot()
	{
		return mHeadGear;
	}
	public Slot GetLeftHandSlot()
	{
		return mLeftHand;
	}
	public Slot GetLegSlot()
	{
		return mLegGear;
	}
	public Slot GetRightHandSlot()
	{
		return mRightHand;
	}
	public Slot GetShoulderSlot()
	{
		return mShoulderGear;
	}
	public Slot GetWaistSlot()
	{
		return mWaistGear;
	}

	// Use this for initialization
	void Start ()
	{
		mArmGear.SetSlotType(Equipment.Type.Arm);
		mBackGear.SetSlotType(Equipment.Type.Back);
		mChestGear.SetSlotType(Equipment.Type.Chest);
		mFootGear.SetSlotType(Equipment.Type.Foot);
		mHeadGear.SetSlotType(Equipment.Type.Head);
		mLeftHand.SetSlotType(Equipment.Type.Hand);
		mLegGear.SetSlotType(Equipment.Type.Leg);
		mRightHand.SetSlotType(Equipment.Type.Hand);
		mShoulderGear.SetSlotType(Equipment.Type.Shoulder);
		mWaistGear.SetSlotType(Equipment.Type.Waist);

		//Set all the preset gear
		foreach(Equipment equipment in GetComponentsInChildren<Equipment>())
		{
			equipment.Equip();
		}
	}
}