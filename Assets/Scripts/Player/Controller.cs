using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//The Controller will handle 4 main functions for players: attack, movement, interaction, and pick up
public class Controller : MonoBehaviour
{
	[SerializeField]
	private float mBaseSpeed = 5.0f;
	[SerializeField]
	private LayerMask mMovementMask;
	private Player playerObject;

	void Attack()
	{
		if(playerObject.GetFocus())
		{
			//playerObject.GetNavAgent().stoppingDistance = playerObject.GetFocus().transform.position - playerObject.GetWeapons().;
			//playerObject.GetNavAgent().SetDestination(playerObject.GetFocus().transform.position);
			if(playerObject.GetNavAgent().isStopped)
			{
				//Attack!!!
			}
		}
	}
	void Interact()
	{

	}
	//Method to handle the movement of this character
	void Movement(Ray ray)
	{
		UpdateMoveSpeed();
		if(Input.GetMouseButton(0))
		{
			if(playerObject.GetFocus())
			{
				playerObject.GetNavAgent().SetDestination(playerObject.GetFocus().transform.position);
			}
			else
			{
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, 100.0f, mMovementMask))
				{
					//playerObject.GetAnimator().SetBool("moving", true);
					playerObject.GetNavAgent().SetDestination(hit.point);
				}
			}
		}
	}
	//Unity initialization method
	void Start ()
	{
		playerObject = GetComponent<Player>();
		if(!playerObject)
		{
			Debug.LogError("[Controller.cs] Can't find the Player!");
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if(!GameManager.GamePaused())
		{
			Ray ray = playerObject.GetCamera().ScreenPointToRay(Input.mousePosition);
		
			UpdateAnimation();
			Movement(ray);
		}
	}
	void UpdateAnimation()
	{
		if(playerObject.GetNavAgent().velocity.magnitude > 0.0f)
		{
			playerObject.GetAnimator().SetBool("moving", true);
		}
		else
		{
			playerObject.GetAnimator().SetBool("moving", false);

			//Check if player is attacking or interacting
		}
	}
	void UpdateMoveSpeed()
	{
		playerObject.GetNavAgent().speed = mBaseSpeed + (playerObject.GetStats().GetAgilityStat() * 0.1f) - (playerObject.GetStats().GetCarryWeight() * 0.1f);
	}
}