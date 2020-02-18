using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public int holeSpawnID = -1;

    public void DestroyHole()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SetHoleFree(holeSpawnID);
        Destroy(gameObject);
    }

}
