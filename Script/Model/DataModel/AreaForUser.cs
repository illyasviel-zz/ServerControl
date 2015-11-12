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
    public class AreaForUser : ShareEntityProto
    {
        public AreaForUser()
        {
            Deleted = false;
        }

        public static AreaForUser CreateRandom(Random rand)
        {
            AreaForUser obj = new AreaForUser();

            obj.AreaId = rand.Next(100);
            obj.EnemyId = rand.Next(100);
            obj.UserId = rand.Next(100);
            obj.AreaStatus = rand.Next(3);

            return obj;
        }

        [ProtoMember(1)]
        ////[EntityField(true)]
        public int Id { get; set; }

        public override int Key { get { return Id; } set { Id = value; } }

        [ProtoMember(2)]
        ////[EntityField]
        public bool Deleted { get; set; }

        [ProtoMember(3)]
        //[EntityField]
        public int UserId
        {
            get;
            set;
        }

        [ProtoMember(4)]
        //[EntityField]
        public int EnemyId
        {
            get;
            set;
        }

        [ProtoMember(5)]
        //[EntityField]
        public int AreaId
        {
            get;
            set;
        }

        [ProtoMember(6)]
        //[EntityField]
        public String AreaName
        {
            get;
            set;
        }

        [ProtoMember(7)]
        //[EntityField]
        public int AreaStatus
        {
            get;
            set;
        }

        public override string TypeName { get { return this.GetType().Name; } }

        public override string ToString()
        {
            return string.Format("*{0}* -- Id: {1}, UserId: {2}, EnemyId: {3}, AreaId: {4}",
                TypeName, Id, UserId, EnemyId, AreaId);
        }
    }
}