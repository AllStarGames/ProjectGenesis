using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public float fadeRate;
    public float transparentLevel;
    public string[] tags;

    private bool awakeCalled = false;
    private List<MeshRenderer> fadeInList;
    private List<MeshRenderer> fadeOutList;
    private Player playerObject;
    //private Vector3 playerPosition;

    void Awake()
    {
        if (!awakeCalled)
        {
            awakeCalled = true;
            fadeInList = new List<MeshRenderer>();
            fadeOutList = new List<MeshRenderer>();

            playerObject = GetComponentInParent<Player>();
        }
        else
        {
            Debug.Log("[LineOfSight.cs] Awake() called mulitple times!");
        }
    }

    void Update()
    {
        if(!GameManager.GamePaused())
        {
            CastRay();
            FadeIn();
            FadeOut();

            fadeInList.AddRange(fadeOutList.FindAll(obj => obj.material.color.a <= transparentLevel));
            fadeOutList.RemoveAll(obj => obj.material.color.a <= transparentLevel);
        }
    }

    void CastRay()
    {
        //playerPosition = PlayerManager.GetPlayerList();
        Vector3 distanceFromPlayer = playerObject.GetPosition() - transform.position;
        Ray ray = new Ray(transform.position, distanceFromPlayer.normalized);

        RaycastHit[] hitInfos = Physics.RaycastAll(ray, distanceFromPlayer.magnitude);

        fadeInList.RemoveAll(obj => obj == null);
        fadeOutList.RemoveAll(obj => obj == null);

        foreach (RaycastHit hit in hitInfos)
        {
            foreach (string str in tags)
            {
                if (hit.collider.CompareTag(str))
                {
                    MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
                    fadeInList.Remove(renderer);
                    if (!fadeOutList.Contains(renderer))
                    {
                        fadeOutList.Add(renderer);
                    }
                }
            }
        }
    }

    void FadeIn()
    {
        foreach (MeshRenderer renderer in fadeInList)
        {
            foreach (Material material in renderer.materials)
            {
                Color colour = material.color;
                if(colour.a < 1.0f)
                {
                    colour.a += fadeRate;
                }
                material.color = colour;
            }
        }
        fadeInList.RemoveAll(obj => obj.material.color.a >= 1.0f);
    }

    void FadeOut()
    {
        foreach (MeshRenderer renderer in fadeOutList)
        {
            foreach (Material material in renderer.materials)
            {
                Color colour = material.color;
                if (colour.a > transparentLevel)
                {
                    colour.a -= fadeRate;
                }
                material.color = colour;
            }
        }
    }
}
