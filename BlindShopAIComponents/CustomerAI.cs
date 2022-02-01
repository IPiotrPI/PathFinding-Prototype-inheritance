using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop.BlindShopAIComponents
{
    class CustomerAI : AIComponent, ICollidable
    {
        private IAIUser _body;

        public updateDelegate _update = new updateDelegate(Update);

        public delegate void _pathFollow(IAIUser _entitybody, Queue<Vector2> _path, GameTime gameTime);

        public _pathFollow Update_pathFinder = new _pathFollow(Update_path);

        
        public CustomerAI(IAIUser body)
        {
            _body = body;
            _body.setVelocity(new Vector2(2, 2));
           
        }

        public Dictionary<int, IEntity> ReturnMap()
        {
            throw new NotImplementedException();
        }

        public  Rectangle getHitBox(IAIUser entity)
        {
            if (entity.GetTexture() != null)
            {
                return new Rectangle((int)entity.GetEntityLocn().X, (int)entity.GetEntityLocn().Y, entity.GetTexture().Width, entity.GetTexture().Height);
            }
            else
            {
                return new Rectangle(0,0,0,0);
            }
            
        }

        public  void onCollide(IAIUser entity1, IAIUser entity2)
        {
        }

        public override IAIUser ReturnBody()
        {
            throw new NotImplementedException();
        }

        public override IStateMachine ReturnStateMachine()
        {
            throw new NotImplementedException();
        }

        public static void Update(IAIUser _entity)
        {
          
          Console.WriteLine(_entity.GetEntityLocn());

        }

        //logic for searching the path 
        public static void Update_path(IAIUser _entity, Queue<Vector2> path,  GameTime gameTime)
        {
            #region make customer disappear
            //as time was nearly finished I had to cut corners, and ceate a logic for deleting the entity from the scene
            if (_entity.GetEntityLocn() == new Vector2(32, 64))
            {
                _entity.SetTexture(false);
            }
            #endregion

            //if there are nodes in path
            if (path.Count > 0)
            {
                //if entity is not on the tile from the path
                if (_entity.GetEntityLocn() != path.Peek())
                {
                    //create a rectangle in the middle of the node, so we dont have to go through the exact point, sort of like get hitbox, but more of a switch
                    Rectangle catcher = new Rectangle((int)path.Peek().X, (int)path.Peek().Y, 2, 2);

                    //if node in the path on x axis does not equals entitys X axis. This code is to prefent entity from drifting diagonally
                    if (path.Peek().X != _entity.GetEntityLocn().X)
                    {
                        //if step node X is bigger than Location X go towards it by adding to axis X
                        if (path.Peek().X > _entity.GetEntityLocn().X)
                        {
                            _entity.setEntitylocnX(path.Peek().X * (float)gameTime.ElapsedGameTime.TotalSeconds * _entity.GetVelocity().X);
                        }
                        //if its smaller reverse the result to allow entity walk backwards, and set the velocity to reasonable value
                        else if (path.Peek().X < _entity.GetEntityLocn().X)
                        {
                            //Monogame is not very good in directions, or my math is wrong, but without this line entity is going crazy
                            _entity.setVelocity(new Vector2(2, 2));
                            _entity.setEntitylocnX(-path.Peek().X * (float)gameTime.ElapsedGameTime.TotalSeconds * _entity.GetVelocity().X);
                        }

                    }


                    //Do the same for Y
                    else if (path.Peek().Y != _entity.GetEntityLocn().Y)
                    {


                        _entity.setEntitylocnY(path.Peek().Y * (float)gameTime.ElapsedGameTime.TotalSeconds * _entity.GetVelocity().Y);


                    }
                    //if we are in the correct column, do not drift away
                    else if (path.Peek().Y == _entity.GetEntityLocn().Y)
                    {
                        _entity.SetVelocityY(0);
                    }
                    //if we are in the correct row, do not drift away
                    else if (path.Peek().X == _entity.GetEntityLocn().X)
                    {
                        _entity.SetVelocityX(0);
                    }
                    //If we reached the step, reset the velocity and pop out the setp out of the queue
                    if (catcher.Contains(_entity.GetEntityLocn()) == true)
                    {
                        _entity.setEntitylocnUpdate(path.Peek());
                        path.Dequeue();
                    }
                }

            }
           
            Console.WriteLine(_entity.GetEntityLocn());

        }

        public override void onCollide(IAIUser _entity)
        {
            throw new NotImplementedException();
        }
    }
}
