using Microsoft.Xna.Framework;
using PongEx1.BlindShop.BlindShopAIComponents;
using PongEx1.BlindShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop
{
    class FloorAI : AIComponent, ICollidable
    {
        IAIUser _body;
        IAIUser _neighbouringShelfe;

        public FloorAI(IAIUser body)
        {
            _body = body;
        }
        public FloorAI(IAIUser body, IAIUser neighbouringShelfe)
        {
            _body = body;
            _neighbouringShelfe = neighbouringShelfe;
        }
        public Rectangle getHitBox(IAIUser entity)
        {
            return new Rectangle((int)entity.GetEntityLocn().X, (int)entity.GetEntityLocn().Y, entity.GetTexture().Width, entity.GetTexture().Height);
        }

        public void onCollide(IAIUser entity1, IAIUser entity2)
        {
            if (((IKindOfFloor)entity1).GetAmIAroundShelve() == true)
            {
                if (entity2 is Customer)
                {
                    bool customer = false;
                    _neighbouringShelfe.SetTexture(customer);
                    //Shelve change texture to empty
                }
                else if (entity2 is RestockDrone)
                {
                    _neighbouringShelfe.SetTexture(true);
                }

                if (((IKindOfFloor)entity1).GetAmIFinish() == true)
                {
                    if (entity2 is Customer)
                    {
                        bool customer = false;
                        _neighbouringShelfe.SetTexture(customer);
                        //Shelve change texture to empty
                    }
                }
                if (((IKindOfFloor)entity1).GetAmIDock() == true)
                {
                    if (entity2 is RestockDrone)
                    {
                        bool customer = false;
                        _neighbouringShelfe.SetTexture(false);
                        //Shelve change texture to empty
                    }
                }
            }
        }

        public override void onCollide(IAIUser _entity)
        {
            throw new NotImplementedException();
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
