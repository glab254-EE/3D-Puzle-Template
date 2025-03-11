using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostifyButton : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _) && collision.gameObject.TryGetComponent<Collider>(out Collider collider)){
            collider.isTrigger = true;
            Debug.Log("Booohohohohohohohohohohoh");
        }
    }
}
