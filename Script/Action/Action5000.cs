using Assets.Script.Com.Messages;
using UnityEngine;
using ZyGames.Framework.Common.Serialization;

namespace Assets.Script.Action
{
    public class Action5000 : BaseAction
    {
        private DatabaseMessage _msg;
        
        public Action5000()
            : base(5000)
        {
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
            byte[] data = ProtoBufUtils.Serialize(userData.GetValue<DatabaseMessage>());
            writer.SetBodyData(data);
        }

        protected override void DecodePackage(NetReader reader)
        {
            if (reader.StatusCode == 0)
            {
                //自定对象格式解包
                _msg = ProtoBufUtils.Deserialize<DatabaseMessage>(reader.Buffer);
            }
            else
            {
                Debug.LogError(this.GetType() + ".DecodePackage(): reader.StatusCode = " + reader.StatusCode);
            }
        }

        public override ActionResult GetResponseData()
        {
            return new ActionResult(_msg);
        }

    }
}
