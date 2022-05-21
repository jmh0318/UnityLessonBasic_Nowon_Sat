using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints instance;
    public Transform[] points;

    /// <summary>
    /// ù ��° ����Ʈ
    /// </summary>
    public Transform GetFirstWayPoint()
    {
        Debug.Log($"First {points[0]}");
        return points[0];
    }

    public Transform GetLastWayPoint()
    {
        return points[points.Length - 1];
    }

    /// <summary>
    /// ���� ����Ʈ �������� �Լ�
    /// </summary>
    /// <param name="currentPointIndex"> ���� ����Ʈ �𵦽� </param>
    /// <param name="nextPoint"> ��ȯ�� ���� ����Ʈ Transform </param>
    /// <returns> ���� ����Ʈ �������µ� ����: ture ����: false</returns>
    public bool TryGetNextWayPoint(int currentPointIndex , out Transform nextPoint)
    {
        nextPoint = null;  
        
        if (currentPointIndex < instance.points.Length - 1)
        {
            nextPoint = instance.points[currentPointIndex + 1];
            return true;
        }

        return false;
    }

    private void Awake()
    {
        Debug.Log("Awake");

        if (instance != null)
            Destroy( instance );
        instance = this;

        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
            points[i] = transform.GetChild(i);
    }
}