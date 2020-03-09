using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Game.Dao.Def;
using UnityEngine;

namespace MyChess.Scripts.Composition.Configs
{
    [CreateAssetMenu(menuName = "MyChess/Main Config")]
    public sealed class MainConfig : ScriptableObject
    {
        #region MainConfig

        [SerializeField]
        private FigureDefSO[] _figureDefs;

        [SerializeField]
        private GameDefSO[] _gameDefs;

        public ICollection<IFigureDef> FigureDefs => _figureDefs;
        public ICollection<IGameDef> GameDefs => _gameDefs;

        #endregion
    }
}