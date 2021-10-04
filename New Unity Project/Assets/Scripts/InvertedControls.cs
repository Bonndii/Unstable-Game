using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedControls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.inverted = -1;
        }
    }
}
