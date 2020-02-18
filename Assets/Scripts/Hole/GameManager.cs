using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<HoleSpawn> holeSpawns = new List<HoleSpawn>();
    [SerializeField] private GameObject holePrefab;

    private bool isStarted = false;

    void Update()
    {
        if(!isStarted)
        {
            isStarted = true;
            StartCoroutine(SpawnAHole());
        }
    }

    IEnumerator SpawnAHole()
    {
        yield return new WaitForSeconds(3f);

        HoleSpawn randomSpawn = holeSpawns[Random.Range(0, holeSpawns.Count - 1)];

        Instantiate(holePrefab, randomSpawn.pos, randomSpawn.rot);
        isStarted = false;
    }



}
