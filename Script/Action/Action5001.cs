using System;
using Assets.Communication;
using Assets.Script.Com.Messages;
using Assets.Script.Model;
using UnityEngine;
using ZyGames.Framework.Common.Serialization;

namespace Assets.Script.Action
{
    public class Action5001 : BaseAction
    {
        private DatabaseMessage _msg;
        
        public Action5001()
            : base(5001)
        {
            //Callback += delegate(ActionResult ar)
            //{
            //    DatabaseMessage msg = ar.GetValue<DatabaseMessage>();
            //    Type type = ShareEntityProto.GetTypeByName(msg.TypeName);
            //    Comm.Instance.DeleteCallback(type, int.Parse(msg.Key));
            //};
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
            return;
        }

        protected override void DecodePackage(NetReader reader)
        {
            if (reader.StatusCode == 0)
            {
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
