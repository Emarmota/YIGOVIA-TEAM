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
    //Agregar Colisiones, añadir otra estado a las 3 puertas
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        EscenaMenu menu;
        EscenaJuego nivel1;

        Player player;
        Elyena elyena;
        Rectangle playerRec;
        Rectangle elyenaRec;

        public static int screenHeight, screenWidth;

        int currentscene;

        private Song BGMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

      
        protected override void Initialize()
        {

            screenWidth = 1080;
            screenHeight = 700;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.ApplyChanges();

            menu = new EscenaMenu(new Rectangle(0, 0, screenWidth, screenHeight));
            
            Map.Wnd = new Rectangle(0, 0, screenWidth, screenHeight);

            nivel1 = new EscenaJuego(Map.Wnd, Color.White);

            playerRec.Width = 100;
            playerRec.Height = 100;
            playerRec.X = screenWidth/3 + playerRec.Width;
            playerRec.Y = screenHeight/2 - playerRec.Height;
            playerRec = new Rectangle(playerRec.X, playerRec.Y, playerRec.Width, playerRec.Height);
            
            player = new Player(playerRec, Color.White, 5, 5);
            player.SetKeys(Keys.Left, Keys.Right, Keys.Down, Keys.Up);

            elyenaRec = new Rectangle(600, 135, 70, 75);
            elyena = new Elyena(elyenaRec, Color.White, 5, 5);
            elyena.SetKeys(Keys.A, Keys.D, Keys.S, Keys.W);

            base.Initialize();

        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AbstractSprite.SetSpriteBatch(spriteBatch);
            AbstractSprite.SetContentManager(Content);

            menu.LoadContent(Content);
            nivel1.LoadMap("CenterMap2");
            nivel1.LoadContent();

            BGMusic = Content.Load<Song>("Yigovia_beginning");
            MediaPlayer.IsRepeating=true;
            MediaPlayer.Play(BGMusic);

            player.LoadContent();
            elyena.LoadContent();

        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            menu.Update();
            menu.GetState();

            if (currentscene == 1)
            {
                MediaPlayer.Stop();
                nivel1.Update(gameTime);
                player.Update(gameTime);
                elyena.Update(gameTime);
            }

            else if (currentscene == 0)
            {
                currentscene = menu.GetState();
            }


            base.Update(gameTime);
        }

     
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (currentscene == 1)
            {
                nivel1.Draw(gameTime);
                elyena.Draw(gameTime);
                player.Draw(gameTime);
            }
            else if (currentscene == 0)
            {
                menu.Draw(spriteBatch);
            }



            base.Draw(gameTime);
        }
    }
}
