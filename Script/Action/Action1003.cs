using System;
using Assets.Script.Com.Messages;
using UnityEngine;
using ZyGames.Framework.Common.Serialization;

namespace Assets.Script.Action
{
    public class Action1003 : BaseAction
    {
        private LoginMessage _msg;
        
        /// <summary>
        /// Register new user
        /// </summary>
        public Action1003()
            : base(1003)
        {
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
            LoginMessage registerMessage = userData.GetValue<LoginMessage>();
            byte[] data = ProtoBufUtils.Serialize(registerMessage);
            writer.SetBodyData(data);
        }

        protected override void DecodePackage(NetReader reader)
        {
            if (reader.StatusCode == 0)
            {
                //自定对象格式解包
                _msg = ProtoBufUtils.Deserialize<LoginMessage>(reader.Buffer);
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
