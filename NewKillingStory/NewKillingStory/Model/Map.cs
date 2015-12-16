using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NewKillingStory.Model;
using NewKillingStory.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory
{
    class Map
    {
        //Camera camera;
        private List<CollisionTiles> collisiontiles = new List<CollisionTiles>();// skapar några listor som gör att jag kan lägga till alla mina tiles spriset här i för att skapa kollision

        public List<CollisionTiles> CollisionTiles
        {
            get { return collisiontiles; }// denna läggger man in kollision med!
        }
        private int width, height;// tiles kommer ha en höjd och en bredd// följde en liten guid på denna!
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        public Map()
        {

        }
        public void Generate(int[,] map, int size)//krånglig funktion!//fick hjälp med denna!
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if(number > 0)
                    {
                        collisiontiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    }

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)//, Camera camera)
        {
            foreach (CollisionTiles tile in collisiontiles)//för varje tile i denna ritar vi ut en tile!
            {
                tile.Draw(spriteBatch);//, camera.getScaleForView(width*2));
            }
        }
    }
}
