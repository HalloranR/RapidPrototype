using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public List<GameObject> edgeTiles;

    public float timer;

    public float resetTimer;

    public GameObject enemy;

    public Vector3 boost;

    public GameObject player;

    void Update()
    {
        timer-=Time.deltaTime;

        if (timer <= 0)
        {
            timer = resetTimer;
            
            enemy = Instantiate(enemy, edgeTiles[Random.Range(0,edgeTiles.Count-1)].transform.position + boost, Quaternion.identity);
            enemy.GetComponent<Enemy_Script>().target = player;
        }
    }
}
