using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower tower;

    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown() 
    {
        if(isPlaceable)
        {
            bool isPlaced = tower.CreateTower(tower , transform.position);
            isPlaceable = !isPlaced;
        }   
    }

}
