using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundExit : StateMachineBehaviour
{
    [SerializeField]
    private SFXClipType _sound;
    [SerializeField, Range(0, 1)]
    private float _volume;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SFXController.Instance.PlaySound(_sound, _volume);
    }
}
