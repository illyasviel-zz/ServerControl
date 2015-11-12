using System;
using System.Collections.Generic;
using Assets.Script.Model;
using ProtoBuf;

namespace Assets.Script.Com.Messages
{
    [ProtoContract]
    public class DictMessage
    {
        [ProtoMember(1)]
        private Dictionary<string, string> _param;
        [ProtoMember(2)]
        private Dictionary<string, ShareEntityProto> _objs;

        public DictMessage()
        {
            _param = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            _objs = new Dictionary<string, ShareEntityProto>(StringComparer.CurrentCultureIgnoreCase);
        }

        //public KeyValuePair<string, string>[] ToArray()
        //{
        //    return _param != null ? _param.ToArray() : new KeyValuePair<string, string>[0];
        //}

        public void Foreach(Func<string, string, bool> func)
        {
            if (_param == null) return;
            foreach (KeyValuePair<string, string> pair in _param)
            {
                if (!func(pair.Key, pair.Value))
                {
                    break;
                }
            }
        }

        //public T Get<T>(string name)
        //{
        //    return (T)this[name];
        //}

        /// <summary>
        /// Find param
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name]
        {
            get
            {
                if (_param.ContainsKey(name))
                    return _param[name];
                if (_objs.ContainsKey(name))
                    return _objs[name];
                return null;
            }
            set
            {
                if (value.GetType().IsSubclassOf(typeof(ShareEntityProto)))
                {
                    _param.Remove(name);
                    _objs[name] = value as ShareEntityProto;
                }
                else
                {
                    _objs.Remove(name);
                    _param[name] = value.ToString();
                }
            }
        }
    }
}