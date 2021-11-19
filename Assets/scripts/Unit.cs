using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3[] path;
    public int targetindex;

    void Start()
    {
        PathRequestManager.RequestPath(transform.position, target.position, onpathfound);
    }
    public void onpathfound(Vector3[] newpath, bool pathsuccess)
    {
        if(pathsuccess)
        {
            path = newpath;
            targetindex = 0;
            StopCoroutine("followpath");
            StartCoroutine("followpath");
        }
    }
    IEnumerator followpath()
    {
        Vector3 waypoint = path[0];
        while (true)
        {
            if(transform.position == waypoint)
            {
                targetindex++;
                if(targetindex >= path.Length)
                {
                    yield break;
                }
                waypoint = path[targetindex];
            }
            Transform.position = Vector3.moveTowards(Transform.position, waypoint, speed * Time.deltaTime);
            yield return null;
        }
        
    }
    
}
