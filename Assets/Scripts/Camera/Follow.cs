using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
	private bool mZoomInFlag;
	private bool mZoomOutFlag;
	[SerializeField]
	private float mMaxZoomLevel;
	[SerializeField]
	private float mMinZoomLevel;
	private float mZoomLevel;
	[SerializeField]
	private float mZoomSpeed;
	private Player mPlayerObject;
	[SerializeField]
	private Vector3 mOffset;

	public bool GetZoomInFlag()
	{
		return mZoomInFlag;
	}
	public bool GetZoomOutFlag()
	{
		return mZoomOutFlag;
	}
	public float GetMaxZoomLevel()
	{
		return mMaxZoomLevel;
	}
	public float GetMinZoomLevel()
	{
		return mMinZoomLevel;
	}
	public float GetZoomLevel()
	{
		return mZoomLevel;
	}
	public float GetZoomSpeed()
	{
		return mZoomSpeed;
	}
	public Player GetPlayerObject()
	{
		return mPlayerObject;
	}
	public Vector3 GetOffset()
	{
		return mOffset;
	}
	public void SetMaxZoomLevel(float zoomLevel)
	{
		mMaxZoomLevel = zoomLevel;
	}
	public void SetMinZoomLevel(float zoomLevel)
	{
		mMinZoomLevel = zoomLevel;
	}
	public void SetOffset(float x, float y, float z)
	{
		mOffset = new Vector3(x, y, z);
	}
	public void SetOffset(Vector3 offset)
	{
		mOffset = offset;
	}
	public void SetPlayerObject(Player playerObject)
	{
		mPlayerObject = playerObject;
	}
	public void SetZoomInFlag(bool zoomInFlag)
	{
		mZoomInFlag = zoomInFlag;
	}
	public void SetZoomLevel(float zoomLevel)
	{
		mZoomLevel = zoomLevel;
	}
	public void SetZoomOutFlag(bool zoomOutFlag)
	{
		mZoomOutFlag = zoomOutFlag;
	}
	public void SetZoomSpeed(float speed)
	{
		mZoomSpeed = speed;
	}

	void HandleInput()
	{
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			mZoomOutFlag = false;
			mZoomInFlag = true;
		}
		else if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			mZoomInFlag = false;
			mZoomOutFlag = true;
		}
	}
	//Unity update method
	void LateUpdate ()
	{
		transform.position = mPlayerObject.GetPosition() - mOffset * mZoomLevel;
		transform.LookAt(mPlayerObject.GetPosition() + Vector3.up * mPlayerObject.GetHeight());
	}
	//Unity initialization method
	void Start()
	{
		mPlayerObject = GetComponentInParent<Player>();
		if(!mPlayerObject)
		{
			Debug.LogError("[Follow.cs] Player camera can't find the Player!");
		}

		mZoomLevel = 10.0f;
	}
	//Unity update method
	void Update()
	{
		HandleInput();
		Zoom();
	}
	void Zoom()
	{
		if(mZoomInFlag)
		{
			if(mZoomLevel > mMinZoomLevel)
			{
				Debug.Log("[Follow.cs] Zooming in...");
				mZoomLevel = Mathf.Lerp(mZoomLevel, mMinZoomLevel, mZoomSpeed * Time.deltaTime);
			}
			else
			{
				mZoomInFlag = !mZoomInFlag;
			}
		}

		if(mZoomOutFlag)
		{
			if(mZoomLevel < mMaxZoomLevel)
			{
				Debug.Log("[Follow.cs] Zooming out...");
				mZoomLevel = Mathf.Lerp(mZoomLevel, mMaxZoomLevel, mZoomSpeed * Time.deltaTime);
			}
			else
			{
				mZoomOutFlag = !mZoomOutFlag;
			}
		}
	}
}
