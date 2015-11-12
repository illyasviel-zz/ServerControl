using UnityEngine;

namespace Assets.Script.Action
{
    /// <summary>
    /// Test ONLY!!!
    /// </summary>
    public class Action1000 : BaseAction
    {
        public Action1000()
            : base(1000)
        {
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
            //byte[] data = new byte[0];
            //writer.SetBodyData(data);
        }

        protected override void DecodePackage(NetReader reader)
        {
            //Debug.Log("Action1000: DecodePackage()");
            if (reader.StatusCode == 0)
            {
                //自定对象格式解包
                //_responseData = ProtoBufUtils.Deserialize<MessagePack>(reader.Buffer);
            }
            else
            {
                Debug.LogError(this.GetType() + ".DecodePackage(): reader.StatusCode = " + reader.StatusCode);
            }
        }

        public override ActionResult GetResponseData()
        {
            return null;
        }
    
    }
}
