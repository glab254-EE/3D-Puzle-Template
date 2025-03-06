using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningButton : MonoBehaviour
{
    [SerializeField] private AnimationDoor door;
    [SerializeField] private string BoxTag;
    private bool state;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _) || collision.gameObject.CompareTag(BoxTag)){
            state = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _) || collision.gameObject.CompareTag(BoxTag)){
            state = false;
        }        
    }
    void Update()
    {
        if (door.IsOpen == state){
            StartCoroutine(door.ToggleDoor(state));
        }
    }
}
