using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.BlindShop.BlindShopAIComponents;
using PongEx1.GameEngine.Path_Finding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop.Entities
{
    class Customer : BlindShopEntities, IAIUser
    {

        public Dictionary<int, IKindOfFloor> Map;
        private IPathfinderManager _myLookout;
        private Queue<Vector2> _path;


        public Customer(Dictionary<int, IKindOfFloor> _map)
        {
            Map = _map;
            _myLookout = new PathFindingManager();
            _path = new Queue<Vector2>();
            _path.Enqueue(new Vector2(32, 0));
            _path.Enqueue(new Vector2(64, 0));
            _path.Enqueue(new Vector2(64, 32));
            _path.Enqueue(new Vector2(96, 32));
            _path.Enqueue(new Vector2(96, 64));
            _path.Enqueue(new Vector2(128, 64));
            _path.Enqueue(new Vector2(96, 64));
            _path.Enqueue(new Vector2(64, 64));
            _path.Enqueue(new Vector2(32, 64));
            _path.Enqueue(new Vector2(0, 64));
            _path.Enqueue(new Vector2(0, 64));
            //path.Enqueue(new Vector2(32, 128));
        }

        public Queue<Vector2> path(int startID, int EndID)
        {
           foreach(KeyValuePair<int, IKindOfFloor> item in Map)
            {
                if(_myLookout.GetOpen().ContainsValue(item.Value.GetNode()) == false && _myLookout.GetOpen().Count <= Map.Count)
                {
                    _myLookout.AddToOpen(item.Key, item.Value.GetNode());
                }
                else
                {
                    break;
                }
            }
            Queue<Vector2> _actualPath = new Queue<Vector2>();
            
           // _actualPath.(_myLookout.SearchThrueTheMap(startID, EndID));
            INode[] _path = new INode[36];
            _myLookout.SearchThrueTheMap(startID, EndID).CopyTo( _path, 1);
            for (int i = 1; i < _path.Length; i++)
            {
                if(_path[i]!= null)
                {
                    INode step = _path[i];
                    _actualPath.Enqueue(step.GetLocaction());
                }
                else
                {
                    continue;
                }
               
            }
            return _actualPath;

        }
      
        public Vector2 GetEntityLocn()
        {
            return entityLocn;
        }

        public void setEntitylocnX(float entlcnX)
        {
            this.entityLocn.X += entlcnX;
        }

        public void setEntitylocnY(float entlcnY)
        {
            this.entityLocn.Y += entlcnY;
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

       
        public void setEntitylocnUpdate(Vector2 entlcn)
        {
            entityLocn = entlcn;
        }

        public void setVelocity(Vector2 _velocity)
        {
            velocity = _velocity;
        }

        public void SetVelocityX(float X)
        {
            velocity.X = X;
        }
        public void SetVelocityY(float Y)
        {
            velocity.Y = Y;
        }


        public override void Initialise(AIComponentManager _entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(AIComponentManager _entityAI, GameTime gameTime)
        {
            if(this.velocity.X >= 0.5f)
            {
                velocity.X = 0.5f;
            }
            ((CustomerAI)_entityAI).Update_pathFinder(this, _path, gameTime);
            ((CustomerAI)_entityAI)._update.Invoke(this);
        }

        public void SetTexture(bool IsSomeoneThere)
        {
            if(IsSomeoneThere == false)
            {
                this.texture = null;
            }
        }
    }
}
