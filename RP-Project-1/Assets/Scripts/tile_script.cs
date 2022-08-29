using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tile_script : MonoBehaviour
{
    public Material normal;
    public Material target;

    public RayCast rayScript;

    private int waitTime;

    MeshRenderer meshRenderer;
    BoxCollider box;

    private bool extra = false;

    public bool edge = false;

    public Text textbox;

    private void Awake()
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
        yield return new WaitForSeconds(waitTime);

        if (extra) 
        { 
            textbox.text = "Long Hole: Active";
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
        if (!edge)
        {
            meshRenderer.enabled = false;
            box.enabled = false;

            waitTime = 2;
        }
    }

    public void turnOffTileLong()
    {
        if (!edge)
        {
            textbox.text = "Long Hole: Inactive";
            rayScript.hold = true;
            extra = true;

            meshRenderer.enabled = false;
            box.enabled = false;

            waitTime = 8;
        }
    }
}
