using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<HoleSpawn> holeSpawns = new List<HoleSpawn>();
    [SerializeField] private GameObject holePrefab = null;
    [SerializeField] private float holeSpawnFrequency = 3f;

    private bool isStarted = false;
    private int currentHoleSpawnID = 0;

    void Update()
    {
        //Instantiates holes for test purposes.
        if(!isStarted)
        {
            isStarted = true;
            StartCoroutine(SpawnAHole());
        }
    }

    public void AddNewHoleSpawnToList(HoleSpawn holeSpawn)
    {
        holeSpawn.id = currentHoleSpawnID;
        holeSpawns.Add(holeSpawn);

        currentHoleSpawnID++;
    }

    IEnumerator SpawnAHole()
    {
        yield return new WaitForSeconds(holeSpawnFrequency);

        List<HoleSpawn> useableHoles = holeSpawns.FindAll(hole => hole.canSpawn == true);

        if(useableHoles.Count <= 0) { isStarted = false; yield break; }

        HoleSpawn randomSpawn = useableHoles[Random.Range(0, useableHoles.Count - 1)];
        randomSpawn.canSpawn = false;
        holeSpawns[randomSpawn.id] = randomSpawn;

        GameObject spawnedHole = Instantiate(holePrefab, randomSpawn.pos, randomSpawn.rot);
        spawnedHole.GetComponent<Hole>().holeSpawnID = randomSpawn.id;
    
        isStarted = false;
    }

    public void SetHoleFree(int id)
    {
        HoleSpawn holeToSetFree = holeSpawns.Find(hole => hole.id == id);
        holeToSetFree.canSpawn = true;
        holeSpawns[holeToSetFree.id] = holeToSetFree;

    }

}
