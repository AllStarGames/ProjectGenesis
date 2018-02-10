using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
	public enum SlotType
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

    public bool indestructable;
    public float breakChance;
    public float durability;
    public int level;
    public int levelRequirement;

    private float currentDurabiltiy;

	public SlotType slotType;

	public SlotType GetSlotType()
	{
		return slotType;
	}

    public bool Indestructable()
    {
        return indestructable;
    }
    public float CurrentDurability()
    {
        return currentDurabiltiy;
    }
    public float Durability()
    {
        return durability;
    }
    public int Level()
    {
        return level;
    }
    public int LevelRequirement()
    {
        return levelRequirement;
    }
    public void Break()
    {
        //Remove form player's equipment

        
        //Remove from player's inventory
        //PlayerManager.GetPlayerInventory().Remove(gameObject.GetComponent<Item>());

        //Destroy the object
        print(gameObject.name + " has been destroyed!");
        DestroyImmediate(gameObject, true);
    }
    public void Weaken(float value)
    {
        currentDurabiltiy -= value;
        if(currentDurabiltiy <= 0.0f)
        {
            Break();
        }
    }
    public void SetLevelRequirement(int value)
    {
        levelRequirement = value;
    }
    public void Start()
    {
        //Set the level of the equipment
        level = 1;
    }
    public void Strengthen(float value)
    {
        currentDurabiltiy += value;
        if(currentDurabiltiy >= durability)
        {
            currentDurabiltiy = durability;
        }
    }

    void OnEnable()
    {
        //Set the durability to something random
        float value = Random.Range(10.0f, durability);
        currentDurabiltiy = value;
    }

	/*public virtual void Equip() 
	{
		if (PlayerManager.GetPlayerStats ().level >= levelRequirement) 
		{
			foreach (Player.EquipmentSlot slot in PlayerManager.GetPlayerEquipmentList()) 
			{
				if (slot.SlotType == slotType) 
				{
					//if(slot.SlotType == SlotType.Hand           // compare player´s actual slot to the equipments slot name 
					if (slot.equipment) 
					{
						slot.equipment.Unequip (slot);
					}
					slot.equipment = this;
					gameObject.transform.position = slot.SlotPosition.position;
					gameObject.GetComponent<Rigidbody> ().useGravity = false;
					gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
                    gameObject.SetActive(true);
					break;
				}
			}
		}
	}*/

    /*public virtual void Unequip(Player.EquipmentSlot slotToUnequip)
    {
        foreach (Player.EquipmentSlot slot in PlayerManager.GetPlayerEquipmentList())
        {
            if (slotToUnequip.SlotType == slotType)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                slotToUnequip.equipment = null;
                gameObject.SetActive(false);
            }
        }
    }*/
}