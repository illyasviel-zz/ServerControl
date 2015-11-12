
namespace Assets.Script.Action
{
    /// <summary>
    /// 客户端从服务器请求所有相关信息
    /// </summary>
    public class Action4000 : BaseAction
    {
        public Action4000()
            : base(4000)
        {
        }

        protected override void SendParameter(NetWriter writer, ActionParam userData)
        {
        }

        protected override void DecodePackage(NetReader reader)
        {
            return;
        }

        public override ActionResult GetResponseData()
        {
            return null;
        }
    }
}