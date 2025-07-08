using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefenderSlot : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
    public Renderer rend;
    

    [Header("Optional")]
    public GameObject defender;

    public Vector3 buildPositionOffset;
    BuildManager buildManager;
    


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;              
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + buildPositionOffset;
    }

    public Quaternion GetBuildRotation()
    {
        return transform.rotation;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.Canbuild)
        {
            return;
        }
        if (!buildManager.IsEnoughMoney)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.Canbuild)
        {
            return;
        }
        if (defender != null)
        {
            Debug.Log("Can't be Built");
            return;
        }

        buildManager.BuildDefenderOn(this);


    }
}
