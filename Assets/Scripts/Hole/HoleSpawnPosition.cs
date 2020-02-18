using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawnPosition : MonoBehaviour
{
    void Awake()
    {

        HoleSpawn holeSpawn = new HoleSpawn();
        holeSpawn.pos = transform.position;
        holeSpawn.rot = transform.rotation;

        GameObject gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<GameManager>().holeSpawns.Add(holeSpawn);

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }
}

public struct HoleSpawn
{
    public Vector3 pos;
    public Quaternion rot;
}
