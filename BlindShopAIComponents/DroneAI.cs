using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop.Entities
{
    class DroneAI : AIComponent, ICollidable
    {

        private IAIUser _body;

        public delegate void _pathFollow(IAIUser _entitybody, Queue<Vector2> _path, GameTime gameTime);

        public _pathFollow Update_pathFinder = new _pathFollow(Update_path);

        public DroneAI(IAIUser body)
        {
            _body = body;
            _body.setVelocity(new Vector2(2, 2));

        }
        public Rectangle getHitBox(IAIUser entity)
        {
            if (entity.GetTexture() != null)
            {
                return new Rectangle((int)entity.GetEntityLocn().X, (int)entity.GetEntityLocn().Y, entity.GetTexture().Width, entity.GetTexture().Height);
            }
            else
            {
                return new Rectangle(0, 0, 0, 0);
            }
        }

        public override void onCollide(IAIUser _entity)
        {
            throw new NotImplementedException();
        }

        public void onCollide(IAIUser entity1, IAIUser entity2)
        {
            if(entity2 is FloorTile && ((IKindOfFloor)entity2).GetAmIDock() == true)
            {
                entity1.SetTexture(false);

            }
        }


        ///For complete comments go to Customer AI
        public static void Update_path(IAIUser _entity, Queue<Vector2> path, GameTime gameTime)
        {
            
            if (path.Count > 0)
            {

                if (_entity.GetEntityLocn() != path.Peek())
                {
                    Rectangle catcher = new Rectangle((int)path.Peek().X, (int)path.Peek().Y, 2, 2);

                    if (path.Peek().X != _entity.GetEntityLocn().X)
                    {
                        if (path.Peek().X > _entity.GetEntityLocn().X)
                        {
                            _entity.setEntitylocnX(path.Peek().X * (float)gameTime.ElapsedGameTime.TotalSeconds * _entity.GetVelocity().X);
                        }
                        else if (path.Peek().X < _entity.GetEntityLocn().X)
                        {
                            
                            _entity.setEntitylocnX(-path.Peek().X * (float)gameTime.ElapsedGameTime.TotalSeconds * _entity.GetVelocity().X);
                        }

                    }
                    else if (path.Peek().Y != _entity.GetEntityLocn().Y)
                    {


                        if (path.Peek().Y < _entity.GetEntityLocn().Y)
                        {
                            _entity.setEntitylocnY(-path.Peek().Y * (float)gameTime.ElapsedGameTime.TotalSeconds * _entity.GetVelocity().Y);
                        }
                       if (path.Peek().Y > _entity.GetEntityLocn().Y)
                        {
                            //_entity.setVelocity(new Vector2(2, 2));
                            _entity.setEntitylocnY(path.Peek().Y * (float)gameTime.ElapsedGameTime.TotalSeconds * _entity.GetVelocity().Y);
                        }


                    }
                    else if (path.Peek().Y == _entity.GetEntityLocn().Y)
                    {
                        _entity.SetVelocityY(0);
                    }
                    else if (path.Peek().X == _entity.GetEntityLocn().X)
                    {
                        _entity.SetVelocityX(0);
                    }
                    if (catcher.Contains(_entity.GetEntityLocn()) == true)
                    {
                        _entity.setEntitylocnUpdate(path.Peek());
                        path.Dequeue();
                    }
                }

            }

            Console.WriteLine(_entity.GetEntityLocn());

        }

        public override IAIUser ReturnBody()
        {
            throw new NotImplementedException();
        }

        public override IStateMachine ReturnStateMachine()
        {
            throw new NotImplementedException();
        }
    }
}
