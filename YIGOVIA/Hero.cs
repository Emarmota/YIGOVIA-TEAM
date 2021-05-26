#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Drawing;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace YIGOVIA
{
    class Hero : AnimatedCharacter
    {
        Keys leftK, rightK, upK, downK;
        bool setKeys;
        Point inc;

        public Hero(Rectangle rect, Color color, int incX, int incY)
            : base(rect, color)
        {

            inc = new Point(incX, incY);
        }
        public void SetKeys(Keys left, Keys right, Keys down, Keys up)
        {
            leftK = left;
            rightK = right;
            downK = down;
            upK = up;
            setKeys = true;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle temp = Pos;
            //Move from KB
            if (direction == SideDirection.MOVE_LEFT)
                direction = SideDirection.STAND_LEFT;
            else if (direction == SideDirection.MOVE_RIGHT)
                direction = SideDirection.STAND_RIGHT;
            else if (direction == SideDirection.MOVE_DOWN)
                direction = SideDirection.STAND_DOWN;
            else if (direction == SideDirection.MOVE_UP)
                direction = SideDirection.STAND_UP;

            if (setKeys)
            {

                if (Keyboard.GetState().IsKeyDown(leftK))
                {
                    temp.X -= inc.X;
                    direction = SideDirection.MOVE_LEFT;
                }
                else if (Keyboard.GetState().IsKeyDown(rightK))
                {
                    temp.X += inc.X;
                    direction = SideDirection.MOVE_RIGHT;
                }
                else if (Keyboard.GetState().IsKeyDown(upK))
                {
                    temp.Y -= inc.Y;
                    direction = SideDirection.MOVE_UP;
                }
                else if (Keyboard.GetState().IsKeyDown(downK))
                {
                    temp.Y += inc.Y;
                    direction = SideDirection.MOVE_DOWN;
                }
                //Wall Collision X
                if (temp.X + temp.Width >= BasicSprite.Wnd.Width)
                    temp.X = BasicSprite.Wnd.Width - temp.Width;
                else if (temp.X <= 0)
                    temp.X = 0;
                //Wall Collision Y
                if (temp.Y + temp.Height >= BasicSprite.Wnd.Height)
                    temp.Y = BasicSprite.Wnd.Height - temp.Height;
                else if (temp.Y <= 0)
                    temp.Y = 0;

                Pos = temp;
            }
            base.Update(gameTime);
        }

    }
}
