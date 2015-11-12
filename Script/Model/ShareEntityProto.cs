using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Assets.Script.Model.DataModel;
using ProtoBuf;

namespace Assets.Script.Model
{
    [ProtoContract]
    [ProtoInclude(200, typeof(AreaForUser))]
    [ProtoInclude(201, typeof(Battle))]
    [ProtoInclude(202, typeof(BuildingList))]
    [ProtoInclude(203, typeof(BuildingForUser))]
    [ProtoInclude(204, typeof(EnemyForUser))]
    [ProtoInclude(205, typeof(SoldierList))]
    [ProtoInclude(206, typeof(SoldierForUser))]
    [ProtoInclude(207, typeof(UserCharacterInfo))]
    [ProtoInclude(208, typeof(UserAccount))]
    public abstract class ShareEntityProto
    {
        public abstract int Key { get; set; }
        public abstract String TypeName { get; }

        public virtual DateTime CreateTimeStamp
        {
            get { return DateTime.MinValue; }
            set { }
        }
        public virtual DateTime UpdateTimeStamp
        {
            get { return DateTime.MinValue; }
            set { }
        }

        private static readonly Hashtable DbTypeLookup = new Hashtable();
        private static readonly string NameSpacePrefix = typeof(UserAccount).Namespace + "."; // "GameServer.Model.DataModel.";
        private static readonly string AssemblyPostfix = "," + System.Reflection.Assembly.GetAssembly(typeof(UserAccount)).FullName;

        public static Type GetTypeByName(String typeName)
        {
            Type dataType;
            try
            {
                lock (DbTypeLookup)
                {
                    dataType = (Type)DbTypeLookup[typeName];
                    if (dataType == null)
                    {
                        dataType = Type.GetType(NameSpacePrefix + typeName + AssemblyPostfix);
                        DbTypeLookup[typeName] = dataType;
                    }
                }
                return dataType;
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogException(e);
                return null;
            }
        }
    }
}