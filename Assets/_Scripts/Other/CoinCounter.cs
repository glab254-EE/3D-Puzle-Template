using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class CoinCounter : MonoBehaviour
{
    [SerializeField] private PlayerCoins coins;
    TMP_Text _TMP_Text;
    void Start()
    {
        _TMP_Text=GetComponent<TMP_Text>();
    }
    void Update()
    {
        _TMP_Text.text = coins.Coins.ToString();
    }
}
