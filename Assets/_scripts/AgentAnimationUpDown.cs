using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimationUpDown : AgentAnimations
{
    private void setDirection(int direction)
    {
        if(direction == 1)
        {
            agentAnimator.SetBool("Looking up", true);
            return;
        }
        agentAnimator.SetBool("Looking up", false);
        if(direction == 3)
        {
            agentAnimator.SetBool("Looking down", true);
            return;
        }
        agentAnimator.SetBool("Looking down",  false);
    }

    public void AnimatePlayerDirection(int direction)
    {
        setDirection(direction);
    }


}
