using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestAnimation : MonoBehaviour
{
    public Animator animator;
    public const string STR_ISWALK = "isWalk";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetAnimClientWalk()
    {
        animator.SetBool(STR_ISWALK, true);
    }
    public void SetAnimClientIdle()
    {
        animator.SetBool(STR_ISWALK, false);
    }
}
