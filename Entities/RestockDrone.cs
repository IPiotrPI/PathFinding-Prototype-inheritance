using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop.Entities
{
    class RestockDrone : BlindShopEntities, IAIUser
    {
        //Storage for path
        private Queue<Vector2> _path;
        public RestockDrone()
        {
            _path = new Queue<Vector2>();

            #region set up the path
            _path.Enqueue(new Vector2(96, 96));
            _path.Enqueue(new Vector2(96, 64));
            _path.Enqueue(new Vector2(128, 64));
            _path.Enqueue(new Vector2(96, 64));
            _path.Enqueue(new Vector2(96, 96));
            _path.Enqueue(new Vector2(96, 128));
            _path.Enqueue(new Vector2(96, 160));
            #endregion

        }

        #region Getters and setters for properties of the body
        public Vector2 GetEntityLocn()
        {
            return this.entityLocn;
        }

        public Texture2D GetTexture()
        {
            return this.texture;
        }

        public Vector2 GetVelocity()
        {
            return this.velocity;
        }

        public override void Initialise(AIComponentManager _entity)
        {
            
        }

        public void setEntitylocnUpdate(Vector2 entlcn)
        {
            entityLocn = entlcn;
        }

        public void setEntitylocnX(float entlcnX)
        {
            this.entityLocn.X += entlcnX;
        }

        public void setEntitylocnY(float entlcnY)
        {
            this.entityLocn.Y += entlcnY;
        }

        public void SetTexture(bool IsSomeoneThere)
        {
            if(IsSomeoneThere == false)
            {
                this.texture = null;
            }
        }

        public void setVelocity(Vector2 _velocity)
        {
            this.velocity = _velocity;
        }

        public void SetVelocityX(float X)
        {
            this.velocity.X = X;
        }

        public void SetVelocityY(float Y)
        {
            this.velocity.Y = Y;
        }
        #endregion


        public override void Update(AIComponentManager _entityAI, GameTime gameTime)
        {
            if (this.velocity.Y >= 0.5f)
            {
                velocity.Y = 0.5f;
            }
            if (this.velocity.X >= 0.5f)
            {
                velocity.X = 0.5f;
            }
            
            //new delegate for the mutated update, that takes game time as an argument
            ((DroneAI)_entityAI).Update_pathFinder(this, _path, gameTime);
            
            
        }
    }
}
