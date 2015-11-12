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

namespace Assets.Script.Model.DataModel
{
    /// <summary>
    /// user ranking
    /// </summary>
    [Serializable, ProtoContract]
    //[EntityTable(CacheType.Entity, "ClashOfToys")]
    public class BuildingList : ShareEntityProto
    {
        public BuildingList()
        //: base(false)
        {
            CreateTimeStamp = DateTime.Now;
            //Items = new CacheList<EquiAttrInfo>();
        }

        [ProtoMember(1)]
        //[EntityField(true)]
        public int BuildingId { get; set; }

        public override int Key
        {
            get { return BuildingId; }
            set { BuildingId = value; }
        }

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
        public string BuildingType
        {
            get;
            set;
        }

        [ProtoMember(6)]
        //[EntityField]
        public string BuildingNameEn
        {
            get;
            set;
        }

        [ProtoMember(7)]
        //[EntityField]
        public string BuildingNameCHS
        {
            get;
            set;
        }

        [ProtoMember(8)]
        //[EntityField]
        public string BuildingNameCHT
        {
            get;
            set;
        }

        [ProtoMember(9)]
        //[EntityField]
        public int Level
        {
            get;
            set;
        }

        [ProtoMember(10)]
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

        [ProtoMember(10)]
        //[EntityField]
        public int PriceRock
        {
            get;
            set;
        }

        [ProtoMember(10)]
        //[EntityField]
        public int PriceCloth
        {
            get;
            set;
        }

        [ProtoMember(14)]
        //[EntityField]
        public int AttackRange
        {
            get;
            set;
        }

        [ProtoMember(15)]
        //[EntityField]
        public int AttackSpeed
        {
            get;
            set;
        }

        [ProtoMember(16)]
        //[EntityField]
        public int AttackType
        {
            get;
            set;
        }

        [ProtoMember(17)]
        //[EntityField]
        public int AttackDamage
        {
            get;
            set;
        }

        [ProtoMember(18)]
        //[EntityField]
        public int MaxHealthPoint
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

        [ProtoMember(21)]
        //[EntityField]
        public int SoldierIdGenerated
        {
            get;
            set;
        }

        [ProtoMember(22)]
        //[EntityField]
        public int SoldierNumberGenerated
        {
            get;
            set;
        }

        [ProtoMember(23)]
        //[EntityField]
        public int SoldierNumberKeep
        {
            get;
            set;
        }

        public override String TypeName { get { return this.GetType().Name; } }
    }

    //[Serializable, ProtoContract]
    //public class EquiAttrInfo : EntityChangeEvent
    //{
    //    public EquiAttrInfo()
    //        : base(false)
    //    {
    //    }

    //    /// <summary>
    //    /// 灞炴€?
    //    /// </summary>
    //    [ProtoMember(1)]
    //    public int AttrType
    //    {
    //        get;
    //        set;
    //    }
    //}
}