using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tilespawner : MonoBehaviour
{
    public int columbLength, rowLength;
    public float x_space, y_space;
    public GameObject prefab;
    public GameObject centerPrefab;
    public GameObject edgePrefab;
    public Enemy_Spawner enemySpawner;
    public Text textBox;
    public Text timerBox;

    void Awake()
    {
        for (int i = 0; i < columbLength * rowLength; i++)
        {
            if (i==columbLength*rowLength/2)
            {
                GameObject tile = Instantiate(centerPrefab, new Vector3(x_space * (i % columbLength), 0, y_space * (i / columbLength)), Quaternion.identity);
                tile.GetComponent<PlayerTile_Script>().textObject = textBox;
            }
            else
            {
                GameObject tile = Instantiate(prefab, new Vector3(x_space * (i % columbLength), 0, y_space * (i / columbLength)), Quaternion.identity);
                tile.GetComponent<tile_script>().textbox = timerBox;

                if (i < columbLength || i > columbLength * rowLength - columbLength - 1 || (i)%9 == 0 || (i+1)%9 == 0)
                {
                    enemySpawner.edgeTiles.Add(tile);
                    tile.GetComponent<tile_script>().edge = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
