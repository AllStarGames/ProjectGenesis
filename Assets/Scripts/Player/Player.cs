using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
	private Animator mAnimator;
	[SerializeField]
	private Behaviour[] mLocalComponents;
	private bool mInCombatFlag;
	private Camera mCamera;
	private Controller mController;
	private Collider mCollider;
	[SerializeField]
	private float mHeight;
	private GameObject mFocus;
	private HealthSystem mHealthSystem;
	private int mNumMagicalUses;
	private int mNumPhysicalUses;
	private int mNumTimesHit;
	private NavMeshAgent mNavAgent;
	private Rigidbody mBody;
	private SkinnedMeshRenderer mMeshRenderer;
	private Stats mStats;
	[SerializeField]
	private string mName;
	private WeaponSkills mWeaponSkills;
	
	//public override void OnStartClient()
	//{
	//	base.OnStartClient();
	//
	//	PlayerManager.RegisterPlayer(GetID(), this);
	//}

	public Animator GetAnimator()
	{
		return mAnimator;
	}
	public Behaviour[] GetLocalComponents()
	{
		return mLocalComponents;
	}
	public bool GetInCombatFlag()
	{
		return mInCombatFlag;
	}
	public Camera GetCamera()
	{
		return mCamera;
	}
	public Controller GetController()
	{
		return mController;
	}
	public Collider GetCollider()
	{
		return mCollider;
	}
	public float GetHeight()
	{
		return mHeight;
	}
	public GameObject GetFocus()
	{
		return mFocus;
	}
	public HealthSystem GetHealthSystem()
	{
		return mHealthSystem;
	}
	public int GetNumMagicalUses()
	{
		return mNumMagicalUses;
	}
	public int GetNumPhysicalUses()
	{
		return mNumPhysicalUses;
	}
	public int GetNumTimesHit()
	{
		return mNumTimesHit;
	}
	public NavMeshAgent GetNavAgent()
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
	public Transform GetTransform()
	{
		return transform;
	}
	public Vector3 GetPosition()
	{
		return transform.position;
	}
	public void SetAnimator(Animator animator)
	{
		mAnimator = animator;
	}
	public void SetBody(Rigidbody body)
	{
		mBody = body;
	}
	public void SetCamera(Camera camera)
	{
		mCamera = camera;
	}
	public void SetController(Controller controller)
	{
		mController = controller;
	}
	public void SetCollider(MeshCollider collider)
	{
		mCollider = collider;
	}
	public void SetFocus(GameObject obj)
	{
		mFocus = obj;
	}
	public void SetHealthSystem(HealthSystem healthSystem)
	{
		mHealthSystem = healthSystem;
	}
	public void SetHeight(float height)
	{
		mHeight = height;
	}
	public void SetInCombatFlag(bool flag)
	{
		mInCombatFlag = flag;
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
	public void SetNumMagicalUses(int value)
	{
		mNumMagicalUses = value;
	}
	public void SetNumPhysicalUses(int value)
	{
		mNumPhysicalUses = value;
	}
	public void SetNumTimesHit(int value)
	{
		mNumTimesHit = value;
	}
	public void SetPosition(float x, float y, float z)
	{
		transform.position = new Vector3(x, y, z);
	}
	public void SetPosition(Vector3 position)
	{
		transform.position = position;
	}
	public void SetStats(Stats stats)
	{
		mStats = stats;
	}
	public void SetWeaponSkills(WeaponSkills weaponSkills)
	{
		mWeaponSkills = weaponSkills;
	}
	public WeaponSkills GetWeaponSkills()
	{
		return mWeaponSkills;
	}

	void AssignRemoteLayer()
	{
		gameObject.layer = LayerMask.NameToLayer("Remote");
	}
	// Use this for initialization
	void Awake ()
	{
		gameObject.name = mName;

		mAnimator = GetComponentInChildren<Animator>();
		if(!mAnimator)
		{
			Debug.LogError("[Player.cs] No Animator associated with " + name);
		}
		mCamera = GetComponentInChildren<Camera>();
		if(!mCamera)
		{
			Debug.LogError("[Player.cs] No Camera associated with " + name);
		}
		mController = GetComponent<Controller>();
		if(!mController)
		{
			Debug.LogError("[Player.cs] No Controller associated with " + name);
		}
		mCollider = GetComponent<MeshCollider>();
		if(!mCollider)
		{
			Debug.LogError("[Player.cs] No MeshCollider associated with " + name);
		}
		mHealthSystem = GetComponent<HealthSystem>();
		if(!mHealthSystem)
		{
			Debug.LogError("[Player.cs] No HealthSystem associated with " + name);
		}
		mMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
		if(!mMeshRenderer)
		{
			Debug.LogError("[Player.cs] No MeshRenderer associated with " + name);
		}
		mNavAgent = GetComponent<NavMeshAgent>();
		if(!mNavAgent)
		{
			Debug.LogError("[Player.cs] No NavMeshAgent associated with " + name);
		}
		mBody = GetComponent<Rigidbody>();
		if(!mBody)
		{
			Debug.LogError("[Player.cs] No Rigidbody associated with " + name);
		}
		mStats = GetComponent<Stats>();
		if(!mStats)
		{
			Debug.LogError("[Player.cs] No Stats associated with " + name);
		}
		mWeaponSkills = GetComponent<WeaponSkills>();
		if(!mWeaponSkills)
		{
			Debug.LogError("[Player.cs] No WeaponSkills associated with " + name);
		}
	}
	void DisableLocalComponents()
	{
		foreach(Behaviour component in mLocalComponents)
		{
			component.enabled = false;
		}
	}
	void Start()
	{
		mStats.Initialize();
		mWeaponSkills.Initialize();

		//if(!isLocalPlayer)
		//{
		//	AssignRemoteLayer();
		//	DisableLocalComponents();
		//}
	}
	// Update is called once per frame
	void Update ()
	{
	}
}