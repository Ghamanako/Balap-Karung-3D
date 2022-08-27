using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Grid grid;
    public Transform startPosition;
    public Transform TargetPosition;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        FindPath(startPosition.position, TargetPosition.position);
    }

    void FindPath(Vector3 a_startPos, Vector3 a_TargetPos)
    {
        Node StartNode = grid.NodeFromWorldPosition(a_startPos);
        Node TargetNode = grid.NodeFromWorldPosition(a_TargetPos);

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();

        OpenList.Add(StartNode);

        while (OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];
                for(int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].HCost < CurrentNode.HCost)
                {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
            }

            foreach(Node NeighborNode in grid.GetNeighboringNodes(CurrentNode))
            {
                if (!NeighborNode.IsObstacles || ClosedList.Contains(NeighborNode))
                {
                    continue;
                }
                int MoveCost = CurrentNode.GCost + getManhattenDistance(CurrentNode, NeighborNode);

                if (MoveCost < NeighborNode.GCost || !OpenList.Contains(NeighborNode))
                {
                    NeighborNode.GCost = MoveCost;
                    NeighborNode.HCost = getManhattenDistance(NeighborNode, TargetNode);
                    NeighborNode.parent = CurrentNode;

                    if (!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }
        }
    }

    void GetFinalPath(Node a_startingNode, Node a_EndNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = a_EndNode;

        while (CurrentNode != a_startingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.parent;
        }

        FinalPath.Reverse();

        grid.FinalPath = FinalPath; 
    }

    int getManhattenDistance(Node a_nodeA,Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.GridX - a_nodeB.GridY);
        int iy = Mathf.Abs(a_nodeA.GridY - a_nodeB.GridY);

        return ix + iy;
    }
}
