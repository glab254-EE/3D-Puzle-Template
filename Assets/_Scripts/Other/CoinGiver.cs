using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGiver : MonoBehaviour
{
    [SerializeField] private double ammount = 1;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerCoins>(out PlayerCoins coins)){
            coins.AddCoins(ammount);
            Destroy(gameObject);
        }
    }
}
