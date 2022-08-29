using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_script : MonoBehaviour
{
    public Material normal;
    public Material target;

    public RayCast rayScript;

    private int waitTime;

    MeshRenderer meshRenderer;
    BoxCollider box;

    private bool extra = false;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        box = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (!box.enabled)
        {
            StartCoroutine(wait());
        }
    }

    public IEnumerator wait()
    {
        print("Here");
        yield return new WaitForSeconds(waitTime);

        if (extra) 
        { 
            rayScript.hold = false;
        }

        meshRenderer.enabled = true;
        box.enabled = true;
    }

    public void ChangeMaterial()
    {
        meshRenderer.material = target;
    }

    public void ResetMaterial()
    {
        meshRenderer.material = normal;
    }


    public void turnOffTile()
    {
        meshRenderer.enabled = false;
        box.enabled = false;

        waitTime = 2;
    }

    public void turnOffTileLong()
    {
        rayScript.hold = true;
        extra = true;

        meshRenderer.enabled = false;
        box.enabled = false;

        waitTime = 8;
    }
}
