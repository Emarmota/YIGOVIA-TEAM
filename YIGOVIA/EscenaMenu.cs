using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections;


namespace YIGOVIA
{
    class EscenaMenu
    {
        Texture2D fondo;
        Texture2D play;

        Rectangle pos;
        int selectedItem;
        int clickedItem;
        Vector2 btn_play;
        Point hover;

        public EscenaMenu(Rectangle pos)
        {
            this.pos = pos;

        }

        public void LoadContent(ContentManager Content)
        {

            fondo = Content.Load<Texture2D>("Menu/YigoviaScreenv2");
            play = Content.Load<Texture2D>("Menu/BTNPlay");

            clickedItem = 0;
            btn_play.X = 580;
            btn_play.Y = 270;
            hover.X = 120;
            hover.Y = 40;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(fondo, pos, Color.White);
            spriteBatch.Draw(play, new Rectangle((int)btn_play.X, (int)btn_play.Y, hover.X, hover.Y), Color.White);
            spriteBatch.End();

        }

        public int GetState()
        {
            Rectangle boton1 = new Rectangle((int)btn_play.X, (int)btn_play.Y, hover.X, hover.Y);

            if (boton1.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                selectedItem = 1;
                if (selectedItem==1)
                {
                    hover.X = 150;
                    hover.Y = 50;
                }
            }

            else
            {
                selectedItem = 0;
                hover.X = 120;
                hover.Y = 40;
            }
            

            if (selectedItem > 0 && selectedItem != 5 && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clickedItem = selectedItem;
                return clickedItem;
            }

            return 0;
        }

    }
}


