using PongEx1.GameEngine.Path_Finding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.BlindShop.Entities
{
    interface IKindOfFloor
    {
        bool GetAmIStart();

        void SetAmIStart(bool i);

        void SetAmIDock(bool i);

        bool GetAmIDock();

        bool GetAmIFinish();

        void SetAmIFinish(bool i);

        bool GetAmIAroundShelve();

        void SetAmIAroundSelve(bool i);

        INode GetNode();
    }
}
