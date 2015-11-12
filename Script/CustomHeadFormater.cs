using System;
using Assets.Script.Com.Messages;
using UnityEngine;
using ZyGames.Framework.Common.Serialization;

namespace Assets.Script
{
    /// <summary>
    /// 定制的头部结构解析
    /// </summary>
    public class CustomHeadFormater : IHeadFormater
    {
        public bool TryParse(byte[] data, out PackageHead head, out byte[] bodyBytes)
        {
            bodyBytes = null;
            head = null;
            int pos = 0;
            if (data == null || data.Length == 0)
            {
                return false;
            }
            int headSize = GetInt(data, ref pos);
            byte[] headBytes = new byte[headSize];
            Buffer.BlockCopy(data, pos, headBytes, 0, headBytes.Length);
            pos += headSize;
            ResponseHeader resPack = ProtoBufUtils.Deserialize<ResponseHeader>(headBytes);

            head = new PackageHead();
            head.StatusCode = resPack.ErrorCode;
            head.MsgId = resPack.MsgId;
            head.Description = resPack.ErrorInfo;
            head.ActionId = resPack.ActionId;
            head.StrTime = resPack.St;

            int bodyLen = data.Length - pos;
            if (bodyLen > 0)
            {
                bodyBytes = new byte[bodyLen];
                Buffer.BlockCopy(data, pos, bodyBytes, 0, bodyLen);
            }
            else
            {
                bodyBytes = new byte[0];
            }

            //UnityEngine.Debug.Log(string.Format("ActionId:{0}, ErrorCode:{1}, len:{2}", resPack.ActionId, resPack.ErrorCode, bodyBytes.Length));

            return true;
        }

        public bool TryParse(string data, NetworkType type, out PackageHead head, out object body)
        {
            throw new System.NotImplementedException();
        }

        public byte[] BuildHearbeatPackage()
        {
            Debug.Log("Built Heartbeat Package");
            RequestHeader headPack = new RequestHeader()
            {
                MsgId = NetWriter.MsgId,
                ActionId = 1, // 心跳1，断开连接2。参见ZyGames.Framework.Game.Contract.ActionEnum
                SessionId = NetWriter.SessionID,
                UserId = (int)NetWriter.UserID
            };
            NetWriter.Instance.SetHeadBuffer(ProtoBufUtils.Serialize(headPack));
            NetWriter.Instance.SetBodyData(null);
            byte[] data = NetWriter.Instance.PostData();
            NetWriter.resetData();
            return data;
        }

        private int GetInt(byte[] data, ref int pos)
        {
            int val = BitConverter.ToInt32(data, pos);
            pos += sizeof(int);
            return val;
        }
    }
}
