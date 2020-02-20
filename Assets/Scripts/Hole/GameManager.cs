﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<HoleSpawn> holeSpawns = new List<HoleSpawn>();
    [SerializeField] private GameObject holePrefab = null;
    [SerializeField] private GameObject waterLevelObject = null;
    [SerializeField] private float holeFillAmountPerSecond = 2f;
    [SerializeField] private float maxWaterAmount = 100f;
    [SerializeField] private float spawnDelay = 10f;
    [SerializeField] private float spawnDelayReducePerSecond = 0.032f;
    [SerializeField] private float minimumSpawnDelay = 3f;

    private float currentWaterAmount = 0;
    private bool isStarted = false;
    private int currentHoleSpawnID = 0;

    private float waterLevelStartingHeight = 0;
    [SerializeField] private float waterLevelFinalHeight = 1.5f;


    private void Start()
    {
        waterLevelStartingHeight = waterLevelObject.transform.position.y;
        waterLevelFinalHeight += waterLevelStartingHeight;
    }

    void Update()
    {
        UpdateSpawnDelay();
        UpdateWaterLevel();

        //Instantiates holes for test purposes.
        if(!isStarted)
        {
            isStarted = true;
            StartCoroutine(SpawnAHole());
        }
    }

    private void UpdateSpawnDelay()
    {
        spawnDelay -= spawnDelayReducePerSecond * Time.deltaTime;
        if (spawnDelay < minimumSpawnDelay) spawnDelay = minimumSpawnDelay;
    }

    private void UpdateWaterLevel()
    {
        foreach(HoleSpawn spawn in holeSpawns)
        {
            if(spawn.canSpawn == false) // This means it is full.
            {
                currentWaterAmount += holeFillAmountPerSecond * Time.deltaTime * spawn.hole.transform.localScale.x;
                if (currentWaterAmount > maxWaterAmount) currentWaterAmount = maxWaterAmount;
            }
        }

        float heightOfWater = Map(0, maxWaterAmount, waterLevelStartingHeight, waterLevelFinalHeight, currentWaterAmount);
        Vector3 newPos = waterLevelObject.transform.position;
        newPos.y = heightOfWater;
        waterLevelObject.transform.position = newPos;

    }

    public void AddNewHoleSpawnToList(HoleSpawn holeSpawn)
    {
        holeSpawn.id = currentHoleSpawnID;
        holeSpawns.Add(holeSpawn);

        currentHoleSpawnID++;
    }

    IEnumerator SpawnAHole()
    {
        yield return new WaitForSeconds(spawnDelay);

        List<HoleSpawn> useableHoles = holeSpawns.FindAll(hole => hole.canSpawn == true);

        if(useableHoles.Count <= 0) { isStarted = false; yield break; }

        HoleSpawn randomSpawn = useableHoles[Random.Range(0, useableHoles.Count - 1)];

        GameObject spawnedHole = Instantiate(holePrefab, randomSpawn.pos, randomSpawn.rot);
        spawnedHole.GetComponent<Hole>().holeSpawnID = randomSpawn.id;

        randomSpawn.canSpawn = false;
        randomSpawn.hole = spawnedHole;

        holeSpawns[randomSpawn.id] = randomSpawn;
        isStarted = false;
    }

    public void SetHoleFree(int id)
    {
        HoleSpawn holeToSetFree = holeSpawns.Find(hole => hole.id == id);
        holeToSetFree.canSpawn = true;
        holeSpawns[holeToSetFree.id] = holeToSetFree;

    }

    public float GetWaterPercentage() { return currentWaterAmount / maxWaterAmount * 100; }
    static float Map(float a1, float a2, float b1, float b2, float s) => b1 + (s - a1) * (b2 - b1) / (a2 - a1);

}