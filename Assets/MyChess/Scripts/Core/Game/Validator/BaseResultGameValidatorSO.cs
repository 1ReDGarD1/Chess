using UnityEngine;

namespace MyChess.Scripts.Core.Game.Validator
{
    public abstract class BaseResultGameValidatorSO : ScriptableObject, IResultGameValidator
    {
        #region IResultGameValidator

        public abstract bool ValidateResult();

        #endregion
    }
}