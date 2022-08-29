using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTile_Script : MonoBehaviour
{
    public int lives = 3;

    public Text textObject;
    

    private void OnCollisionEnter(Collision collision)
    {
        print("collided");
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            lives -= 1;

            if (lives <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                textObject.text = "Lives : " + lives;
            }
        }
    }
}
