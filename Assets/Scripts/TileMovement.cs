using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TileMovement : MonoBehaviour {
    public float offset = .5f;

    public float moveSpeed = 3;

    public Vector2 currentTileWorldCoordinates;
    public Vector2 currentTargetTileWorldCoordinates;



    public bool moving = false;

    public LayerMask raycastMask;

	// Use this for initialization
	void Start () {
        transform.position = SnapToTile(transform.position);
        currentTileWorldCoordinates = transform.position;
        currentTargetTileWorldCoordinates = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position, currentTargetTileWorldCoordinates) > .001f)
        {
            moving = true;
            transform.position = Vector2.MoveTowards(transform.position, currentTargetTileWorldCoordinates, moveSpeed * Time.deltaTime);
        }
        else
        {
            moving = false;
            transform.position = currentTargetTileWorldCoordinates;
            currentTileWorldCoordinates = currentTargetTileWorldCoordinates;
        }
	}

    [Button]
    public bool MoveUp()
    {
        Vector2 direction = Vector2.up;
        return MoveDirection(direction);
    }

    [Button]
    public bool MoveDown()
    {
        Vector2 direction = Vector2.down;
        return MoveDirection(direction);
    }

    public bool MoveRight()
    {
        Vector2 direction = Vector2.right;
        return MoveDirection(direction);
    }
    public bool MoveLeft()
    {
        Vector2 direction = Vector2.left;
        return MoveDirection(direction);
    }

    public bool MoveDirection(Vector2 dir)
    {
        if(TileHelperFunctions.CanMoveInDirection(currentTileWorldCoordinates, dir, raycastMask))
        {
            currentTargetTileWorldCoordinates = currentTileWorldCoordinates + dir;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector2 SnapToTile(Vector2 worldCoordinates)
    {
        worldCoordinates.x = Mathf.Floor(worldCoordinates.x - offset) + offset;
        worldCoordinates.y = Mathf.Floor(worldCoordinates.y - offset) + offset;
        return worldCoordinates;
    }

    [Button]
    public void SnapPositionToTile()
    {
        transform.position = SnapToTile(transform.position);
    }
   
}
