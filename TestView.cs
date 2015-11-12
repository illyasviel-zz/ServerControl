using Assets.Communication;
using Assets.Script;
using Assets.Script.Action;
using Assets.Script.Model;
using Assets.Script.Model.DataModel;
using UnityEngine;

namespace Assets
{
    public class TestView : MonoBehaviour
    {
        private int _myId = -1;
        private string _userName = "";
        private string _password = "";

        private string _fieldName = "";
        private string _key = "";
        private string _userId = "";
        private string _areaId = "";
        private string _enemyId = "";
        private string _soldierId = "";

        private int _selected = 0;

        private System.Random _rand = new System.Random();

        private string _curUserName = "(not logged in)";

        void Start()
        {
            //Comm.ConnectHost("127.0.0.1:9001");
            Comm.ConnectHost("50.116.62.140:9001");
            Comm.Instance.ReSyncCallback = null;
            Comm.Instance.ReSyncCallback += ReSyncCallback;
        }

        void OnGUI()
        {
            LoginGUI();
            DatabaseGUI();
        }

        private void DatabaseGUI()
        {
            int x1 = 260, x2 = 340, x3 = 20;
            GUI.Label(new Rect(x1, 10, 100, 22), "Field Name: ");
            GUI.Label(new Rect(x1, 40, 100, 22), "Primary Key: ");
            GUI.Label(new Rect(x1, 70, 100, 22), "User Id: ");
            GUI.Label(new Rect(x1, 100, 100, 22), "Area Id: ");
            GUI.Label(new Rect(x1, 130, 100, 22), "Enemy Id: ");
            GUI.Label(new Rect(x1, 160, 100, 22), "Soldier Id: ");

            _fieldName = GUI.TextField(new Rect(x2, 10, 100, 22), _fieldName);
            _key = GUI.TextField(new Rect(x2, 40, 100, 22), _key);
            _userId = GUI.TextField(new Rect(x2, 70, 100, 22), _userId);
            _areaId = GUI.TextField(new Rect(x2, 100, 100, 22), _areaId);
            _enemyId = GUI.TextField(new Rect(x2, 130, 100, 22), _enemyId);
            _soldierId = GUI.TextField(new Rect(x2, 160, 100, 22), _soldierId);

            _selected = GUI.SelectionGrid(new Rect(30, 190, 450, 22), _selected,
                new[] { "SoldierForUser", "EnemyForUser", "BuildingForUser", "AreaForUser" }, 4, "toggle");


            if (GUI.Button(new Rect(x3, 220, 70, 22), "Add"))
                Add();
            if (GUI.Button(new Rect(x3 + 80, 220, 70, 22), "Delete"))
                Delete();
            if (GUI.Button(new Rect(x3 + 160, 220, 70, 22), "Modify"))
                Modify();
            if (GUI.Button(new Rect(x3 + 280, 220, 70, 22), "ReSync"))
                ReSync();

            if (GUI.Button(new Rect(x3, 250, 100, 22), "Find By Key"))
                FindByKey();
            if (GUI.Button(new Rect(x3 + 110, 250, 100, 22), "Find By UserId"))
                FindByUserId();
            if (GUI.Button(new Rect(x3 + 220, 250, 100, 22), "Find By Field"))
                FindByFieldName();
        }

        private void Add()
        {
            int key = 0, userId = 0, soldierId = 0, areaId = 0, enemyId = 0;
            int.TryParse(_key, out key);
            int.TryParse(_userId, out userId);
            int.TryParse(_soldierId, out soldierId);
            int.TryParse(_areaId, out areaId);
            int.TryParse(_enemyId, out enemyId);

            switch (_selected)
            {
                case 0: // SoldierForUser
                    SoldierForUser s = SoldierForUser.CreateRandom(_rand);
                    s.UserId = userId;
                    s.SoldierId = soldierId;
                    Comm.Add(s, AddCallback);
                    break;
                case 1: // EnemyForUser
                    EnemyForUser e = EnemyForUser.CreateRandom(_rand);
                    e.UserId = userId;
                    e.AreaId = areaId;
                    e.EnemyId = enemyId;
                    Comm.Add(e, AddCallback);
                    break;
                case 2: // BuildingForUser
                    BuildingForUser b = BuildingForUser.CreateRandom(_rand);
                    b.UserId = userId;
                    Comm.Add(b, AddCallback);
                    break;
                case 3: // AreaForUser
                    AreaForUser a = AreaForUser.CreateRandom(_rand);
                    a.UserId = userId;
                    a.AreaId = areaId;
                    a.EnemyId = enemyId;
                    Comm.Add(a, AddCallback);
                    break;
            }
        }

        private void AddCallback(ShareEntityProto obj)
        {
            if (obj == null)
                Debug.Log("添加失败");
            else
            {
                Debug.Log("添加成功： " + obj);
                // obj指向Comm.add的第一个参数
                // 添加操作会更改Comm.add第一个参数的主键值
                // 更改的主键值是由服务器决定的
            }
        }

        private void Delete()
        {
            switch (_selected)
            {
                case 0: // SoldierForUser
                    Comm.Delete<SoldierForUser>(int.Parse(_key), DeleteCallback);
                    break;
                case 1: // EnemyForUser
                    Comm.Delete<EnemyForUser>(int.Parse(_key), DeleteCallback);
                    break;
                case 2: // BuildingForUser
                    Comm.Delete<BuildingForUser>(int.Parse(_key), DeleteCallback);
                    break;
                case 3: // AreaForUser
                    Comm.Delete<AreaForUser>(int.Parse(_key), DeleteCallback);
                    break;
            }
        }

