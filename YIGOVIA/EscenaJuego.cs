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
using System;

namespace YIGOVIA
{
    class EscenaJuego: IMonogame
    {
            Map mapa_nivel1;

        public EscenaJuego(Rectangle pos, Color color)
        {
            mapa_nivel1 = new Map(pos, color);

        }

        public void LoadContent()
        {
            mapa_nivel1.LoadContent();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {
            mapa_nivel1.Draw(gameTime);
        }

        public void LoadMap(String filename)
        {
            mapa_nivel1.LoadImage(filename);
        }
             
    }
}
