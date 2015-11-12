using System;
using Assets.Communication;
using Assets.Script.Model;
using ProtoBuf;

namespace Assets.Script.Com.Messages
{
    public enum DatabaseOpType
    {
        Add,
        Delete,
        Modify,
        FindByKey,
        FindByUserId,
        FindByFieldName
    }

    [ProtoContract]
    public class DatabaseMessage
    {
        [ProtoMember(1)]
        public DatabaseOpType OpType { get; set; }

        [ProtoMember(2)]
        public string TypeName { get; set; }

        [ProtoMember(3)]
        public ShareEntityProto Obj { get; set; }

        [ProtoMember(4)]
        public string Key { get; set; }

        [ProtoMember(5)]
        public bool Result { get; set; }

        [ProtoMember(6)]
        public string FieldName { get; set; }

        public override string ToString()
        {
            String str = OpType + ", " + ", Key: " + Key + ", Result: " + Result + "\n";
            str += Obj;
            return str;
        }
    }
}
