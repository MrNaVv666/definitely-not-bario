using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatcherScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.PLAYER_TAG)
        {
            print("spadles");
            collision.GetComponent<PlayerDamage>().RestartSceneFunction();
        }
    }
}
