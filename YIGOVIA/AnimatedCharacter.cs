#region Includes
using System;
using System.Collections.Generic;
using System.Collections;
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
    class AnimatedCharacter : AbstractCharacter
    {

        public AnimatedCharacter(Rectangle rect, Color color)
        {
            standLeft = new BasicSprite(rect, color);
            standRight = new BasicSprite(rect, color);
            standUp = new BasicSprite(rect, color);
            standDown = new BasicSprite(rect, color);
            moveLeft = new AnimatedSprite(rect, color);
            moveRight = new AnimatedSprite(rect, color);
            moveUp = new AnimatedSprite(rect, color);
            moveDown = new AnimatedSprite(rect, color);
        }

        public void LoadMove(string nameDir, string filename, int framecount, float timePerFrame, SideDirection direction)
        {
            switch (direction)
            {
                case (SideDirection.MOVE_DOWN):
                    moveDown.MultipleFiles(nameDir, filename, framecount, timePerFrame);
                    break;
                case (SideDirection.MOVE_UP):
                    moveUp.MultipleFiles(nameDir, filename, framecount, timePerFrame);
                    break;
                case (SideDirection.MOVE_LEFT):
                    moveLeft.MultipleFiles(nameDir, filename, framecount, timePerFrame);
                    break;
                case (SideDirection.MOVE_RIGHT):
                    moveRight.MultipleFiles(nameDir, filename, framecount, timePerFrame);
                    break;
            }
        }

        public void LoadMove(string filename, SideDirection direction)
        {
            switch (direction)
            {
                case (SideDirection.STAND_DOWN):
                    standDown.LoadImage(filename);
                    break;
                case (SideDirection.STAND_LEFT):
                    standLeft.LoadImage(filename);
                    break;
                case (SideDirection.STAND_RIGHT):
                    standRight.LoadImage(filename);
                    break;
                case (SideDirection.STAND_UP):
                    standUp.LoadImage(filename);
                    break;
            }
        }

        public override void LoadContent()
        {
            moveDown.LoadContent();
            moveUp.LoadContent();
            moveLeft.LoadContent();
            moveRight.LoadContent();
            standDown.LoadContent();
            standUp.LoadContent();
            standLeft.LoadContent();
            standRight.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
        

            switch (direction)
            {
                case (SideDirection.MOVE_DOWN):
                    moveDown.Update(gameTime);
                    break;
                case (SideDirection.MOVE_UP):
                    moveUp.Update(gameTime);
                    break;
                case (SideDirection.MOVE_LEFT):
                    moveLeft.Update(gameTime);
                    break;
                case (SideDirection.MOVE_RIGHT):
                    moveRight.Update(gameTime);
                    break;
                case (SideDirection.STAND_DOWN):
                    standDown.Update(gameTime);
                    break;
                case (SideDirection.STAND_LEFT):
                    standLeft.Update(gameTime);
                    break;
                case (SideDirection.STAND_RIGHT):
                    standRight.Update(gameTime);
                    break;
                case (SideDirection.STAND_UP):
                    standUp.Update(gameTime);
                    break;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            switch (direction)
            {
                case (SideDirection.MOVE_DOWN):
                    moveDown.Draw(gameTime);
                    break;
                case (SideDirection.MOVE_UP):
                    moveUp.Draw(gameTime);
                    break;
                case (SideDirection.MOVE_LEFT):
                    moveLeft.Draw(gameTime);
                    break;
                case (SideDirection.MOVE_RIGHT):
                    moveRight.Draw(gameTime);
                    break;
                case (SideDirection.STAND_DOWN):
                    standDown.Draw(gameTime);
                    break;
                case (SideDirection.STAND_LEFT):
                    standLeft.Draw(gameTime);
                    break;
                case (SideDirection.STAND_RIGHT):
                    standRight.Draw(gameTime);
                    break;
                case (SideDirection.STAND_UP):
                    standUp.Draw(gameTime);
                    break;
            }
        }
    }
}
