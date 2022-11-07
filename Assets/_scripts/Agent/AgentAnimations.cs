using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    protected Animator agentAnimator;

    private void Awake()
    {
        agentAnimator = GetComponent<Animator>();
    }

    public void setWalkAnimation(bool val)
    {
        agentAnimator.SetBool("Walking", val);
    }

    public void AnimatePlayer(float velocity)
    {
        setWalkAnimation(velocity > 0);
    }
}
