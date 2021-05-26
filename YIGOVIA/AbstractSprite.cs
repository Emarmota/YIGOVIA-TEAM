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
    abstract class AbstractSprite : IMonogame
    {
        
        protected static SpriteBatch spriteBatch;
        protected static ContentManager content;

        public static void SetSpriteBatch(SpriteBatch spriteBatchIn)
        {
            spriteBatch = spriteBatchIn;
        }

        public static void SetContentManager(ContentManager contentIn)
        {
            content = contentIn;
        }

        protected Rectangle pos;
        protected Texture2D image;
        protected Color color;
        protected string filename;

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        public Rectangle Pos
        {
            get { return pos; }
            set { pos = value; }
        }


    }
}
