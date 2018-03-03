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
                if(mObject.GetWeapons().Length > 0)
                {
                    if(mObject.GetWeapons().Length > 1)
                    {
                        if(mObject.GetWeapons()[1].InRange(transform, mObject.GetTarget().transform))
                        {
                            mObject.GetTarget().GetComponent<HealthSystem>().TakeDamage(mObject.GetWeapons()[1].CalculateDamage());
                        }
                    }

                    if(mObject.GetWeapons()[0].InRange(transform, mObject.GetTarget().transform))
                    {
                        mObject.GetTarget().GetComponent<HealthSystem>().TakeDamage(mObject.GetWeapons()[0].CalculateDamage());
                    }
                    else
                    {
                        mObject.GetNavMeshAgent().SetDestination(mObject.GetTarget().transform.position);
                    }
                }
                else
                {
                    mObject.GetNavMeshAgent().SetDestination(mObject.GetTarget().transform.position);
                }
            }
            else
            {
                //Lost sight of the target;
                mObject.SetTarget(null);
            }
        }
    }
    //Unity update method
    void Update()
    {
        UpdateTarget();
        Attack();
    }
    void UpdateTarget()
    {
        RaycastHit hit;

        //Check the time of day
        if(EnvironmentManager.GetTime().OfDay() == EnvironmentManager.DayState.Dawn || EnvironmentManager.GetTime().OfDay() == EnvironmentManager.DayState.Day || mObject.HasNightVision())
        {
            //Check if this NPC can see a potential target
           if(Physics.SphereCast(mObject.GetPosition(), 9999, Vector3.forward, out hit, Mathf.Infinity))
           {
               Debug.Log(hit);
               if(hit.transform.GetComponent<NPC>() || hit.transform.GetComponent<Player>())
               {
                    //Check if this NPC already has a target
                    if(mObject.GetTarget())
                    {
                        //Check if which target has higher threat
                        if(hit.transform.GetComponent<ThreatSystem>().GetThreatLevel() > mObject.GetTarget().GetComponent<ThreatSystem>().GetThreatLevel())
                        {
                            //Switch targets
                            mObject.SetTarget(hit.transform.gameObject);

                            Debug.Log("[Enemy.cs] Switching target to " + mObject.GetTarget().name);
                        }
                    }
                    else
                    {
                        //Set this NPC's target
                        mObject.SetTarget(hit.transform.gameObject);

                        Debug.Log("[Enemy.cs] Targeting " + mObject.GetTarget().name);
                    }
               }
           }
        }
        else
        {
            //Check if this NPC can see a potential target
            if(Physics.SphereCast(mObject.GetPosition(), mNighttimeSightDistance, Vector3.forward, out hit, mNighttimeSightDistance))
           {
                 if(hit.transform.GetComponent<NPC>() || hit.transform.GetComponent<Player>())
                {
                    //Check if this NPC already has a target
                    if(mObject.GetTarget())
                    {
                        //Check if which target has higher threat
                        if(hit.transform.GetComponent<ThreatSystem>().GetThreatLevel() > mObject.GetTarget().GetComponent<ThreatSystem>().GetThreatLevel())
                        {
                            //Switch targets
                            mObject.SetTarget(hit.transform.gameObject);

                            Debug.Log("[Enemy.cs] Switching target to " + mObject.GetTarget().name);
                        }
                    }
                    else
                    {
                        //Set this NPC's target
                        mObject.SetTarget(hit.transform.gameObject);

                        Debug.Log("[Enemy.cs] Targeting " + mObject.GetTarget().name);
                    }
                }
           }
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
    }
}