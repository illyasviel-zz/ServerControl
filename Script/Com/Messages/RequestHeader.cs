using System;
using ProtoBuf;

namespace Assets.Script.Com.Messages
{
    [ProtoContract]
    public class RequestHeader
    {
        [ProtoMember(1)]
        public int MsgId { get; set; }
        [ProtoMember(2)]
        public String SessionId { get; set; }
        [ProtoMember(3)]
        public int ActionId { get; set; }
        [ProtoMember(4)]
        public int UserId { get; set; }
    }
}