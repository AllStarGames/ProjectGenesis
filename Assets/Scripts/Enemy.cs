using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Type
    {
        Boss = 1,
        Minion = 2,
        NONE = 0
    }

    
    [SerializeField]
	private float mBaseSpeed = 5.0f;
	[SerializeField]
    private float mDaytimeSightDistance = 1.0f;
    [SerializeField]
    private float mNighttimeSightDistance = 0.5f;
    [SerializeField]
    private float mPreceptionRange = 5.0f;
    private NPC mObject;
    [SerializeField]
    private Type mType = Type.NONE;

    public bool CanSeeTarget()
    {
        if(EnvironmentManager.GetTime().OfDay() == EnvironmentManager.DayState.Dawn || EnvironmentManager.GetTime().OfDay() == EnvironmentManager.DayState.Day)
        {
            return Vector3.Distance(mObject.GetPosition(), mObject.GetTarget().transform.position) <= mDaytimeSightDistance;
        }

        return Vector3.Distance(mObject.GetPosition(), mObject.GetTarget().transform.position) <= mNighttimeSightDistance;
    }

    void Attack()
    {
        if(mObject.GetTarget())
        {
             if(CanSeeTarget())
            {
                if(mObject.GetTarget().GetComponent<NPC>())
                {
                    mObject.GetTarget().GetComponent<NPC>().SetIsInCombatFlag(true);
                    mObject.GetTarget().GetComponent<NPC>().SetCombatTimer(15.0f);
                }
                else if(mObject.GetTarget().GetComponent<Player>())
                {
                    mObject.GetTarget().GetComponent<Player>().SetIsInCombatFlag(true);
                    mObject.GetTarget().GetComponent<Player>().SetCombatTimer(15.0f);
                }

                if(mObject.GetWeapons().Length > 0)
                {
                    if (mObject.GetWeapons().Length > 1)
                    {
                        if(mObject.GetWeapons()[1].InRange(transform, mObject.GetTarget().transform))
                        {
                            if(mObject.GetSecondaryAttackTimer() <= 0.0f)
                            {
                                if (mObject.GetTarget().GetComponent<NPC>())
                                {
                                    mObject.GetTarget().GetComponent<NPC>().SetCombatTimer(15.0f);
                                }
                                else if (mObject.GetTarget().GetComponent<Player>())
                                {
                                    mObject.GetTarget().GetComponent<Player>().SetCombatTimer(15.0f);
                                }

                                mObject.GetTarget().GetComponent<HealthSystem>().TakeDamage(mObject.GetWeapons()[1].CalculateDamage());
                                mObject.SetSecondaryAttackTimer(mObject.GetWeapons()[1].CalculateSpeed());
                            }
                        }
                    }

                    if (mObject.GetWeapons()[0].InRange(transform, mObject.GetTarget().transform))
                    {
                        if(mObject.GetMainAttackTimer() <= 0.0f)
                        {
                            if (mObject.GetTarget().GetComponent<NPC>())
                            {
                                mObject.GetTarget().GetComponent<NPC>().SetCombatTimer(15.0f);
                            }
                            else if (mObject.GetTarget().GetComponent<Player>())
                            {
                                mObject.GetTarget().GetComponent<Player>().SetCombatTimer(15.0f);
                            }

                            mObject.GetTarget().GetComponent<HealthSystem>().TakeDamage(mObject.GetWeapons()[0].CalculateDamage());
                            mObject.SetMainAttackTimer(mObject.GetWeapons()[0].CalculateSpeed());
                        }
                    }
                    else
                    {
                        mObject.GetNavMeshAgent().SetDestination(mObject.GetTarget().transform.position);
                    }
                }
                else
                {
                    Debug.LogError("[Enemy.cs] " + name + " has no weapon to attack with!");
                    //mObject.GetNavMeshAgent().SetDestination(mObject.GetTarget().transform.position);
                }
            }
            else
            {
                //Lost sight of the target;
                Debug.Log("[Enemy.cs] Lost sight of " + mObject.GetTarget().name);
                mObject.SetTarget(null);
            }
        }
    }
    //Unity update method
    void Update()
    {
        UpdateAnimation();
        UpdateTarget();
        Attack();
    }
    void UpdateAnimation()
    {
        if(mObject.GetNavMeshAgent().velocity.magnitude > 0.0f)
        {
            mObject.GetAnimator().SetBool("moving", true);
        }
        else
        {
            mObject.GetAnimator().SetBool("moving", false);

            //Check if this NPC is attacking or interacting
        }
    }
    void UpdateTarget()
    {
        //Check the time of day
        if (EnvironmentManager.GetTime().OfDay() == EnvironmentManager.DayState.Dawn || EnvironmentManager.GetTime().OfDay() == EnvironmentManager.DayState.Day || mObject.HasNightVision())
        {
            //Get all objects within my daytime sight distance
            Collider[] objects = Physics.OverlapSphere(mObject.GetPosition(), mDaytimeSightDistance);
            foreach(Collider obj in objects)
            {
                //Check that the object isn't myself
                if((obj.GetComponent<NPC>() || obj.GetComponent<Player>()) && obj.gameObject != gameObject)
                {
                    //Check if this NPC already has a target
                    if (mObject.GetTarget())
                    {
                        //Check if which target has higher threat
                        if (obj.GetComponent<ThreatSystem>().GetThreatLevel() > mObject.GetTarget().GetComponent<ThreatSystem>().GetThreatLevel())
                        {
                            //Switch targets
                            mObject.SetTarget(obj.gameObject);

                            Debug.Log("[Enemy.cs] Switching target to " + mObject.GetTarget().name);
                        }
                    }
                    else
                    {
                        //Set this NPC's target
                        mObject.SetTarget(obj.gameObject);

                        Debug.Log("[Enemy.cs] Targeting " + mObject.GetTarget().name);
                    }
                }
            }
        }
        else
        {
            //Get all objects within my nighttime sight distance
            Collider[] objects = Physics.OverlapSphere(mObject.GetPosition(), mNighttimeSightDistance);
            foreach (Collider obj in objects)
            {
                //Check that the object isn't myself
                if ((obj.GetComponent<NPC>() || obj.GetComponent<Player>()) && obj.gameObject != gameObject)
                {
                    //Check if this NPC already has a target
                    if (mObject.GetTarget())
                    {
                        //Check if which target has higher threat
                        if (obj.GetComponent<ThreatSystem>().GetThreatLevel() > mObject.GetTarget().GetComponent<ThreatSystem>().GetThreatLevel())
                        {
                            //Switch targets
                            mObject.SetTarget(obj.gameObject);

                            Debug.Log("[Enemy.cs] Switching target to " + mObject.GetTarget().name);
                        }
                    }
                    else
                    {
                        //Set this NPC's target
                        mObject.SetTarget(obj.gameObject);

                        Debug.Log("[Enemy.cs] Targeting " + mObject.GetTarget().name);
                    }
                }
            }
        }

        //Check if this NPC's current target is dead
        if(mObject.GetTarget() && mObject.GetTarget().GetComponent<HealthSystem>().IsDead())
        {
            mObject.SetTarget(null);
        }
    }
    //Unity initialization method
    void Start()
    {
        mObject = GetComponent<NPC>();
        if(!mObject)
        {
            Debug.LogError("[Enemy.cs] Could not find the NPC!");
        }

        mObject.GetNavMeshAgent().speed = mBaseSpeed;
    }
}