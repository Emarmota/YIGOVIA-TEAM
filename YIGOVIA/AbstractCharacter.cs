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

    enum SideDirection 
    { 
        STAND_LEFT, STAND_RIGHT, STAND_UP, STAND_DOWN, MOVE_DOWN, MOVE_LEFT, MOVE_RIGHT, MOVE_UP 
    }

    abstract class AbstractCharacter : IMonogame
    {
        protected BasicSprite standLeft, standRight, standUp, standDown;
        protected AnimatedSprite moveLeft, moveRight, moveUp, moveDown;
        protected SideDirection direction;


        public Rectangle Pos
        {
            set
            {
                standLeft.Pos = value;
                standRight.Pos = value;
                standDown.Pos = value;
                standUp.Pos = value;
                moveLeft.Pos = value;
                moveRight.Pos = value;
                moveDown.Pos = value;
                moveUp.Pos = value;
            }

            get
            {
                return standUp.Pos;
            }
        }



        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

    }
}
