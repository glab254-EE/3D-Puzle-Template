using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    [SerializeField] private string message;
    [SerializeField] private Pop_up pop_Up;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _)){
            pop_Up.OutText = message;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _)){
            pop_Up.OutText = "";
        }        
    }
}
