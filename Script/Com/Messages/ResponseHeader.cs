using System;
using ProtoBuf;

namespace Assets.Script.Com.Messages
{
    [ProtoContract]
    public class ResponseHeader
    {
        [ProtoMember(1)]
        public int MsgId { get; set; }
        [ProtoMember(2)]
        public int ActionId { get; set; }
        [ProtoMember(3)]
        public int ErrorCode { get; set; }
        [ProtoMember(4)]
        public String ErrorInfo { get; set; }
        [ProtoMember(5)]
        public String St { get; set; }
    }
}