using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactitePooler : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject baseStalactite;
    [SerializeField] private List<GameObject> stalactitePool;

    WaitForSeconds wait;
    private void Start()
    {
        wait = new WaitForSeconds(spawnTimer);

        GameObject temp;
        stalactitePool = new List<GameObject>();
        for(int i = 0; i < 4; ++i)
        {
            temp = Instantiate(baseStalactite, transform);
            temp.SetActive(false);
            stalactitePool.Add(temp);

        }

        StartCoroutine(SpikeProduction());
    }

    IEnumerator SpikeProduction()
    {
        while (true)
        {
            yield return wait;
            print("activate one");
            ActivateFromPool();
        }
    }

    GameObject ActivateFromPool()
    {
        for(int i = 0; i < stalactitePool.Count; ++i)
        {
            if(stalactitePool[i].activeSelf == false)
            {
                stalactitePool[i].transform.position = transform.position;
                stalactitePool[i].SetActive(true);
                return stalactitePool[i];
            }
        }

        GameObject temp = Instantiate(baseStalactite, transform);
        stalactitePool.Add(temp);
        return temp;
    }
}
