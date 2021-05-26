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
    class BasicSprite : AbstractSprite
    {
        protected static Rectangle wnd;
        protected Rectangle source;
        protected bool collision = false;

        public BasicSprite(Rectangle pos, Color color)
        {
            this.pos = pos;
            this.color = color;
        }
        public void LoadImage(string filename)
        {
            this.filename = filename;
        }
        public override void LoadContent()
        {
            if (filename != null || content != null)
                image = content.Load<Texture2D>(filename);

            source = new Rectangle(0, 0, image.Width, image.Height);
        }
        public override void Draw(GameTime gameTime)
        {

            if (spriteBatch != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(image, pos, Color.White);
                spriteBatch.End();
            }

        }

        public override void Update(GameTime gameTime)
        {

        }


        public static Rectangle Wnd
        {
            set { wnd = value; }
            get { return wnd; }
        }

        public virtual bool CheckColCharacter(Rectangle colCharacter)
        {

            if (!collision)
            {
                if (pos.Intersects(colCharacter))
                {
                    collision = true;
                    return true;
                }
                else
                {
                    collision = false;
                    return false;
                }

            }
            return false;
        }
    }
}

