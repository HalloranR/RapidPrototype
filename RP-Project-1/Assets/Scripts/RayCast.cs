using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public LineRenderer line;
    private LineRenderer spawnedLine;

    public Vector3 cameraOffset
;
    public Camera cam;

    public int dist = 45;

    public GameObject curTile;
    public tile_script script;

    public bool hold = false;


    private void Start()
    {
        spawnedLine = Instantiate(line);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTile();
        }

        RaycastHit hit;
        
        Ray ray = new Ray(cam.transform.position,  cam.transform.forward * dist);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)){
            spawnedLine.SetPosition(0, transform.position + cameraOffset);
            spawnedLine.SetPosition(1, hit.point);


            if (hit.transform.gameObject.tag == "normTile")
            {
                if(hit.transform.gameObject != curTile)
                {
                    if(script != null)
                    {
                        script.ResetMaterial();
                    }
                    curTile = hit.transform.gameObject;

                    script = curTile.GetComponent<tile_script>();

                    script.ChangeMaterial();
                }
            }
        }
        else {
            spawnedLine.SetPosition(0, transform.position);
            spawnedLine.SetPosition(1, transform.position);
        }
    }

    public void SetTile()
    {
        if(script != null)
        {
            if (hold)
            {
                script.rayScript = this;
                script.turnOffTile();
            }
            else
            {
                script.rayScript = this;
                script.turnOffTileLong();
            }
        }
    }
}
