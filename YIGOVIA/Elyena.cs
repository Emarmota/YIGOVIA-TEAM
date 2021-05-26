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
    class Elyena
    {
        Hero elyena;

        public Elyena(Rectangle rect, Color color, int incX, int incY)
        {
            elyena = new Hero(rect, color, incX, incY);
        }

        public void SetKeys(Keys left, Keys right, Keys down, Keys up)
        {
            elyena.SetKeys(left, right, down, up);
        }
        public void LoadContent()
        {
            elyena.LoadMove("StandDownm/f01", SideDirection.STAND_DOWN);
            elyena.LoadMove("StandUpm/f01", SideDirection.STAND_UP);
            elyena.LoadMove("StandLeftm/f01", SideDirection.STAND_LEFT);
            elyena.LoadMove("StandRightm/f01", SideDirection.STAND_RIGHT);

            elyena.LoadMove("Move_Downm", "f", 4, 0.09f, SideDirection.MOVE_DOWN);
            elyena.LoadMove("Move_Upm", "f", 4, 0.09f, SideDirection.MOVE_UP);
            elyena.LoadMove("Move_Rightm", "f", 4, 0.09f, SideDirection.MOVE_RIGHT);
            elyena.LoadMove("Move_Leftm", "f", 4, 0.09f, SideDirection.MOVE_LEFT);


            elyena.LoadContent();
        }
        public void Update(GameTime gameTime)
        {
            elyena.Update(gameTime);
        }
        public void Draw(GameTime gameTime)
        {
            elyena.Draw(gameTime);
        }
    }
}
