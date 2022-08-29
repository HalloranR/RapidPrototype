using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
