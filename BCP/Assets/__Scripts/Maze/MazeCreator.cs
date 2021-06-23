using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCreatorCell
{
    public Int32 x, y;

    public Boolean wallLeft = true, wallBottom = true, floor = true;

    public Boolean visited = false;
}



public class MazeCreator
{
    public Int32 height, width;

    public MazeCreator(Int32 height, Int32 width)
    {
        this.height = height + 1;
        this.width = width + 1;
    }

    public MazeCreatorCell[,] CreateMaze()
    {
        MazeCreatorCell[,] maze = CreateMazeCells();
        RemoveWallsWithBacktracker(maze);
        return maze;
    }

    private MazeCreatorCell[,] CreateMazeCells()
    {
        var maze = new MazeCreatorCell[width, height];

        for (Int32 horizontalCell = 0; horizontalCell < maze.GetLength(0); horizontalCell++)
        {
            for (int verticalCell = 0; verticalCell < maze.GetLength(1); verticalCell++)
            {
                maze[horizontalCell, verticalCell] =
                    new MazeCreatorCell { x = horizontalCell, y = verticalCell };
            }
        }

        RemoveWallsInLastCells(maze);

        return maze;
    }

    private MazeCreatorCell[,] RemoveWallsInLastCells(MazeCreatorCell[,] maze)
    {
        for (Int32 horizontalCell = 0; horizontalCell < maze.GetLength(0); horizontalCell++)
        {
            maze[horizontalCell, height - 1].wallLeft = false;
            maze[horizontalCell, height - 1].floor = false;  
        }

        for (Int32 verticalCell = 0; verticalCell < maze.GetLength(1); verticalCell++)
        {
            maze[width - 1, verticalCell].wallBottom = false;
            maze[width - 1, verticalCell].floor = false;
        }

        return maze;
    }


    private void RemoveWallsWithBacktracker(MazeCreatorCell[,] maze)
    {
        MazeCreatorCell current = maze[0, 0];
        current.visited = true;

        Stack<MazeCreatorCell> stack = new Stack<MazeCreatorCell>();

        do
        {
            List<MazeCreatorCell> unvisitedNearbyCells = new List<MazeCreatorCell>();
            Int32 x = current.x;
            Int32 y = current.y;

            if (x > 0 && !maze[x - 1, y].visited)
                unvisitedNearbyCells.Add(maze[x - 1, y]);

            if (y > 0 && !maze[x, y - 1].visited)
                unvisitedNearbyCells.Add(maze[x, y - 1]);

            if (x < width - 2 && !maze[x + 1, y].visited)
                unvisitedNearbyCells.Add(maze[x + 1, y]);

            if (y < height - 2 && !maze[x, y + 1].visited)
                unvisitedNearbyCells.Add(maze[x, y + 1]);

            
            if (unvisitedNearbyCells.Count > 0)
            {
                MazeCreatorCell chosen =
                    unvisitedNearbyCells[UnityEngine.Random.Range(0, unvisitedNearbyCells.Count)];

                RemoveWall(current, chosen);

                chosen.visited = true;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeCreatorCell a, MazeCreatorCell b)
    {
        if (a.x == b.x)
        {
            if (a.y > b.y) a.wallBottom = false;
            else b.wallBottom = false;
        }
        else
        {
            if (a.x > b.x) a.wallLeft = false;
            else b.wallLeft = false;
        }
    }
}