using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//The Controller will handle 4 main functions for players: attack, movement, interaction, and pick up
public class Controller : MonoBehaviour
{
	public LayerMask mMovementMask;
	private Player playerObject;

	void Attack()
	{
		if(playerObject.GetFocus())
		{
			//playerObject.GetNavAgent().stoppingDistance = playerObject.GetFocus().transform.position - playerObject.GetWeapons().range;
			//playerObject.GetNavAgent().SetDestination(playerObject.GetFocus().transform.position);
			if(playerObject.GetNavAgent().isStopped)
			{
				//Attack!!!!
			}
		}
	}
	void Interact()
	{

	}
	//Method to handle the movement of this character
	void Movement(Ray ray)
	{
		if(Input.GetMouseButton(0))
		{
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100.0f, mMovementMask))
			{
				//playerObject.GetAnimator().SetBool("moving", true);
				playerObject.GetNavAgent().SetDestination(hit.point);
			}
			if(playerObject.GetPosition() == playerObject.GetNavAgent().destination)
			{
				playerObject.GetNavAgent().isStopped = true;
				//playerObject.GetAnimator().SetBool("moving", false);
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
		Ray ray = playerObject.GetCamera().ScreenPointToRay(Input.mousePosition);
		
		UpdateAnimation();
		Movement(ray);
	}
	void UpdateAnimation()
	{
		if(playerObject.GetNavAgent().isStopped)
		{
			playerObject.GetAnimator().SetBool("moving", false);
			//Check if player is attacking or interacting
		}
		else
		{
			playerObject.GetAnimator().SetBool("moving", true);
		}
	}
}