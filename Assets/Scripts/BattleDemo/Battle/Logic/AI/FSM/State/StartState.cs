﻿using System;
using FSM;
namespace Battle.Logic.AI.FSM
{
    class StartState : FSMStateBase<TroopData, BattleData>
    {
        public StartState(Enum name) : base(name)
        {
        }
        public override void Init(BattleData dataMgr)
        {
            base.Init(dataMgr);
        }
        public override Enum Enter(ref TroopData data)
        {
            //死亡
            if (data.count==0)
            {
                data.state = (int)TroopAnimState.Die;
                return TroopFSMState.End;
            }
            //前置动作
            if (data.inPrepose)
            {
                if (data.preTime>0)
                {
                    data.preTime -= 1;
                }
                else
                {
                    //发射武器
                    data.inPrepose = false;
                }
                data.state = (int)TroopAnimState.Idle;
                return TroopFSMState.End;
            }
            //普攻CD
            if (data.norAtkCD > 0)
            {
                data.norAtkCD -= 1;
                data.state = (int)TroopAnimState.Idle;
                return TroopFSMState.End;
            }
            //寻找目标
            return TroopFSMState.FindTarget;
        }

    }
}