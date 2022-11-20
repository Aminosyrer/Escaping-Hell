using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        Debug.Log(this.transform.parent.gameObject.transform.parent.gameObject.name);
        enemyBrain.NavHandler.ClearTarget();
        aiMovementData.Direction = Vector2.zero;
        aiMovementData.PointOfInterest = transform.position;
        enemyBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
    }
}
