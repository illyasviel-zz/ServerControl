using System;
using Assets.Script.Action;
using Assets.Script.Com.Messages;
using Assets.Script.Model;
using UnityEngine;
using Assets.Extension;
using Assets.Script;
using Assets.Script.Model.DataModel;

namespace Assets.Communication
{
    public sealed class Comm : MonoBehaviour
    {
        public Action<ShareEntityProto> ReSyncCallback;
        public Action<Type, int> DeleteCallback;

        private Comm()
        {
        }

        /// <summary>
        /// 设置服务器地址。
        /// 格式为："127.0.0.1:9001"
        /// 前面不要加 "http" 字段，后面必须有端口号
        /// </summary>
        /// <param name="url"></param>
        public static void ConnectHost(String url)
        {
            // TODO: what happens if the client changes to another server?
            NetWriter.SetUrl(url);
            Net.Instance.HeadFormater = new CustomHeadFormater();
        }

        /// <summary>
        /// 注册新用户。
        /// 新用户不能和已存在的用户重名。
        /// 
        /// 此方法可以在任何时候调用：以登陆时，未登录时
        /// 此方法不会自动登录，必须调用Login登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="callback"></param>
        public static void Register(String userName, String password, Action<int> callback)
        {
            callback.ThrowIfNull("callback");
            //callback.th

            LoginMessage msg = new LoginMessage()
            {
                UserName = userName.ThrowIfNull("userName"),
                Password = password.ThrowIfNull("password")
            };
            ActionParam param = new ActionParam(msg);
            Net.Instance.Send(ActionType.Register,
                delegate (ActionResult r)
                {
                    callback(r.GetValue<LoginMessage>().UserId);
                },
                param);
        }

        /// <summary>
        /// 用户登陆
        /// 
        /// 如果两个客户端使用同一个账号登陆，先登录的客户端会被后登陆的客户端踢出
        /// (被踢出的客户端暂时不会从服务器收到任何通知)
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="callback"></param>
        public static void Login(String userName, String password, Action<int> callback)
        {
            callback.ThrowIfNull("callback");

            LoginMessage msg = new LoginMessage()
            {
                UserName = userName.ThrowIfNull("userName"),
                Password = password.ThrowIfNull("password")
            };
            ActionParam param = new ActionParam(msg);
            Net.Instance.Send(ActionType.Login,
                delegate (ActionResult r)
                {
                    callback(r.GetValue<LoginMessage>().UserId);
                },
                param);
        }

        public static void RequestAll()
        {
            Net.Instance.Send(ActionType.Initialize, null, null);
        }

        public static void Add<T>(T obj, Action<ShareEntityProto> callback) where T : ShareEntityProto
        {
            callback.ThrowIfNull("callback");
            obj.ThrowIfNull("obj");

            if (typeof (T) == typeof (BuildingList) || typeof (T) == typeof (SoldierList))
                throw new ArgumentException("You are not allowed to modify data of this type", typeof(T).Name);

            Action<ActionResult> action = delegate (ActionResult r)
            {
                DatabaseMessage response = r.GetValue<DatabaseMessage>();
                if (response.Result == false)
                    callback(null);
                else
                {
                    obj.Key = int.Parse(response.Key);
                    callback(obj);
                }
            };

            DatabaseMessage msg = new DatabaseMessage()
            {
                OpType = DatabaseOpType.Add,
                TypeName = obj.GetType().Name,
                Obj = obj,
                //Key = obj.Key,
                Result = false
            };
            ActionParam param = new ActionParam(msg);

            Net.Instance.Send(ActionType.Database, action, param);
        }

        public static void Delete<T>(int key, Action<bool> callback) where T : ShareEntityProto
        {
            callback.ThrowIfNull("callback");

            if (typeof(T) == typeof(BuildingList) || typeof(T) == typeof(SoldierList))
                throw new ArgumentException("You are not allowed to modify data of this type", typeof(T).Name);

            Action<ActionResult> action = delegate (ActionResult r)
            {
                callback(r.GetValue<DatabaseMessage>().Result);
            };
            DatabaseMessage msg = new DatabaseMessage()
            {
                OpType = DatabaseOpType.Delete,
                TypeName = typeof(T).Name,
                Obj = null,
                Key = key.ToString(),
                Result = false
            };
            ActionParam param = new ActionParam(msg);

            Net.Instance.Send(ActionType.Database, action, param);
        }

