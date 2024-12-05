using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;
    private Animator animator;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetIsRunTrue()
    {
        animator.SetBool("isRun", true);
    }
    public void SetIsRunFalse()
    {
        animator.SetBool("isRun", false);
    }
}
