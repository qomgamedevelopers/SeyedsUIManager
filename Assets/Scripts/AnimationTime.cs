using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTime : MonoBehaviour
{
    public static float Time(Animator animator, string animationName)
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;

        foreach (var item in ac.animationClips)
            if (item.name == animationName)
                return item.length;

        Debug.LogError("Not Find");
        return 0;
    }
}