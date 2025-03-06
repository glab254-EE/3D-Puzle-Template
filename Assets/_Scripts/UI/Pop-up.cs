using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Pop_up : MonoBehaviour
{
    [SerializeField] internal string OutText = "";
    TMP_Text _Text;
    void Start()
    {
        _Text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        _Text.text = OutText;
    }
}
