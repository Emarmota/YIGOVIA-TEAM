using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YIGOVIA
{
    class Player
    {
        Hero player;

        public Player(Rectangle rect, Color color, int incX, int incY)
        {
            player = new Hero(rect, color, incX, incY);
        }

        public void SetKeys(Keys left, Keys right, Keys down, Keys up)
        {
            player.SetKeys(left, right, down, up);
        }
        public void LoadContent()
        {
            player.LoadMove("StandDown/f01", SideDirection.STAND_DOWN);
            player.LoadMove("StandUp/f01", SideDirection.STAND_UP);
            player.LoadMove("StandLeft/f01", SideDirection.STAND_LEFT);
            player.LoadMove("StandRight/f01", SideDirection.STAND_RIGHT);

            player.LoadMove("Move_Down", "f", 9, 0.05f, SideDirection.MOVE_DOWN);
            player.LoadMove("Move_Up", "f", 9, 0.05f, SideDirection.MOVE_UP);
            player.LoadMove("Move_Right", "f", 9, 0.05f, SideDirection.MOVE_RIGHT);
            player.LoadMove("Move_Left", "f", 8, 0.05f, SideDirection.MOVE_LEFT);


            player.LoadContent();
        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }
        public void Draw(GameTime gameTime)
        {
            player.Draw(gameTime);
        }
    }
}
