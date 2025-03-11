using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TMP_Text))]
public class Pop_up : MonoBehaviour
{
    [SerializeField] internal string OutText = "";
    internal bool onhold = false;
    private PlayerInputActions inputActions;
    TMP_Text _Text;
    void Start()
    {
        inputActions = new();
        _Text = GetComponent<TMP_Text>();
        inputActions.InGame.Fire.performed += OnClick;
        inputActions.InGame.Fire.Enable();
    }
    void OnClick(InputAction.CallbackContext _)
    {
        onhold = false;
    }
    void OnDestroy()
    {
        inputActions.InGame.Fire.performed -= OnClick;
        inputActions.InGame.Fire.Disable();
    }
    void Update()
    {
        if (_Text.text == "" || !onhold)
        {
            _Text.text = OutText;
        }
    }
}
