using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float towerOffestY;
    public Tower towerBuilt;

    private Renderer rend;

    private Color originColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        if (TowerHandler.instance.isSelected)
        {
            rend.material.color = buildAvailableColor;
        }
        else
        {
            rend.material.color = buildNotAvailableColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = originColor;
    }
}
