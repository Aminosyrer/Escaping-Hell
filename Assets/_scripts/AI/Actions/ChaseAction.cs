using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = enemyBrain.Target.transform.position;
        enemyBrain.NavHandler.MoveToTarget(enemyBrain.Target.transform);
        enemyBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
    }
}
