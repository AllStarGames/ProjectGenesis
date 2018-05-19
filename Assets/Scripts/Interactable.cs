using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public enum Type
	{
		Enemy = 1,
		Item = 2,
		NPC = 3,
		Object = 4,
		NONE = 0
	}

	private bool mIsHighlighted;
	[SerializeField]
	private float mInterationRange;
	[SerializeField]
	private Type mType;

	public bool IsHighlighted()
	{
		return mIsHighlighted;
	}
	public Type GetType()
	{
		return mType;
	}

	public void Highlight(bool value)
	{
		mIsHighlighted = value;
	}
	public void Interact()
	{
		PlayerManager.GetLocalPlayer().transform.LookAt(transform);

		switch(mType)
		{
			case Type.Enemy:
				//Attack the enemy
				Weapon leftWeapon = PlayerManager.GetLocalPlayer().GetGear().GetLeftHandSlot().GetSlotEquipment().GetComponent<Weapon>();
				Weapon rightWeapon = PlayerManager.GetLocalPlayer().GetGear().GetRightHandSlot().GetSlotEquipment().GetComponent<Weapon>();

				if(leftWeapon && leftWeapon.InRange(PlayerManager.GetLocalPlayer().GetTransform(), transform))
				{
					if(!PlayerManager.GetLocalPlayer().GetNavAgent().isStopped)
					{
						PlayerManager.GetLocalPlayer().GetNavAgent().nextPosition = PlayerManager.GetLocalPlayer().GetPosition();
						PlayerManager.GetLocalPlayer().GetNavAgent().isStopped = true;
					}
					else
					{
						PlayerManager.GetLocalPlayer().GetAnimator().SetBool("attacking", true);
						
						Damage damage = leftWeapon.CalculateDamage();
						if(leftWeapon.IsSecondaryModeActive())
						{
							if(damage.GetAmount() != 0.0f)
							{
								switch(leftWeapon.GetSecondaryDamage().GetDamageType())
								{
									case Damage.Type.Magical:
										PlayerManager.GetLocalPlayer().SetNumMagicalUses(PlayerManager.GetLocalPlayer().GetNumMagicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetIntellectStat());
										break;
									case Damage.Type.Physical:
										PlayerManager.GetLocalPlayer().SetNumPhysicalUses(PlayerManager.GetLocalPlayer().GetNumPhysicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetStrengthStat());
										break;
									case Damage.Type.NONE:
										Debug.LogError("[Interactable.cs] " + leftWeapon.name + " has no secondary damage type! Please make sure it has been intialized correctly!");
										break;
								}
							}
						}
						else
						{
							if(damage.GetAmount() != 0.0f)
							{
								switch(leftWeapon.GetMainDamage().GetDamageType())
								{
									case Damage.Type.Magical:
										PlayerManager.GetLocalPlayer().SetNumMagicalUses(PlayerManager.GetLocalPlayer().GetNumMagicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetIntellectStat());
										break;
									case Damage.Type.Physical:
										PlayerManager.GetLocalPlayer().SetNumPhysicalUses(PlayerManager.GetLocalPlayer().GetNumPhysicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetStrengthStat());
										break;
									case Damage.Type.NONE:
										Debug.LogError("[Interactable.cs] " + leftWeapon.name + " has no primary damage type! Please make sure it has been intialized correctly!");
										break;
								}
							}
						}

						GetComponent<HealthSystem>().TakeDamage(damage);
						leftWeapon.GrantExperienceToClass(1);
						if(!leftWeapon.GetIndestructibleFlag())
						{
							leftWeapon.Weaken(1.0f);
						}
					}
				}
				if(rightWeapon && rightWeapon.InRange(PlayerManager.GetLocalPlayer().GetTransform(), transform))
				{
					if(!PlayerManager.GetLocalPlayer().GetNavAgent().isStopped)
					{
						PlayerManager.GetLocalPlayer().GetNavAgent().nextPosition = PlayerManager.GetLocalPlayer().GetPosition();
						PlayerManager.GetLocalPlayer().GetNavAgent().isStopped = true;
					}
					else
					{
						PlayerManager.GetLocalPlayer().GetAnimator().SetBool("attacking", true);
						
						Damage damage = rightWeapon.CalculateDamage();
						if(rightWeapon.IsSecondaryModeActive())
						{
							if(damage.GetAmount() != 0.0f)
							{
								switch(rightWeapon.GetSecondaryDamage().GetDamageType())
								{
									case Damage.Type.Magical:
										PlayerManager.GetLocalPlayer().SetNumMagicalUses(PlayerManager.GetLocalPlayer().GetNumMagicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetIntellectStat());
										break;
									case Damage.Type.Physical:
										PlayerManager.GetLocalPlayer().SetNumPhysicalUses(PlayerManager.GetLocalPlayer().GetNumPhysicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetStrengthStat());
										break;
									case Damage.Type.NONE:
										Debug.LogError("[Interactable.cs] " + rightWeapon.name + " has no secondary damage type! Please make sure it has been intialized correctly!");
										break;
								}
							}
						}
						else
						{
							if(damage.GetAmount() != 0.0f)
							{
								switch(rightWeapon.GetMainDamage().GetDamageType())
								{
									case Damage.Type.Magical:
										PlayerManager.GetLocalPlayer().SetNumMagicalUses(PlayerManager.GetLocalPlayer().GetNumMagicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetIntellectStat());
										break;
									case Damage.Type.Physical:
										PlayerManager.GetLocalPlayer().SetNumPhysicalUses(PlayerManager.GetLocalPlayer().GetNumPhysicalUses() + 1);
										damage.SetAmount(damage.GetAmount() + PlayerManager.GetLocalPlayer().GetStats().GetStrengthStat());
										break;
									case Damage.Type.NONE:
										Debug.LogError("[Interactable.cs] " + rightWeapon.name + " has no primary damage type! Please make sure it has been intialized correctly!");
										break;
								}
							}
						}

						GetComponent<HealthSystem>().TakeDamage(damage);
						rightWeapon.GrantExperienceToClass(1);
						if(!rightWeapon.GetIndestructibleFlag())
						{
							rightWeapon.Weaken(1.0f);
						}
					}
				}
				break;
			case Type.Item:
				//Pick up the item
				break;
			case Type.NPC:
				//Talk to the NPC
				break;
			case Type.Object:
				//Interact with the object
				break;
			case Type.NONE:
				Debug.LogError("[Interact.cs] " + gameObject.name + " interaction type not specified! Please make sure it has been initialized correctly!");
				break;
		}
	}
	public void SetType(Type interactionType)
	{
		mType = interactionType;
	}

	/// <summary>
	/// Called every frame while the mouse is over the GUIElement or Collider.
	/// </summary>
	void OnMouseOver()
	{
		//Highlight this NPC and set it as the player's focus
		mIsHighlighted = true;
		PlayerManager.GetLocalPlayer().SetFocus(gameObject);

		if(GetComponentInChildren<SkinnedMeshRenderer>())
		{
			foreach(Material material in GetComponentInChildren<SkinnedMeshRenderer>().materials)
			{
				material.shader = Shader.Find("Unlit/Outline_Diffuse");
			}
		}
		else if(GetComponent<MeshRenderer>())
		{
			foreach(Material material in GetComponent<MeshRenderer>().materials)
			{
				material.shader = Shader.Find("Unlit/Outline_Diffuse");
			}
		}
	}
	/// <summary>
	/// Called when the mouse is not any longer over the GUIElement or Collider.
	/// </summary>
	void OnMouseExit()
	{
		if(!Input.GetMouseButton(0))
		{
			mIsHighlighted = false;
			PlayerManager.GetLocalPlayer().SetFocus(null);
			if(GetComponentInChildren<SkinnedMeshRenderer>())
			{
				foreach(Material material in GetComponentInChildren<SkinnedMeshRenderer>().materials)
				{
					material.shader = Shader.Find("Standard");
				}
			}
			else if(GetComponent<MeshRenderer>())
			{
				foreach(Material material in GetComponent<MeshRenderer>().materials)
				{
					material.shader = Shader.Find("Standard");
				}
			}
		}
	}
	// Use this for initialization
	void Start ()
	{
		mIsHighlighted = false;	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}