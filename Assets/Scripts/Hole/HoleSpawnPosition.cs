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
        holeSpawn.canSpawn = true;

        GameObject gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<GameManager>().AddNewHoleSpawnToList(holeSpawn);

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }
}

public struct HoleSpawn
{
    public int id;
    public Vector3 pos;
    public Quaternion rot;
    public bool canSpawn;
    public GameObject hole;
}
