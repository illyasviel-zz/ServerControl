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
    public class UserAccount : ShareEntityProto
    {
        public UserAccount()
        //: base(false)
        {
            Deleted = false;
            CreateTimeStamp = DateTime.Now;
            UserName = "";
            PasswordHash = "";
            PasswordSalt = "";
            Email = "";
            EmailVerified = false;
            IsActive = false;
            IsBanned = false;
            IsOnline = false;
            IsAdmin = false;
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
        public override DateTime CreateTimeStamp { get; set; }

        [ProtoMember(5)]
        //[EntityField]
        public string UserName
        {
            get;
            set;
        }

        [ProtoMember(101)]
        public string Password { get; set; }

        [ProtoMember(6)]
        //[EntityField]
        public string PasswordHash
        {
            get;
            set;
        }

        [ProtoMember(7)]
        //[EntityField]
        public string PasswordSalt
        {
            get;
            set;
        }

        [ProtoMember(8)]
        //[EntityField]
        public string Email
        {
            get;
            set;
        }

        [ProtoMember(9)]
        //[EntityField]
        public bool EmailVerified
        {
            get;
            set;
        }

        [ProtoMember(10)]
        //[EntityField]
        public bool IsActive
        {
            get;
            set;
        }

        [ProtoMember(11)]
        //[EntityField]
        public bool IsBanned
        {
            get;
            set;
        }

        [ProtoMember(12)]
        //[EntityField]
        public bool IsOnline
        {
            get;
            set;
        }

        [ProtoMember(13)]
        //[EntityField]
        public bool IsAdmin
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
            String str = this.GetType().Name + ", ";
            str += "UserId: " + UserId + ", ";
            str += "Create Time: " + CreateTimeStamp + ", ";
            str += "User name: " + UserName + ", ";
            str += "Password hash: " + PasswordHash + ", ";
            return str;
        }
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