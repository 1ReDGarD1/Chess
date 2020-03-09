using MyChess.Scripts.Core.Board.Creator;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Figure.Controller;
using MyChess.Scripts.Core.Figure.Creator;
using MyChess.Scripts.Core.Game.Dao.Def;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Core.Game.Observer.Configurator;
using MyChess.Scripts.Utility.Common;
using UnityEngine;

namespace MyChess.Scripts.Core.Board
{
    public sealed class BoardPreparation : IGameComponentInitializable
    {
        #region BoardPreparation

        private readonly IBoardCreator BoardCreator;
        private readonly IFigureCreator FigureCreator;
        private readonly IBoardModel BoardModel;
        private readonly IFigureController FigureController;

        public BoardPreparation(IBoardCreator boardCreator,
            IFigureCreator figureCreator,
            IBoardModel boardModel,
            IFigureController figureController)
        {
            BoardCreator = boardCreator.CheckNull();
            FigureCreator = figureCreator.CheckNull();
            BoardModel = boardModel.CheckNull();
            FigureController = figureController.CheckNull();
        }

        private void ArrangementFigures(IGameDef gameDef)
        {
            foreach (var startInfoFigureDef in gameDef.StartInfoFigureDefs)
            {
                var figureDef = startInfoFigureDef.Def;
                var team = startInfoFigureDef.Team;
                var figureEntity = FigureCreator.Create(figureDef, team);
                
                var cell = BoardModel.GetCell(startInfoFigureDef.StartCol, startInfoFigureDef.StartRow);
                FigureController.MoveFigure(figureEntity, cell);
            }
        }

        #endregion

        #region IGameComponentInitializable

        public void GameInitialize(IGameConfigurator configurator)
        {
            BoardCreator.CreateCells(BoardModel);
            ArrangementFigures(configurator.GameDef);

            Debug.LogWarning($"Launch game:{configurator.GameDef}");
        }

        #endregion
    }
}