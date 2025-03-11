using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterArea : MonoBehaviour
{
    [SerializeField] private Transform destination;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _)){
            collision.transform.position = destination.position;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerHandler>(out _)){
            other.transform.position = destination.position;
        }
        
    }
}
