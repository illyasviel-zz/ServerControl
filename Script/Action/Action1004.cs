using System;
using Assets.Script.Com.Messages;
using UnityEngine;
using ZyGames.Framework.Common.Serialization;

namespace Assets.Script.Action
{
    /// <summary>
    /// Login
    /// </summary>
    public class Action1004 : BaseAction
    {
        private LoginMessage _msg;
        
        /// <summary>
        /// Login Action
        /// </summary>
        public Action1004()
            : base(1004)
        {
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
            byte[] data = ProtoBufUtils.Serialize(userData.GetValue<LoginMessage>());
            writer.SetBodyData(data);
        }

        protected override void DecodePackage(NetReader reader)
        {
            if (reader.StatusCode == 0)
            {
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
