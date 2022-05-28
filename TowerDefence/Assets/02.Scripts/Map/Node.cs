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

    private void OnMouseDown()
    {
        // �Ǽ��� Ÿ���� ���õǾ���, ���� ��忡 Ÿ���� ���ٸ� Ÿ�� �Ǽ�
        if (TowerHandler.instance.isSelected &&
            towerBuilt == null)
        {
            TowerInfo info = TowerHandler.instance.selectedTowerInfo;
            if (TowerAssets.TryGetTowerPrefab(info.type, info.upgradeLevel, out GameObject towerPrefab))
            {
                towerBuilt = Instantiate(towerPrefab, 
                                         transform.position + Vector3.up * towerOffestY, 
                                         Quaternion.identity,
                                         transform).GetComponent<Tower>();

                TowerHandler.instance.Clear();
            }
            else
            {
                throw new System.Exception("Ÿ�� ������ �� �������µ� ������. Ÿ�� Ÿ�԰� ���� Ȯ�����ּ���");
            }
        }
    }
}
