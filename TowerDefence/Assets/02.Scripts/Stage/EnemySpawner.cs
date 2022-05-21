using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float startDelay = 1f;
    [HideInInspector] public int currentLevel;
    [HideInInspector] public int tmpstage;

    [System.Serializable]
    public class SpawnElement
    {
        public GameObject prefab;
        public int num;
        public float delay;
    }
    [SerializeField] private SpawnElement[][] spawnElements;
    private float[][] timers;
    private int[][] counts;

    public void Spawn()
    {
        if (tmpstage < spawnElements.Length - 1)
        {
            StartCoroutine(E_Spawn());
        }
    }

    private void Awake()
    {
        // ���� ������ ���� ��� �������� ���� ������
        StageInfo[] tmpStageInfos = LevelInfoAssets.GetAllStageInfo(currentLevel);

        // ��ȯ�ؾ��ϴ� Enemy �迭�� �������� ũ�� �Ҵ�
        spawnElements = new SpawnElement[tmpStageInfos.Length][];
        
        // ��ȯ�ؾ��ϴ� ���������� Enemy ��� �Ҵ�
        for (int i = 0; i < tmpStageInfos.Length; i++)
        {
            spawnElements[i] = tmpStageInfos[i].enemiesElement;
        }

        timers = new float[spawnElements.Length][];
        counts = new int[spawnElements.Length][];

        for (int i = 0; i < spawnElements.Length; i++)
        {
            timers[i] = new float[spawnElements[i].Length];
            counts[i] = new int[spawnElements[i].Length];

            for (int j = 0; j < spawnElements[i].Length; j++)
            {
                timers[i][j] = spawnElements[i][j].delay;
                counts[i][j] = spawnElements[i][j].num;
            }
        }
    }

    private IEnumerator E_Spawn()
    {
        tmpstage++;
        yield return new WaitForSeconds(startDelay);

        bool isDone = false;
        while (isDone == false)
        {
            isDone = true;

            for (int i = 0; i < spawnElements[tmpstage].Length; i++)
            {
                // ��ȯ�� ���� �����ִ��� üũ
                if (counts[tmpstage][i] > 0)
                {
                    isDone = false;

                    // ��ȯ ������ üũ
                    if (timers[tmpstage][i] < 0)
                    {
                        Instantiate(spawnElements[tmpstage][i].prefab,
                                    WayPoints.instance.GetFirstWayPoint().position,
                                    Quaternion.identity);
                        counts[tmpstage][i]--;
                        timers[tmpstage][i] = spawnElements[tmpstage][i].delay;
                    }
                    else
                        timers[tmpstage][i] -= Time.deltaTime;

                    yield return null;
                }
            }
        }

    }
}