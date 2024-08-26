using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    public bool IsRunning {
        get { return IsRunning; }
        set {
            IsRunning = value;
            PlayIsRunning();
        }
    }
    public bool IsInAir
    {
        get { return IsInAir; }
        set
        {
            IsInAir = value;
            PlayIsInAir();
        }
    }

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayJump()
    {
        _animator.SetTrigger("jump");
    }

    private void PlayIsRunning()
    {

        _animator.SetBool("isRunning", IsRunning);
    }

    private void PlayIsInAir()
    {

        _animator.SetBool("isInAir", IsInAir);
    }


}
