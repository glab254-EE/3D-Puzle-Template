using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEnablerOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject GUI;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerHandler>(out _) && !GUI.activeInHierarchy)
        {
            GUI.SetActive(true);
        }
    }
}
