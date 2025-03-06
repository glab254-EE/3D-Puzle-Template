using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float openingtime;
    [SerializeField] private float closingtime;
    internal bool IsOpen;
    private bool operationing;
    internal IEnumerator ToggleDoor(){
        if (!operationing)
        {
            operationing = true;
            if (!IsOpen)
            {
                animator.SetTrigger("Open");
                yield return new WaitForSeconds(openingtime);
                animator.SetBool("IsOpen",true);
            } else 
            {
                animator.SetBool("IsOpen",false);
                yield return new WaitForSeconds(closingtime);
            }
            IsOpen = !IsOpen;
            operationing = false;
        }
    }
    internal IEnumerator ToggleDoor(bool state){
        if (!operationing && IsOpen == state)
        {
            IsOpen = !state;
            operationing = true;
            if (!IsOpen)
            {
                animator.SetTrigger("Open");
                yield return new WaitForSeconds(openingtime);
                animator.SetBool("IsOpen",true);
            } else 
            {
                animator.SetBool("IsOpen",false);
                yield return new WaitForSeconds(closingtime);
            }
            operationing = false;
        }
    }
}