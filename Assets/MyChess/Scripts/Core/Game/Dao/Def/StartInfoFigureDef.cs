using System;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;
using UnityEngine;

namespace MyChess.Scripts.Core.Game.Dao.Def
{
    [Serializable]
    public struct StartInfoFigureDef : IStartInfoFigureDef
    {
        #region StartInfoFigureDef

        [SerializeField]
        private FigureDefSO _figureDef;

        [SerializeField]
        private GameTeam _team;

        [SerializeField]
        private BoardCellCol _startCol;

        [SerializeField]
        private BoardCellRow _startRow;

        #endregion

        #region IStartInfoFigureDef

        public IFigureDef Def => _figureDef;
        public GameTeam Team => _team;

        public BoardCellCol StartCol => _startCol;
        public BoardCellRow StartRow => _startRow;

        #endregion
    }
}