        private void DeleteCallback(bool result)
        {
            if (result)
                Debug.Log("删除成功");
            else
                Debug.Log("删除失败 - 不存在该主键的对象");
        }

        private void Modify()
        {
            switch (_selected)
            {
                case 0: // SoldierForUser
                    SoldierForUser s = SoldierForUser.CreateRandom(_rand);
                    s.UserId = int.Parse(_userId);
                    s.SoldierId = int.Parse(_soldierId);
                    Comm.Modify(s, ModifyCallback);
                    break;
                case 1: // EnemyForUser
                    EnemyForUser e = EnemyForUser.CreateRandom(_rand);
                    e.UserId = int.Parse(_userId);
                    e.AreaId = int.Parse(_areaId);
                    e.EnemyId = int.Parse(_enemyId);
                    Comm.Modify(e, ModifyCallback);
                    break;
                case 2: // BuildingForUser
                    BuildingForUser b = BuildingForUser.CreateRandom(_rand);
                    b.UserId = int.Parse(_userId);
                    Comm.Modify(b, ModifyCallback);
                    break;
                case 3: // AreaForUser
                    AreaForUser a = AreaForUser.CreateRandom(_rand);
                    a.UserId = int.Parse(_userId);
                    a.AreaId = int.Parse(_areaId);
                    a.EnemyId = int.Parse(_enemyId);
                    Comm.Modify(a, ModifyCallback);
                    break;
            }
        }

        private void ModifyCallback(bool result)
        {
            if (result)
                Debug.Log("修改成功");
            else
                Debug.Log("修改失败 - 不存在该主键的对象");
        }

        private void FindByKey()
        {
            switch (_selected)
            {
                case 0: // SoldierForUser
                    Comm.FindByKey<SoldierForUser>(int.Parse(_key), FindCallback);
                    break;
                case 1: // EnemyForUser
                    Comm.FindByKey<EnemyForUser>(int.Parse(_key), FindCallback);
                    break;
                case 2: // BuildingForUser
                    Comm.FindByKey<BuildingForUser>(int.Parse(_key), FindCallback);
                    break;
                case 3: // AreaForUser
                    Comm.FindByKey<AreaForUser>(int.Parse(_key), FindCallback);
                    break;
            }
        }

        private void FindByUserId()
        {
            switch (_selected)
            {
                case 0: // SoldierForUser
                    Comm.FindByUserId<SoldierForUser>(int.Parse(_key), FindCallback);
                    break;
                case 1: // EnemyForUser
                    Comm.FindByUserId<EnemyForUser>(int.Parse(_key), FindCallback);
                    break;
                case 2: // BuildingForUser
                    Comm.FindByUserId<BuildingForUser>(int.Parse(_key), FindCallback);
                    break;
                case 3: // AreaForUser
                    Comm.FindByUserId<AreaForUser>(int.Parse(_key), FindCallback);
                    break;
            }
        }

        private void FindByFieldName()
        {
            switch (_selected)
            {
                case 0: // SoldierForUser
                    Comm.FindByFieldName<SoldierForUser>(_fieldName, _key, FindCallback);
                    break;
                case 1: // EnemyForUser
                    Comm.FindByFieldName<EnemyForUser>(_fieldName, _key, FindCallback);
                    break;
                case 2: // BuildingForUser
                    Comm.FindByFieldName<BuildingForUser>(_fieldName, _key, FindCallback);
                    break;
                case 3: // AreaForUser
                    Comm.FindByFieldName<AreaForUser>(_fieldName, _key, FindCallback);
                    break;
            }
        }

        private void FindCallback(ShareEntityProto obj)
        {
            if (obj == null)
                Debug.Log("没有找到");
            else
                Debug.Log("找到： " + obj);
        }

        private void ReSync()
        {
            
            Comm.ReSync();
        }

        private void ReSyncCallback(ShareEntityProto obj)
        {
            if (obj.GetType() == typeof (UserCharacterInfo))
            {
                if (obj.Key != _myId)
                    Debug.Log("<Enemy> : " + obj);
                else
                    Debug.Log("<Myself> : " + obj);
            }
            else
                Debug.Log(obj);
        }

        private void LoginGUI()
        {
            GUI.Label(new Rect(10, 10, 100, 22), "User Name:");
            GUI.Label(new Rect(10, 40, 100, 22), "Password:");
            _userName = GUI.TextField(new Rect(120, 10, 120, 22), _userName);
            _password = GUI.TextField(new Rect(120, 40, 120, 22), _password);
            if (GUI.Button(new Rect(10, 70, 80, 22), "Register"))
                Comm.Register(_userName, _password, RegisterCallback);
            if (GUI.Button(new Rect(100, 70, 80, 22), "Login"))
                Comm.Login(_userName, _password, LoginCallback);
            GUI.Label(new Rect(10, 100, 100, 22), "Current UserId is   : ");
            GUI.Label(new Rect(120, 100, 120, 22), _myId.ToString());
            GUI.Label(new Rect(10, 130, 100, 22), "Current logged in as: ");
            GUI.Label(new Rect(120, 130, 120, 22), _curUserName);
        }

        private void RegisterCallback(int userId)
        {
            if (userId > 0)
                Debug.Log("注册成功");
            else
                Debug.Log("注册失败");
        }

        private void LoginCallback(int userId)
        {
            if (userId > 0)
            {
                Debug.Log("登陆成功");
                _curUserName = _userName;
                _myId = userId;
            }
            else
                Debug.Log("登陆失败");
        }
    }
}