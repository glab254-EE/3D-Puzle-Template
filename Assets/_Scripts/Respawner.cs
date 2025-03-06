using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHandler>(out _)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
