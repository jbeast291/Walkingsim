using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    public Transform seeker, target;
    Grid grid;

    void Awake() {
        grid = GetComponent<Grid>();
    }

    void Update() {
        FindPath(seeker.position, target.position);
    }
    public void StartFindPath(Vector3 startposition, Vector3 targetPosition)
    {
        StartCoroutine(FindPath(startposition, targetPosition));
    }

    IEnumerator FindPath(PathRequest request, Action<PathResult> callback)
    {
        Vector3[] waypoints = new Vector3[0];
        bool pathsuccess = false;
        Node startNode = grid.NodeFromWorldPoint(request.pathStart - new Vector3(2785, 0, 325));
        Node targetNode = grid.NodeFromWorldPoint(request.pathEnd - new Vector3(2785, 0, 325));
        startNode.parent = startNode;
        if(startNode.walkable && targetNode.walkable)
        {
            Heap1<Node> openSet = new Heap1<Node>(grid.maxSize);
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0) {
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);
                if (currentNode == targetNode) {
                    RetracePath(startNode, targetNode);
                    return;
                }

                foreach (Node neighbor in grid.GetNeighbors(currentNode)) {
                    if (!neighbor.walkable || closedSet.Contains(neighbor)) {
                        continue;
                    }

                    int newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                    if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor)) {
                        neighbor.gCost = newMovementCostToNeighbor;
                        neighbor.hCost = GetDistance(neighbor, targetNode);
                        neighbor.parent = currentNode;

                        if (!openSet.Contains(neighbor)) openSet.Add(neighbor);
                    }
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode) {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode) {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }

    int GetDistance(Node nodeA, Node nodeB) {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
        
        if (distX > distY) return 14 * distY + 10 * (distX - distY);

        return 14 * distX + 10 * (distY - distX);
    }
}