        public static void Modify<T>(T obj, Action<bool> callback) where T : ShareEntityProto
        {
            callback.ThrowIfNull("callback");
            obj.ThrowIfNull("obj");

            if (typeof(T) == typeof(BuildingList) || typeof(T) == typeof(SoldierList))
                throw new ArgumentException("You are not allowed to modify data of this type", typeof(T).Name);

            Action<ActionResult> action = delegate (ActionResult r)
            {
                DatabaseMessage response = r.GetValue<DatabaseMessage>();
                callback(response.Result);
            };

            DatabaseMessage msg = new DatabaseMessage()
            {
                OpType = DatabaseOpType.Modify,
                TypeName = obj.GetType().Name,
                Obj = obj,
                Key = obj.Key.ToString(),
                Result = false
            };
            ActionParam param = new ActionParam(msg);

            Net.Instance.Send(ActionType.Database, action, param);
        }

        public static void FindByKey<T>(int key, Action<ShareEntityProto> callback) where T : ShareEntityProto
        {
            callback.ThrowIfNull("callback");
            FindHelper<T>(key.ToString(), callback, DatabaseOpType.FindByKey);
        }

        public static void FindByUserId<T>(int key, Action<ShareEntityProto> callback) where T : ShareEntityProto
        {
            callback.ThrowIfNull("callback");
            if (typeof(T).GetProperty("UserId") == null)
                throw new ArgumentException(String.Format("Type '{0}' does not contain field 'UserId'", typeof(T).Name));
            FindHelper<T>(key.ToString(), callback, DatabaseOpType.FindByUserId);
        }

        public static void FindByFieldName<T>(String fieldName, String key, Action<ShareEntityProto> callback)
            where T : ShareEntityProto
        {
            callback.ThrowIfNull("callback");
            if (typeof(T).GetProperty(fieldName) == null)
                throw new ArgumentException(String.Format("Type '{0}' does not contain field '{1}'", typeof(T).Name, fieldName));
            FindHelper<T>(key, callback, DatabaseOpType.FindByFieldName, fieldName);
        }

        public static void ReSync()
        {
            Net.Instance.Send(4000, ar => {}, null);
        }

        private static void FindHelper<T>(string key, Action<ShareEntityProto> callback, DatabaseOpType opType, string fieldName = null) where T : ShareEntityProto
        {
            Action<ActionResult> action = delegate (ActionResult r)
            {
                DatabaseMessage response = r.GetValue<DatabaseMessage>();
                if (response.Result == false)
                    callback(null);
                else
                    callback(response.Obj as T);
            };
            DatabaseMessage msg = new DatabaseMessage()
            {
                OpType = opType,
                TypeName = typeof(T).Name,
                Obj = null,
                Key = key,
                Result = false,
                FieldName = fieldName
            };
            ActionParam param = new ActionParam(msg);

            Net.Instance.Send(ActionType.Database, action, param);
        }

        #region Singleton Support
        private static Comm _instance;
        private static readonly object Lock = new object();

        public static Comm Instance
        {
            get
            {
                if (_applicationIsQuitting)
                {
                    Debug.LogWarning("[Conn] Instance '" +
                        "' already destroyed on application quit." +
                        " Won't create again - returning null.");
                    return null;
                }

                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = (Comm)FindObjectOfType(typeof(Comm));

                        if (FindObjectsOfType(typeof(Comm)).Length > 1)
                        {
                            Debug.LogError("[Conn] Something went really wrong " +
                                " - there should never be more than 1 Conn Instance!" +
                                " Reopening the scene might fix it.");
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<Comm>();
                            singleton.name = "Conn.Instance";

                            Init(_instance);

                            DontDestroyOnLoad(singleton);
                        }
                    }

                    return _instance;
                }
            }
        }

        private static void Init(Comm instance)
        {
            //instance._callbackWrapper = new CallbackWrapper();
            //instance.CallbackHandler = new BaseCallbackHandler();
            instance.DeleteCallback = delegate (Type t, int id)
            {
                Debug.LogError("客户端需要设置 Comm.DeleteCallback 方法");
            };
            //instance.ReSyncCallback = DefaultCallback;
            Net.Instance.HeadFormater = new CustomHeadFormater();
            //NetWriter.SetUrl("127.0.0.1");
        }

        private static void DefaultCallback<T>(T obj) where T : ShareEntityProto
        {
            Debug.Log(string.Format("Received: {0}", obj));
        }

        private static bool _applicationIsQuitting = false;
        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        ///   it will create a buggy ghost object that will stay on the Editor scene
        ///   even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        public void OnDestroy()
        {
            _applicationIsQuitting = true;
        }
        #endregion
    }
}