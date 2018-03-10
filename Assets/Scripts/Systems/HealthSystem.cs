using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	[SerializeField]
	private bool mAlwaysRegenHealth;
	private bool mIsDead;
	[SerializeField]
	private bool mIsImmortal;
	private float mHealth;
	private float mHealthRegenTimer;
	private float mShields;
	private float mShieldRegenTimer;
	private NPC mNPCObject;
	private Player mPlayerObject;

	public bool AlwaysRegenHealth()
	{
		return mAlwaysRegenHealth;
	}
	public bool IsDead()
	{
		return mIsDead;
	}
	public bool IsImmortal()
	{
		return mIsImmortal;
	}
	public float GetHealth()
	{
		return mHealth;
	}
	public float GetHealthRegenTimer()
	{
		return mHealthRegenTimer;
	}
	public void DecreaseHealth(float value)
	{
		mHealth -= value;
		if(mHealth <= 0.0f)
		{
			Death();
		}
	}
	public void DecreaseShields(float value)
	{
		mShields -= value;
		if(mShields < 0.0f)
		{
			mShields = 0.0f;
		}
	}
	public void IncreaseHealth(float value)
	{
		mHealth += value;

		if(mPlayerObject)
		{
			if(mHealth > mPlayerObject.GetStats().GetMaxHealth())
			{
				mHealth = mPlayerObject.GetStats().GetMaxHealth();
			}
		}
		else if(mNPCObject)
		{
			if(mHealth > mNPCObject.GetStats().GetMaxHealth())
			{
				mHealth = mNPCObject.GetStats().GetMaxHealth();
			}
		}
	}
	public void IncreaseShields(float value)
	{
		mShields += value;

		if(mPlayerObject)
		{
			if(mShields > mPlayerObject.GetStats().GetMaxShields())
			{
				mShields = mPlayerObject.GetStats().GetMaxShields();
			}
		}
			
		else if(mNPCObject)
		{
			if(mShields > mNPCObject.GetStats().GetMaxShields())
			{
				mShields = mNPCObject.GetStats().GetMaxShields();
			}
		}
	}
	public void Reset()
	{
		mIsDead = false;
		if(mPlayerObject)
		{
			mHealth = mPlayerObject.GetStats().GetMaxHealth();
		}
		else if(mNPCObject)
		{
			mHealth = mNPCObject.GetStats().GetMaxHealth();
		}
	}
	public void SetAlwaysRegenHealthFlag(bool value)
	{
		mAlwaysRegenHealth = value;
	}
	public void SetDeadFlag(bool value)
	{
		mIsDead = value;
	}
	public void SetHealth(float value)
	{
		mHealth = value;
	}
	public void SetHealthRegenTimer(float time)
	{
		mHealthRegenTimer = time;
	}
	public void SetImmortalFlag(bool value)
	{
		mIsImmortal = value;
	}
	public void SetShieldRegenTimer(float time)
	{
		mShieldRegenTimer = time;
	}
	public void SetShields(float value)
	{
		mShields = value;
	}
	public void TakeDamage(Damage damage)
	{
		if(!mIsImmortal)
		{
			if(mPlayerObject)
			{
				mPlayerObject.SetNumTimesHit(mPlayerObject.GetNumTimesHit() + 1);
				float finalDamage = damage.GetAmount();

				if(damage.GetDamageType() == Damage.Type.Magical)
				{
					finalDamage -= mPlayerObject.GetStats().GetWillpowerStat() * 0.1f;
					if(finalDamage <= mShields)
					{
						DecreaseShields(finalDamage);
					}
					else
					{
						float remaining = Mathf.Abs(mShields - finalDamage);
						DecreaseShields(finalDamage);
						DecreaseHealth(remaining);
					}
				}
				else if(damage.GetDamageType() == Damage.Type.Physical || damage.GetDamageType() == Damage.Type.Tech)
				{
					finalDamage -= mPlayerObject.GetStats().GetArmourStat() * 0.1f;
					if(finalDamage <= mShields)
					{
						DecreaseShields(finalDamage);
					}
					else
					{
						float remaining = Mathf.Abs(mShields - finalDamage);
						DecreaseShields(finalDamage);
						DecreaseHealth(remaining);
					}
				}
				else
				{
					Debug.LogError("[HealthSystem.cs] No damage type was assigned to this attack!");
				}
			}
			else if(mNPCObject)
			{
				float finalDamage = damage.GetAmount();

				if(damage.GetDamageType() == Damage.Type.Magical)
				{
					finalDamage -= mNPCObject.GetStats().GetWillpowerStat() * 0.1f;
					if(finalDamage <= mShields)
					{
						DecreaseShields(finalDamage);
					}
					else
					{
						float remaining = Mathf.Abs(mShields - finalDamage);
						DecreaseShields(finalDamage);
						DecreaseHealth(remaining);
					}
				}
				else if(damage.GetDamageType() == Damage.Type.Physical || damage.GetDamageType() == Damage.Type.Tech)
				{
					finalDamage -= mNPCObject.GetStats().GetArmourStat() * 0.1f;
					if(finalDamage <= mShields)
					{
						DecreaseShields(finalDamage);
					}
					else
					{
						float remaining = Mathf.Abs(mShields - finalDamage);
						DecreaseShields(finalDamage);
						DecreaseHealth(remaining);
					}
				}
				else
				{
					Debug.LogError("[HealthSystem.cs] No damage type was assigned to this attack!");
				}
			}
		}
	}

	void Death()
	{
		mIsDead = true;
		if(mPlayerObject)
		{
			//This is a player
		}
		else
		{
			//This is either an enemy or NPC
			if(mNPCObject)
			{
				mNPCObject.GetAnimator().SetBool("dead", true);
				mNPCObject.CleanUp();
			}
		}
	}
	void RegenerateHealth()
	{
		if(mPlayerObject)
		{
			if(mAlwaysRegenHealth)
			{
				mHealthRegenTimer -= Time.deltaTime;
				if(mHealthRegenTimer <= 0.0f)
				{
					IncreaseHealth(mPlayerObject.GetStats().GetHealthRegenRate());
					mHealthRegenTimer = 1.0f;
				}
			}
			else
			{
				if(!mPlayerObject.IsInCombat())
				{
					mHealthRegenTimer -= Time.deltaTime;
					if(mHealthRegenTimer <= 0.0f)
					{
						IncreaseHealth(mPlayerObject.GetStats().GetHealthRegenRate());
						mHealthRegenTimer = 1.0f;
					}
				}
			}
		}
		else if(mNPCObject)
		{
			if(mAlwaysRegenHealth)
			{
				mHealthRegenTimer -= Time.deltaTime;
				if(mHealthRegenTimer <= 0.0f)
				{
					IncreaseHealth(mNPCObject.GetStats().GetHealthRegenRate());
					mHealthRegenTimer = 1.0f;
				}
			}
			else
			{
				if(!mNPCObject.IsInCombat())
				{
					mHealthRegenTimer -= Time.deltaTime;
					if(mHealthRegenTimer <= 0.0f)
					{
                        IncreaseHealth(mNPCObject.GetStats().GetHealthRegenRate());
                        mHealthRegenTimer = 1.0f;
                    }
				}
			}
		}
	}
	void RegenerateShields()
	{
		if(mPlayerObject)
		{
			if(!mPlayerObject.IsInCombat())
			{
				mShieldRegenTimer -= Time.deltaTime;
				if(mShieldRegenTimer <= 0.0f)
				{
					IncreaseShields(mPlayerObject.GetStats().GetShieldRegenRate());
					mShieldRegenTimer = 1.0f;
				}
			}
		}
		else if(mNPCObject)
		{
			if(!mNPCObject.IsInCombat())
			{
				mShieldRegenTimer -= Time.deltaTime;
				if(mShieldRegenTimer <= 0.0f)
				{
                    IncreaseShields(mNPCObject.GetStats().GetShieldRegenRate());
                    mShieldRegenTimer = 1.0f;
                }
			}
		}
	}
	// Use this for initialization
	void Start ()
	{
		//Set flags
		mIsDead = false;

        //Set regen timers
        mHealthRegenTimer = 1.0f;
        mShieldRegenTimer = 1.0f;

        //Reference the object script
        mPlayerObject = GetComponent<Player>();
		mNPCObject = GetComponent<NPC>();

		if(mPlayerObject)
		{
			//This is a player
			//Set health and shield values
			mHealth = mPlayerObject.GetStats().GetMaxHealth();
			mShields = mPlayerObject.GetStats().GetMaxShields();
		}
		else if(mNPCObject)
		{
			//This is an enemy
			//Set health and shield values
			mHealth = mNPCObject.GetStats().GetMaxHealth();
			mShields = mNPCObject.GetStats().GetMaxShields();
		}
		else
		{
			Debug.LogError("[HealthSystem.cs] Could not find the NPC or Player script on " + gameObject.name + "!");
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if(!GameManager.GamePaused())
		{
			RegenerateHealth();
			RegenerateShields();
		}
	}
}