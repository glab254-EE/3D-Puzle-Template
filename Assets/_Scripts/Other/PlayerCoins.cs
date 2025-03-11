using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    internal double Coins{ get;private set;} = 0;
    internal void AddCoins(double ammount)
    {
        Coins+=ammount;
    }
}
