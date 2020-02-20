using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public int holeSpawnID = -1;
    public float holeHealth = 3;

    public void DamageHole()
    {
        holeHealth -= 1;

        Vector3 newScale = new Vector3(holeHealth / 3, holeHealth / 3, holeHealth / 3);
        transform.localScale = newScale;

        if (holeHealth <= 0) DestroyHole();
    }

    void DestroyHole()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SetHoleFree(holeSpawnID);
        Destroy(gameObject);
    }

}
