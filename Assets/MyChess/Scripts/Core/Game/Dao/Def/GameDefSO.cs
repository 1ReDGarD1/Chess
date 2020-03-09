using System.Collections.Generic;
using System.Linq;
using MyChess.Scripts.Core.Game.Validator;
using MyChess.Scripts.Utility.Common;
using MyChess.Scripts.Utility.Dao.Def;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Core.Game.Dao.Def
{
    [CreateAssetMenu(menuName = "MyChess/Game Def")]
    public sealed class GameDefSO : BaseDefSO, IGameDef
    {
        #region GameDefSO

        [SerializeField]
        private StartInfoFigureDef[] _startInfoFigureDefs;

        [SerializeField]
        private BaseResultGameValidatorSO _resultGameValidator;

        [Inject]
        private void Construct()
        {
            _startInfoFigureDefs.CheckNull();
            _resultGameValidator.CheckNull();
        }

        #endregion

        #region IGameDef

        public IEnumerable<IStartInfoFigureDef> StartInfoFigureDefs => _startInfoFigureDefs.Cast<IStartInfoFigureDef>();

        public IResultGameValidator Validator => _resultGameValidator;

        #endregion
    }
}