using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.BlindShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop.BlindShopAIComponents
{

    class Shelve :BlindShopEntities , IShelve, IAIUser
    {
        private Texture2D Full;
        private Texture2D Empty;

        public Shelve(Vector2 position, Texture2D full, Texture2D empty)
        {
            Full = full;
            Empty = empty;
            this.entityLocn = position;
        }

        public Texture2D GetStocked()
        {
            return Full;
        }

        public Texture2D GetEmpty()
        {
            return Empty;
        }
        public override void Initialise(AIComponentManager _entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(AIComponentManager _entityAI, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public Vector2 GetEntityLocn()
        {
            throw new NotImplementedException();
        }

        public Texture2D GetTexture()
        {
            throw new NotImplementedException();
        }

        public void SetTexture(bool whosethere)
        {
            //if robot == true
            //if customer == false
            if(whosethere == false)
            {
                this.texture = Empty;
            }if(whosethere == true)
            {
                this.texture = Full;
            }
        }

        public void setVelocity(Vector2 _velocity)
        {
            throw new NotImplementedException();
        }

        public void SetVelocityX(float X)
        {
            throw new NotImplementedException();
        }

        public void SetVelocityY(float Y)
        {
            throw new NotImplementedException();
        }

        public void setEntitylocnX(float entlcnX)
        {
            throw new NotImplementedException();
        }

        public void setEntitylocnY(float entlcnY)
        {
            throw new NotImplementedException();
        }

        public Vector2 GetVelocity()
        {
            throw new NotImplementedException();
        }

        public void setEntitylocnUpdate(Vector2 entlcn)
        {
            throw new NotImplementedException();
        }
    }
}
