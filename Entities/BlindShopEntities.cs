using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop.Entities
{
    abstract class BlindShopEntities : Entity
    {

        //DECLARE vector2 used to store the location of each 2d entity, call it entityLocn
        public Vector2 entityLocn;
        //DECLARE Texture2D used to store the texture of each 2d entity, call it texture
        protected Texture2D texture;
        //DECLARE Vector2 used to change the velocity of entities, call it velocity
        public Vector2 velocity;
 
        public override void draw(SpriteBatch spriteBatch)
        {
            if(texture != null)
            {
                spriteBatch.Draw(texture, entityLocn, Color.AntiqueWhite);
            }
            
        }

        public abstract override void Initialise(AIComponentManager _entity);


        public override void setPosition(float x, float y)
        {
            entityLocn.X = x;
            entityLocn.Y = y;
        }

        public override void setTexture(Texture2D texture2D)
        {
            texture = texture2D;
        }

        public abstract override void Update(AIComponentManager _entityAI, GameTime gameTime);
 
    }
}
