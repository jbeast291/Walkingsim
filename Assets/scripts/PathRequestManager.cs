using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PathRequestManager : MonoBehaviour
{
    Queue<PathRequest> PathRequestQueue = new Queue<PathRequest>();
    PathRequest currentPathRequest;
    static PathRequestManager instance;
    PathFinding pathFinding;
    bool IsProcessingPath;
    private void Awake()
    {
        instance = this;
        pathFinding = GetComponent<PathFinding>();
    }
    public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[],bool> callback)
    {
        PathRequest newRequest = new PathRequest(pathStart,pathEnd,callback);
        instance.PathRequestQueue.Enqueue(newRequest);
        instance.tryProcessNext();

    }
    void tryProcessNext()
    {
        if(!IsProcessingPath && PathRequestQueue.Count > 0)
        {
            currentPathRequest = PathRequestQueue.Dequeue();
            IsProcessingPath = true;
            pathFinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
        }
    }
    public void FinishedProcessingPath(Vector3[] Path, bool Success)
    {
        currentPathRequest.callback(Path, Success);
        IsProcessingPath = false;
        tryProcessNext();
    }



    struct PathRequest
    {
        public Vector3 pathStart;
        public Vector3 pathEnd;
        public Action<Vector3[],bool> callback;
        public PathRequest(Vector3 _Start, Vector3 _End, Action<Vector3[],bool> _callback)
        {
            pathStart = _Start;
            pathEnd = _End;
            callback = _callback;
        }
    }
}
