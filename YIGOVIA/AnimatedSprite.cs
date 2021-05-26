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
    class AnimatedSprite : BasicSprite
    {
        int frameCount;         
        int countX;           
        int countY;          
        int currentFrame;       
        ArrayList textureList;
        float timer;           
        float timePerFrame;    
        bool multipleFiles; 
        int frameWidth;        
        int frameHeight;       
        string nameDir;

        public AnimatedSprite(Rectangle rect, Color color)
            : base(rect, color)
        {
            pos = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void SingleFile(string filename, int countX, int countY, float timePerFrame, int frameWidth, int frameHeight)
        {
            this.filename = filename;
            this.countX = countX;
            this.countY = countY;
            this.frameCount = countX * countY;
            this.timePerFrame = timePerFrame;
            this.currentFrame = 0;
            this.timer = 0.0f;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            multipleFiles = false;
        }
        public void MultipleFiles(string nameDir, string filename, int frameCount, float timePerFrame)
        {
            this.nameDir = nameDir;
            this.filename = filename;
            this.frameCount = frameCount;
            this.timePerFrame = timePerFrame;
            this.currentFrame = 0;
            this.timer = 0.0f;
            this.textureList = new ArrayList();

            this.multipleFiles = true;
        }
        public override void LoadContent()
        {
            if (!multipleFiles)
            {
                //Actually load the texture
                base.LoadContent();
            }
            else
            {
                //Load all the texture image
                for (int k = 1; k <= frameCount; k++)
                {
                    Texture2D tex;
                    tex = content.Load<Texture2D>(nameDir + "/" + filename + k.ToString("00"));
                    textureList.Add(tex);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            //Calculate how much time has passed
            timer = timer + (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //Draw animated sprite based  on multiple files
            if (multipleFiles)
            {
                if (currentFrame < textureList.Count)
                {
                    Texture2D tex = (Texture2D)textureList[currentFrame];
                    spriteBatch.Draw(tex, pos, color);
                }
            }
            else
            {
                int xTex, yTex;
                int currX, currY;
                Rectangle sourceRect;

                currX = currentFrame % countX;
                currY = currentFrame / countX;
                xTex = currX * frameWidth;
                yTex = currY * frameHeight;
                sourceRect = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                spriteBatch.Draw(image, pos, sourceRect, color);
            }
            spriteBatch.End();
            //base.Draw(gameTime);
        }

    }
}
