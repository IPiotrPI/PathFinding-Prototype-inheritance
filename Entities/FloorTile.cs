using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.BlindShop.Entities;
using PongEx1.GameEngine.Path_Finding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop
{
    class FloorTile : BlindShopEntities, IKindOfFloor, IAIUser
    {
        //store the node that is on the floor
        public INode _mynode;
        //add an index to me
        int index;

        public bool amIStart = false;
        public bool amIFinish = false;
        public bool amIAroundShelve = false;
        public bool amIDroneDock = false;

        //CREATE floor tile giving it ID and the location where it should be. copy those values to the node that is on me
        public FloorTile(int id, Vector2 tileLocation)
        {
            index = id;
            this.entityLocn = tileLocation;
            _mynode = new Node(id, this.entityLocn);
        }

        public bool GetAmIStart()
        {
            return amIStart;
        }

        public void SetAmIStart(bool i)
        {
            amIStart = i;
        }

        public bool GetAmIFinish()
        {
            return amIFinish;
        }

        public void SetAmIFinish(bool i)
        {
            amIFinish = i;
        }

        public bool GetAmIAroundShelve()
        {
            return amIAroundShelve;
        }

        public void SetAmIAroundSelve(bool i)
        {
            amIAroundShelve = i;
        }

        public void SetAmIDock(bool i)
        {
            amIDroneDock = i;
        }

        public bool GetAmIDock()
        {
            return amIDroneDock;
        }

        public INode GetNode()
        {
            return _mynode;
        }

        public override void Initialise(AIComponentManager _entity)
        {

        }

        public override void Update(AIComponentManager _entityAI, GameTime gameTime)
        {

        }

        public Vector2 GetEntityLocn()
        {
            return this.entityLocn;
        }

        public Texture2D GetTexture()
        {
            return this.texture;
        }

        public void SetTexture(bool IsSomeoneThere)
        {
            
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

        public void setEntitylocnX(float entlcnX)
        {
            this.entityLocn.X = entlcnX;
        }

        public void setEntitylocnY(float entlcnY)
        {
            this.entityLocn.X = entlcnY;
        }

        public Vector2 GetVelocity()
        {
            return this.velocity;
        }

        public void setEntitylocnUpdate(Vector2 entlcn)
        {
            throw new NotImplementedException();
        }
    }
}
