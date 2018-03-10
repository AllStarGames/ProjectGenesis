using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class NPC : MonoBehaviour
{
	private Animator mAnimator;
	[SerializeField]
	private bool mCanBeFocused;
	[SerializeField]
	private bool mDebugMode;
	[SerializeField]
	private bool mHasNightVision;
	private bool mIsHighlighted;
	private bool mIsInCombat;
	private Collider mCollider;
	private EnergySystem mEnergySystem;
	[SerializeField]
	private float mCleanUpTimer = 30.0f;
    private float mCombatTimer;
	[SerializeField]
	private float mHeight;
    private float mMainAttackTimer;
    private float mSecondaryAttackTimer;
	private GameObject mTarget;
	private HealthSystem mHealthSystem;
	private MonoBehaviour mController;
	private NavMeshAgent mNavAgent;
	private Rigidbody mBody;
	private SkinnedMeshRenderer mMeshRenderer;
	private Stats mStats;
	[SerializeField]
	private string mName;
	private ThreatSystem mThreatSystem;
	[SerializeField]
	private Weapon[] mWeapons;
    private WeaponSkills mWeaponSkills;

	public Animator GetAnimator()
	{
		return mAnimator;
	}
	public bool CanBeFocused()
	{
		return mCanBeFocused;
	}
	public bool HasNightVision()
	{
		return mHasNightVision;
	}
	public bool HasTwoWeapons()
	{
		return mWeapons.Length	> 1;
	}
	public bool IsHighlighted()
	{
		return mIsHighlighted;
	}
	public bool IsInCombat()
	{
		return mIsInCombat;
	}
	public Collider GetCollider()
	{
		return mCollider;
	}
	public EnergySystem GetEnergySystem()
	{
		return mEnergySystem;
	}
    public float GetCombatTimer()
    {
        return mCombatTimer;
    }
	public float GetHeight()
	{
		return mHeight;
	}
    public float GetMainAttackTimer()
    {
        return mMainAttackTimer;
    }
    public float GetSecondaryAttackTimer()
    {
        return mSecondaryAttackTimer;
    }
	public GameObject GetTarget()
	{
		return mTarget;
	}
	public HealthSystem GetHealthSystem()
	{
		return mHealthSystem;
	}
	public MonoBehaviour GetController()
	{
		return mController;
	}
	public NavMeshAgent GetNavMeshAgent()
	{
		return mNavAgent;
	}
	public Rigidbody GetBody()
	{
		return mBody;
	}
	public SkinnedMeshRenderer GetMeshRenderer()
	{
		return mMeshRenderer;
	}
	public Stats GetStats()
	{
		return mStats;
	}
	//public string GetID()
	//{
	//	return GetComponent<NetworkIdentity>().netId.ToString();
	//}
	public string GetName()
	{
		return mName;
	}
	public ThreatSystem GetThreatSystem()
	{
		return mThreatSystem;
	}
	public Transform GetTransform()
	{
		return transform;
	}
	public Vector3 GetPosition()
	{
		return transform.position;
	}
	public void CleanUp()
	{
		mCleanUpTimer -= Time.deltaTime;
		if(mCleanUpTimer <= 0.0f)
		{
			mCleanUpTimer = 30.0f;
			gameObject.SetActive(false);
		}
	}
	public void Reset()
	{
		mAnimator.SetBool("dead", false);
		mHealthSystem.Reset();

		mTarget = null;
	}
	public void SetAnimator(Animator animator)
	{
		mAnimator = animator;
	}
	public void SetBody(Rigidbody body)
	{
		mBody = body;
	}
	public void SetCanBeFocusedFlag(bool value)
	{
		mCanBeFocused = value;
	}
	public void SetCollider(Collider collider)
	{
		mCollider = collider;
	}
    public void SetCombatTimer(float time)
    {
        mCombatTimer = time;
    }
	public void SetController(Enemy controller)
	{
		mController = controller;
	}
	public void SetEnergySystem(EnergySystem energySystem)
	{
		mEnergySystem = energySystem;
	}
	public void SetHasNightVisionFlag(bool value)
	{
		mHasNightVision = value;
	}
	public void SetHealthSystem(HealthSystem healthSystem)
	{
		mHealthSystem = healthSystem;
	}
	public void SetHeight(float value)
	{
		mHeight = value;
	}
	public void SetHighlightedFlag(bool value)
	{
		mIsHighlighted = value;
	}
	public void SetIsInCombatFlag(bool value)
	{
		mIsInCombat = value;
	}
    public void SetMainAttackTimer(float time)
    {
        mMainAttackTimer = time;
    }
	public void SetMeshRenderer(SkinnedMeshRenderer meshRenderer)
	{
		mMeshRenderer = meshRenderer;
	}
	public void SetName(string name)
	{
		mName = name;
	}
	public void SetNavAgent(NavMeshAgent navAgent)
	{
		mNavAgent = navAgent;
	}
	public void SetPosition(float x, float y, float z)
	{
		transform.position = new Vector3(x, y, z);
	}
	public void SetPosition(Vector3 position)
	{
		transform.position = position;
	}
    public void SetSecondaryAttackTimer(float time)
    {
        mSecondaryAttackTimer = time;
    }
	public void SetStats(Stats stats)
	{
		mStats = stats;
	}
	public void SetTarget(GameObject obj)
	{
		mTarget = obj;
	}
	public void SetThreatSystem(ThreatSystem threatSystem)
	{
		mThreatSystem = threatSystem;
	}
    public void SetWeaponSkills(WeaponSkills weaponSkills)
    {
        mWeaponSkills = weaponSkills;
    }
	public Weapon[] GetWeapons()
	{
		return mWeapons;
	}
    public WeaponSkills GetWeaponSkills()
    {
        return mWeaponSkills;
    }

	//Unity initialization method
	void Awake ()
	{
		gameObject.name = mName;

		mAnimator = GetComponentInChildren<Animator>();
		if(!mAnimator)
		{
			Debug.LogError("[NPC.cs] No Animator associated with " + name);
		}
		mBody = GetComponent<Rigidbody>();
		if(!mBody)
		{
			Debug.LogError("[NPC.cs] No Rigidbody associated with " + name);
		}
		if(!(mController = GetComponent<Enemy>()))
		{
			//if(!(mController = GetComponent<>()))
			//{
				Debug.LogError("[NPC.cs] No Controller associated with " + name);
			//}
		}
		mCollider = GetComponent<MeshCollider>();
		if(!mCollider)
		{
			Debug.LogError("[NPC.cs] No MeshCollider associated with " + name);
		}
		mEnergySystem = GetComponent<EnergySystem>();
		if(!mEnergySystem)
		{
			Debug.LogError("[NCP.cs] No EnergySystem associated with " + name);
		}
		mHealthSystem = GetComponent<HealthSystem>();
		if(!mHealthSystem)
		{
			Debug.LogError("[NPC.cs] No HealthSystem associated with " + name);
		}
		mMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
		if(!mMeshRenderer)
		{
			Debug.LogError("[NPC.cs] No MeshRenderer associated with " + name);
		}
		mNavAgent = GetComponent<NavMeshAgent>();
		if(!mNavAgent)
		{
			Debug.LogError("[NPC.cs] No NavMeshAgent associated with " + name);
		}
		mStats = GetComponent<Stats>();
		if(!mStats)
		{
			Debug.LogError("[NPC.cs] No Stats associated with " + name);
		}
		mThreatSystem = GetComponent<ThreatSystem>();
		if(!mThreatSystem)
		{
			Debug.LogError("[NPC.cs] No ThreatSystem associated with " + name);
		}
        mWeaponSkills = GetComponent<WeaponSkills>();
        if(!mWeaponSkills)
        {
            Debug.LogError("[NPC.cs] No WeaponSkills associated with " + name);
        }
	}
	void OnMouseOff()
	{
		if(mIsHighlighted)
		{
			if(!Input.GetMouseButton(0))
			{
				//Unhighlight this NPC and remove it as the player's focus
				mIsHighlighted = false;
				PlayerManager.GetLocalPlayer().SetFocus(null);
			}
		}
	}
	void OnMouseOver()
	{
		if(!mHealthSystem.IsDead())
		{
			if(mCanBeFocused)
			{
				//Highlight this NPC and set it as the player's focus
				mIsHighlighted = true;
				PlayerManager.GetLocalPlayer().SetFocus(gameObject);
			}
		}
	}
	//Unity initialization method
	void Start ()
	{
		//Set flags
		mIsHighlighted = false;

		//Initialize stats
		mStats.Initialize();
        mWeaponSkills.Initialize();

        //Initialize timers
        mCombatTimer = 15.0f;
        if(mWeapons.Length > 0)
        {
            mMainAttackTimer = mWeapons[0].CalculateSpeed();
            if(mWeapons.Length > 1)
            {
                mSecondaryAttackTimer = mWeapons[1].CalculateSpeed();
            }
        }
	}
	//Unity update method
	void Update()
	{
		if(!GameManager.GamePaused())
		{
			if(mHealthSystem.IsDead())
			{
				CleanUp();
			}
			else
			{
				OnMouseOff();

                //Run timers
                if(mIsInCombat)
                {
                    mCombatTimer -= Time.deltaTime;
                    if(mCombatTimer <= 0.0f)
                    {
                        mIsInCombat = false;
                    }
                }

                mMainAttackTimer -= Time.deltaTime;
                mSecondaryAttackTimer -= Time.deltaTime;
			}
		}
	}
}