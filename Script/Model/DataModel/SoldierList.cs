/****************************************************************************
Copyright (c) 2013-2015 scutgame.com

http://www.scutgame.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/

using System;
using ProtoBuf;

//using ZyGames.Framework.Event;
//using ZyGames.Framework.Model;

namespace Assets.Script.Model.DataModel
{
    /// <summary>
    /// user ranking
    /// </summary>
    [Serializable, ProtoContract]
    //[EntityTable(CacheType.Entity, "ClashOfToys")]
    public class SoldierList : ShareEntityProto
    {
        public SoldierList()
            //: base(false)
        {
            CreateTimeStamp = DateTime.Now;
            //Items = new CacheList<EquiAttrInfo>();
        }

        [ProtoMember(1)]
        //[EntityField(true)]
        public int SoldierId
        {
            get;
            set;
        }

        public override int Key
        {
            get { return SoldierId; }
            set { SoldierId = value; }
        }

        //[ProtoMember(2)]
        ////[EntityField]
        //public bool Deleted
        //{
        //    get;
        //    set;
        //}

        [ProtoMember(3)]
        //[EntityField]
        public override DateTime UpdateTimeStamp
        {
            get;
            set;
        }

        [ProtoMember(4)]
        //[EntityField]
        public override DateTime CreateTimeStamp
        {
            get;
            set;
        }

        [ProtoMember(5)]
        //[EntityField]
        public string SoldierNameEN
        {
            get;
            set;
        }

        [ProtoMember(6)]
        //[EntityField]
        public string SoldierNameCH
        {
            get;
            set;
        }

        [ProtoMember(7)]
        //[EntityField]
        public string SoldierNameCHT
        {
            get;
            set;
        }

        [ProtoMember(8)]
        //[EntityField]
        public int Level
        {
            get;
            set;
        }

        [ProtoMember(9)]
        //[EntityField]
        public int PriceMoney
        {
            get;
            set;
        }

        [ProtoMember(10)]
        //[EntityField]
        public int PriceWool
        {
            get;
            set;
        }

        [ProtoMember(11)]
        //[EntityField]
        public int PriceRock
        {
            get;
            set;
        }

        [ProtoMember(12)]
        //[EntityField]
        public int PriceCloth
        {
            get;
            set;
        }

        [ProtoMember(13)]
        //[EntityField]
        public int AttackRange
        {
            get;
            set;
        }

        [ProtoMember(14)]
        //[EntityField]
        public int AttackSpeed
        {
            get;
            set;
        }

        [ProtoMember(15)]
        //[EntityField]
        public int AttackType
        {
            get;
            set;
        }

        [ProtoMember(16)]
        //[EntityField]
        public int AttackDamage
        {
            get;
            set;
        }

        [ProtoMember(17)]
        //[EntityField]
        public int MoveSpeed
        {
            get;
            set;
        }

        [ProtoMember(18)]
        //[EntityField]
        public int HealthPoint
        {
            get;
            set;
        }

        [ProtoMember(19)]
        //[EntityField]
        public int BuildTime
        {
            get;
            set;
        }

        [ProtoMember(20)]
        //[EntityField]
        public int UpgradeTime
        {
            get;
            set;
        }

        public override String TypeName { get { return this.GetType().Name; } }

        public override string ToString()
        {
            String str = this.GetType().Name + ", ";
            str += "Soldier Id: " + SoldierId + ", ";
            str += "Create Time: " + CreateTimeStamp + ", ";
            //str += "User name: " + UserName + ", ";
            //str += "Password hash: " + PasswordHash + ", ";
            return str;
        }
    }
}