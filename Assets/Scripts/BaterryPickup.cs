using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaterryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<FlashLight>().RestoreLight();
            Destroy(gameObject);
        }
    }
}
