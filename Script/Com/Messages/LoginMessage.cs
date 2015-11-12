using ProtoBuf;

namespace Assets.Script.Com.Messages
{
    [ProtoContract]
    public class LoginMessage
    {
        [ProtoMember(1)]
        public int UserId { get; set; }
        [ProtoMember(2)]
        public string UserName { get; set; }
        [ProtoMember(3)]
        public string Password { get; set; }
    }
}