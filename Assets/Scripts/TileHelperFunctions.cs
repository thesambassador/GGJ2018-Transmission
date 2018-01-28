using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHelperFunctions {

	public static bool CanMoveInDirection(Vector2 tileLocation, Vector2 attemptedMovement, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast(tileLocation, attemptedMovement, .75f, mask);

        if (hit.collider == null)
            return true;
        else
            return false;
    }
}
