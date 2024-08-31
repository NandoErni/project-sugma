using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private bool _isRunning;
    private bool _isInAir;

    public bool IsRunning {
        get { return _isRunning; }
        set {
            _isRunning = value;
            PlayIsRunning();
        }
    }
    public bool IsInAir
    {
        get { return _isInAir; }
        set
        {
            _isInAir = value;
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

    public void PlaySoundOnAnimation(SFXClipType clipType)
    {
        SFXController.Instance.PlaySound(clipType);
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
