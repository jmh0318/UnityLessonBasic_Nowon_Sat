using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints instance;
    public Transform[] points;

    /// <summary>
    /// 첫 번째 포인트
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
    /// 다음 포인트 가져오는 함수
    /// </summary>
    /// <param name="currentPointIndex"> 현재 포인트 언덱스 </param>
    /// <param name="nextPoint"> 반환할 다음 포인트 Transform </param>
    /// <returns> 다음 포인트 가져오는데 성공: ture 실패: false</returns>
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