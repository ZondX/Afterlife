using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] PlayerController player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
            player.SetOnGround(true);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
            player.SetOnGround(true);
    }
}
