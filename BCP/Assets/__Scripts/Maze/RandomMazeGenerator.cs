using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMazeGenerator : MonoBehaviour
{
    public GameObject cellPrefab;

    public GameObject basePrefab;

    public Vector3 cellSize = new Vector3(1, 1, 0);

    public Int32 height, width;

    void Start()
    {
        MazeCreator mazeCreator = new MazeCreator(height, width);
        MazeCreatorCell[,] maze = mazeCreator.CreateMaze();


        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(cellPrefab, new Vector3(x * cellSize.x, y * cellSize.y, y * cellSize.z), Quaternion.identity)
                    .GetComponent<Cell>();

                c.wallLeft.SetActive(maze[x, y].wallLeft);
                c.wallBottom.SetActive(maze[x, y].wallBottom);
                c.floor.SetActive(maze[x, y].floor);
            }
        }
    }

}
