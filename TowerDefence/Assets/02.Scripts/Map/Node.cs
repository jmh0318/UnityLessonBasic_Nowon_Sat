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
        // 건설할 타워가 선택되었고, 현재 노드에 타워가 없다면 타워 건설
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
                throw new System.Exception("타워 프리팹 을 가져오는데 실패함. 타워 타입과 레벨 확인해주세요");
            }
        }
    }
}
