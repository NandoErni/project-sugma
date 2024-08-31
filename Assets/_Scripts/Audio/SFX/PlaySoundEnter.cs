using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEnter : StateMachineBehaviour
{
    [SerializeField]
    private SFXClipType _sound;
    [SerializeField, Range(0,1)]
    private float _volume;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SFXController.Instance.PlaySound(_sound, _volume);
    }
}
