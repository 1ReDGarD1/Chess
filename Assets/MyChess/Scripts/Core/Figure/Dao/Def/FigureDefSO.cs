using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.MoveTurnRules;
using MyChess.Scripts.Core.Figure.PostTurnLogic;
using MyChess.Scripts.Utility.Common;
using MyChess.Scripts.Utility.Dao.Def;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace MyChess.Scripts.Core.Figure.Dao.Def
{
    [CreateAssetMenu(menuName = "MyChess/Figure Def")]
    public sealed class FigureDefSO : BaseDefSO, IFigureDef
    {
        #region FigureDefSO

        [SerializeField]
        private GameObject _whitePrefab;

        [SerializeField]
        private GameObject _blackPrefab;

        [SerializeField]
        private int _prefabInitialSize;

        [SerializeField]
        private BaseFigureMoveTurnRulesSO[] _figureMoveTurnRules;

        [SerializeField]
        private BaseFigurePostTurnLogicSO[] _figurePostTurnLogics;

        [Inject]
        private void Construct()
        {
            _whitePrefab.CheckNull();
            _blackPrefab.CheckNull();
            Assert.IsTrue(_prefabInitialSize > 0);
            _figureMoveTurnRules.CheckNull();
        }

        #endregion

        #region IFigureDef

        public GameObject WhitePrefab => _whitePrefab;
        public GameObject BlackPrefab => _blackPrefab;

        public int PrefabInitialSize => _prefabInitialSize;

        public IEnumerable<IFigureMoveTurnRules> FigureMoveTurnRules => _figureMoveTurnRules;
        public IEnumerable<IFigurePostTurnLogic> FigurePostTurnLogics => _figurePostTurnLogics;

        #endregion
    }
}