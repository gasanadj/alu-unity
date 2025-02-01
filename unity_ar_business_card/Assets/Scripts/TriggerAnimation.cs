using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator[] animators;
    private DefaultObserverEventHandler targetObserver;
    void Start()
    {
        targetObserver = GetComponent<DefaultObserverEventHandler>();

        foreach(Animator animator in animators)
        {
            animator.enabled = false;
        }

        if (targetObserver != null)
        {
            targetObserver.OnTargetFound.AddListener(PlayAnimations);
        }
    }

    private void PlayAnimations()
    {
        foreach(Animator animator in animators)
        {
            animator.enabled = true;
        }
    }
}
