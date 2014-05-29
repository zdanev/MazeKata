namespace MazeKata
{
    using System.Collections.Generic;

    public class Maze
    {
        private const int wall = -1;
        private const int empty = 0;

        public int Width { get; private set; }

        public int Height { get; private set; }

        private int[,] cells;

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            cells = new int[height, width];
        }

        public bool IsEmpty(int x, int y)
        {
            return cells[x, y] == empty;
        }

        public bool IsWall(int x, int y)
        {
            return cells[x, y] == wall;
        }

        public void SetWall(int x, int y)
        {
            cells[x, y] = wall;
        }

        public void SetValue(int x, int y, int value)
        {
            cells[x, y] = value;
        }

        public int GetValue(int x, int y)
        {
            return cells[x, y];
        }

        public bool AreConnected(int x1, int y1, int x2, int y2)
        {
            return Distance(x1, y1, x2, y2) > 0;
        }

        public int Distance(int x1, int y1, int x2, int y2)
        {
            Wave(x1, y1);
            return cells[x2, y2];
        }

        private Queue<Point> queue = new Queue<Point>();

        private void Wave(int x, int y)
        {
            GoTo(x, y, 1);

            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();
                int dist = GetValue(p.X, p.Y) + 1;
                GoTo(p.X - 1, p.Y, dist);
                GoTo(p.X + 1, p.Y, dist);
                GoTo(p.X, p.Y - 1, dist);
                GoTo(p.X, p.Y + 1, dist);
            }
        }

        private void GoTo(int x, int y, int dist)
        {
            if (0 <= x && x < Width && 0 <= y && y < Height && IsEmpty(x, y))
            {
                SetValue(x, y, dist);
                queue.Enqueue(new Point(x, y));
            }
        }
    }
}