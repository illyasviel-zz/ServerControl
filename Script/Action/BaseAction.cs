using Assets.Script.Com.Messages;
using ZyGames.Framework.Common.Serialization;

namespace Assets.Script.Action
{
    /// <summary>
    /// 自定结构Action代理基类
    /// </summary>
    public abstract class BaseAction : GameAction
    {
        protected BaseAction(int actionId)
            : base(actionId)
        {
        }

        protected override void SetActionHead(NetWriter writer)
        {
            RequestHeader headPack = new RequestHeader()
            {
                MsgId = Head.MsgId,
                ActionId = ActionId,
                SessionId = Head.SessionId,
                UserId = Head.UserId
            };
            byte[] data = ProtoBufUtils.Serialize(headPack);
            writer.SetHeadBuffer(data);
            writer.SetBodyData(null);
        }
    }
}
