using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform StartPosition;
    public LayerMask WallMask;
    public Vector2 GridWorldSize;
    public float NodeRadius;
    public float Distance;

    Node[,] grid;
    public List<Node> FinalPath;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = NodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(GridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(GridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 BottomLeft = transform.position - Vector3.right * GridWorldSize.x / 2 - Vector3.forward * GridWorldSize.y / 2;
        for(int y = 0; y < gridSizeX; y++)
        {
            for(int x = 0; x < gridSizeY; x++)
            {
                Vector3 worldPoint = BottomLeft + Vector3.right * (x * nodeDiameter + NodeRadius) + Vector3.forward * (y * nodeDiameter + NodeRadius);
                bool obstacles = true;

                if (Physics.CheckSphere(worldPoint, NodeRadius, WallMask))
                {
                    obstacles = false;
                }

                grid[y, x] = new Node(obstacles, worldPoint, x, y);
            }
        }
    }


    public Node NodeFromWorldPosition(Vector3 a_WorldPosition)
    {
        float Xpoint = ((a_WorldPosition.x + GridWorldSize.x / 2) / GridWorldSize.x);
        float Ypoint = ((a_WorldPosition.z + GridWorldSize.y / 2) / GridWorldSize.y);

        Xpoint = Mathf.Clamp01(Xpoint);
        Ypoint = Mathf.Clamp01(Ypoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * Xpoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * Ypoint);

        return grid[x, y];
    }

    public List<Node>GetNeighboringNodes(Node a_node)
    {
        List<Node> NeighboringNodes = new List<Node>();
        int xCheck;
        int YCheck;

        xCheck = a_node.GridX + 1;
        YCheck = a_node.GridY;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (YCheck >= 0 && YCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, YCheck]);
            }
        }

        xCheck = a_node.GridX - 1;
        YCheck = a_node.GridY;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (YCheck >= 0 && YCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, YCheck]);
            }
        }

        xCheck = a_node.GridX ;
        YCheck = a_node.GridY+1;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (YCheck >= 0 && YCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, YCheck]);
            }
        }

        xCheck = a_node.GridX ;
        YCheck = a_node.GridY - 1;

        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (YCheck >= 0 && YCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, YCheck]);
            }
        }

        return NeighboringNodes;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(GridWorldSize.x, 1, GridWorldSize.y));

        if (grid != null)
        {
            foreach(Node node in grid)
            {
                if (node.IsObstacles)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.yellow; 
                }

                if (FinalPath != null)
                {
                    Gizmos.color = Color.red;
                }

                Gizmos.DrawCube(node.Position, Vector3.one * (nodeDiameter - Distance));
            }
        }
    }
}
