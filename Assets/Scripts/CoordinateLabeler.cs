using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white; 
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    private float spanKatsayisi = 10f;

    Waypoint waypoint;

    void Awake() 
    {
        label = GetComponent<TextMeshPro>(); 
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();   
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        } 
        ColorCoordinates();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(waypoint.IsPlaceable)
                label.enabled = !label.IsActive();
        }
    }

    void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / spanKatsayisi);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / spanKatsayisi);

        label.text = coordinates.x + "," + coordinates.y ;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
