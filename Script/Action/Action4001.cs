using Assets.Communication;
using Assets.Script.Model;
using UnityEngine;
using ZyGames.Framework.Common.Serialization;
using Object = System.Object;

namespace Assets.Script.Action
{
    /// <summary>
    /// 客户端从服务器请求所有相关信息
    /// 该Action仅用来获取服务器推送
    /// </summary>
    public class Action4001 : BaseAction
    {
        private ShareEntityProto _obj;

        public Action4001()
            : base(4001)
        {
            Callback += delegate(ActionResult ar)
            {
                Comm.Instance.ReSyncCallback(ar.GetValue<Object>() as ShareEntityProto);
            };
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
        }

        protected override void DecodePackage(NetReader reader)
        {
            if (reader.StatusCode == 0)
            {
                _obj = ProtoBufUtils.Deserialize<ShareEntityProto>(reader.Buffer);
            }
            else
            {
                UnityEngine.Debug.LogError(this.GetType() + ".DecodePackage(): reader.StatusCode = " + reader.StatusCode);
            }
        }

        public override ActionResult GetResponseData()
        {
            return new ActionResult(_obj);
        }
    }
}