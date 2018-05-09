using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	bool mIsHighlighted = false;

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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
