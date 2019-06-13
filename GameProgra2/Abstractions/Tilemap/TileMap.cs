using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Managers;
using static Game.Utils.Enums;

namespace Game
{
    class TileMap
    {

        List<Tile> tileMapList = new List<Tile>();
        int[,] tileMap;
        float size;


        public TileMap(int[,] tileMap, float size, string[] paths)
        {

            this.size = size;
            this.tileMap = tileMap;

            for (float row = 0; row < tileMap.GetLength(0); row++)
            {
                for (float column = 0; column < tileMap.GetLength(1); column++)
                {
                    int tileValue = tileMap[(int)row, (int)column];

                    if (tileValue >= 0)
                    {
                        TileWallRol tileRol;

                        if(row == 0)
                        {
                            tileRol = TileWallRol.left;
                        }
                        else if(row == tileMap.GetLength(0) - 1)
                        {
                            tileRol = TileWallRol.right;
                        } else if(column == 0)
                        {
                            tileRol = TileWallRol.top;
                        } else if(column == tileMap.GetLength(1) - 1)
                        {
                            tileRol = TileWallRol.down;
                        } else
                        {
                            tileRol = TileWallRol.none;
                        }

                        tileMapList.Add(new Tile((row) * size, (column) * size, size, paths[tileValue], tileRol));
                    }

                }
            }
        }

        public Tile CheckCollision(Collider collider)
        {
            foreach(Tile tile in tileMapList)
            {
                if(Vector2D.distance(tile.Vector2(), collider.Vector2()) <= size*2)
                {
                    if(Collider.CheckCollision(tile.getCollider(), collider))
                    {
                        return tile;
                    }
                }
            }

            return null;
        }

        public void Render()
        {
            foreach (Tile tile in tileMapList)
            {
                tile.Render();
                //tile.DrawCollider();
            }
        }

        private int[] GetPosition(Vector2D vector2D)
        {
            int x = (int)(vector2D.x / size);
            int y = (int)(vector2D.y / size);

            
            return new int[] { x, y };
        }

    }
}
