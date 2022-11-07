using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimationUpDown : AgentAnimations
{
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        agentAnimator = GetComponent<Animator>();
    }

    private void setDirection(Vector3 mousePosition)
    {
        int direction = GetPointerArea(mousePosition);
        // look mom a switch case
        switch (direction)
        {
            case 0:
                agentAnimator.SetBool("Looking down", false);
                agentAnimator.SetBool("Looking up", false);
                spriteRenderer.flipX = true;
                break;
            case 1:
                agentAnimator.SetBool("Looking down", false);
                agentAnimator.SetBool("Looking up", true);
                spriteRenderer.flipX = false;
                break;
            case 2:
                agentAnimator.SetBool("Looking down", false);
                agentAnimator.SetBool("Looking up", false);
                spriteRenderer.flipX = false;
                break;
            case 3:
                agentAnimator.SetBool("Looking down", true);
                agentAnimator.SetBool("Looking up", false);
                spriteRenderer.flipX = false;
                break;
            default:
                // this block should never be hit but just in case we will face right (default)
                agentAnimator.SetBool("Looking down", false);
                agentAnimator.SetBool("Looking up", false);
                spriteRenderer.flipX = false;
                break;
        }
    }

    public void AnimatePlayerDirection(Vector2 mousePosition)
    {
        setDirection(mousePosition);
    }

    // 0 = most left
    // 1 = most up
    // 2 = most right
    // 3 = most down
    private int GetPointerArea(Vector2 mousePostion)
    {
        // bottom left corner
        if (mousePostion.x < 0.5 && mousePostion.y < 0.5)
        {
            return mousePostion.x < mousePostion.y ? 0 : 3;
        }
        //Top left corner
        else if (mousePostion.x < 0.5 && mousePostion.y > 0.5)
        {
            var DisToTop = 1 - mousePostion.y;
            return mousePostion.x < DisToTop ? 0 : 1;
        }
        //Top right corner
        else if (mousePostion.x > 0.5 && mousePostion.y > 0.5)
        {
            var DisToTop = 1 - mousePostion.y;
            var DisToRight = 1 - mousePostion.x;
            return DisToRight > DisToTop ? 1 : 2;
        }
        // bottom right corner
        else
        {
            var DisToRight = 1 - mousePostion.x;
            return DisToRight < mousePostion.y ? 2 : 3;
        }
    }
}
