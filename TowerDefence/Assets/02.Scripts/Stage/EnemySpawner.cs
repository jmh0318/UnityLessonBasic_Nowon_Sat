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
        // 현재 레벨에 대한 모든 스테이지 정보 가져옴
        StageInfo[] tmpStageInfos = LevelInfoAssets.GetAllStageInfo(currentLevel);

        // 소환해야하는 Enemy 배열의 스테이지 크기 할당
        spawnElements = new SpawnElement[tmpStageInfos.Length][];
        
        // 소환해야하는 스테이지별 Enemy 목록 할당
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
                // 소환할 것이 남아있는지 체크
                if (counts[tmpstage][i] > 0)
                {
                    isDone = false;

                    // 소환 딜레이 체크
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