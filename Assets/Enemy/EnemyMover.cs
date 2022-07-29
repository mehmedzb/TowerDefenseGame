using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,4)] float speed = 1f;
    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path.Add(waypoint);    
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    
    void FinishPart()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startpos = transform.position;
            Vector3 endpos = waypoint.transform.position;
            float travelPercent = 0f; 

            transform.LookAt(endpos);
            while(travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startpos,endpos,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPart();
    }
}
