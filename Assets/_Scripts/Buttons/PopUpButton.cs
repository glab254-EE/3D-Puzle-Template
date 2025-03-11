using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    [SerializeField] private string message;
    [SerializeField] private Pop_up pop_Up;
    [SerializeField] private bool hold;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _)){
            pop_Up.OutText = message;
            pop_Up.onhold = hold;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHandler>(out _)){
            pop_Up.OutText = "";
        }        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerHandler>(out _)){
            pop_Up.OutText = message;
            pop_Up.onhold = hold;
        }
        
    }
    void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerHandler>(out _)){
            pop_Up.OutText = "";
        }     
    }
}
