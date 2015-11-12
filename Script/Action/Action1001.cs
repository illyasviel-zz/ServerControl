namespace Assets.Script.Action
{
    public class Action1001 : BaseAction//GameAction
    {
        //private MessagePack _responseData;

        public Action1001()
            : base(1001)
        {
            throw new System.NotImplementedException();
            //Debug.Log("Action1001()");
            Callback += myCallback;
        }

        private void myCallback(object obj)
        {
            //var gui = UnityEngine.Object.FindObjectOfType(typeof(TestGUI)) as TestGUI;
            //if (gui == null)
            //{
            //    Debug.LogError("myCallback() did not find TestGUI");
            //    return;
            //}
            //if (obj.GetType() == typeof(MessagePack))
            //    gui.AddReceivedMessage(obj as MessagePack);
            //else
            //    Debug.LogError("myCallback() received parameter of type: " + obj.GetType());
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
            //自定对象参数格式
            //Request1001Pack requestPack = new Request1001Pack()
            //{
            //    PageIndex = 1,
            //    PageSize = 10
            //};
            //byte[] data = ProtoBufUtils.Serialize(requestPack);
            //writer.SetBodyData(data);
            //Debug.Log("Action1001: SendParameter() DONE!");
        }

        protected override void DecodePackage(NetReader reader)
        {
            //Debug.Log("Action1001: DecodePackage()");
            if (reader.StatusCode == 0)
            {
                //自定对象格式解包
                //_responseData = ProtoBufUtils.Deserialize<MessagePack>(reader.Buffer);
            }
        }

        public override ActionResult GetResponseData()
        {
            //Debug.Log("Action1001: GetResonseData() start");
            //if (_responseData != null)
            //{
            //    UnityEngine.Debug.Log(string.Format("The action{0} receive ok, record count:{1}", ActionId, _responseData.Items == null ? 0 : _responseData.Items.Count));
            //}
            //Debug.Log("Action1001.GetResponseData()");
            //return _responseData;
            return null;
        }
    }
}
