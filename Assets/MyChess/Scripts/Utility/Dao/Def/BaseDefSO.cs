using System;
using UnityEngine;

namespace MyChess.Scripts.Utility.Dao.Def
{
    [Serializable]
    public abstract class BaseDefSO : ScriptableObject, IBaseDef
    {
        #region BaseDefSO

        [SerializeField]
        private string _id;

        public override string ToString() => $"Id:{_id}";

        #endregion

        #region IDef

        public string Id => _id;

        #endregion

        #region IBaseDef

        public bool Equals(IDef<string> def) => def.Id.Equals(Id);

        #endregion
    }
}