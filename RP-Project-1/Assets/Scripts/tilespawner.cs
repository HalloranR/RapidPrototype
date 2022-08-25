using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilespawner : MonoBehaviour
{
    public int columbLength, rowLength;
    public float x_space, y_space;
    public GameObject prefab;

    void Start()
    {
        for (int i = 0; i < columbLength * rowLength; i++)
        {
            Instantiate(prefab, new Vector3(x_space * (i % columbLength), 0,y_space * (i / columbLength)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}