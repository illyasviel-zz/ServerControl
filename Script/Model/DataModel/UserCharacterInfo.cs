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
    public class UserCharacterInfo : ShareEntityProto
    {
        public UserCharacterInfo()
            //: base(false)
        {
            Deleted = false;
            CreateTimeStamp = DateTime.Now;
            UserName = "";
            Money = 0;
            Wool = 0;
            Rock = 0;
            Cloth = 0;
            Experience = 0;
            LoginTimes = 0;
            //Items = new CacheList<EquiAttrInfo>();
        }

        [ProtoMember(1)]
        //[EntityField(true)]
        public int UserId
        {
            get;
            set;
        }

        public override int Key
        {
            get { return UserId; }
            set { UserId = value; }
        }

        [ProtoMember(2)]
        //[EntityField]
        public bool Deleted
        {
            get;
            set;
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
        public string UserName
        {
            get;
            set;
        }

        [ProtoMember(6)]
        //[EntityField]
        public int Money
        {
            get;
            set;
        }

        [ProtoMember(7)]
        //[EntityField]
        public int Wool
        {
            get;
            set;
        }

        [ProtoMember(8)]
        //[EntityField]
        public int Rock
        {
            get;
            set;
        }

        [ProtoMember(9)]
        //[EntityField]
        public int Cloth
        {
            get;
            set;
        }

        [ProtoMember(10)]
        //[EntityField]
        public int Experience
        {
            get;
            set;
        }

        public override String TypeName { get { return this.GetType().Name; } }

        [ProtoMember(100)]
        //[EntityField]
        public int LoginTimes
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("*{0}* -- UserId: {1}, UserName: {2}, Money: {3}, Experience: {4}",
                TypeName, UserId, UserName, Money, Experience);
        }
    }
}