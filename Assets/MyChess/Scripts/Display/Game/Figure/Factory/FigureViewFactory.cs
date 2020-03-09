using System.Collections.Generic;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Display.Game.Figure.Factory.Pool;
using MyChess.Scripts.Display.Game.Figure.View;
using UnityEngine;

namespace MyChess.Scripts.Display.Game.Figure.Factory
{
    public sealed class FigureViewFactory : IFigureViewFactory
    {
        #region FigureViewFactory

        private readonly IDictionary<IFigureDef, IFigureViewPool> StorageWhiteFigureViewPools =
            new Dictionary<IFigureDef, IFigureViewPool>();

        private readonly IDictionary<IFigureDef, IFigureViewPool> StorageBlackFigureViewPools =
            new Dictionary<IFigureDef, IFigureViewPool>();

        private void RegisterFigureView(IFigureDef figureDef, IFigureViewPool figureViewPool,
            IDictionary<IFigureDef, IFigureViewPool> storagePools)
        {
            if (storagePools.ContainsKey(figureDef))
            {
                Debug.LogError($"Attempt to re-register figureDef:{figureDef}, figureViewPool:{figureViewPool}");
                return;
            }

            if (figureViewPool == null)
            {
                Debug.LogError("Attempt to add null figureViewPool");
                return;
            }

            storagePools.Add(figureDef, figureViewPool);
        }

        private IFigureViewPool GetPool(IFigureEntity entity)
        {
            var def = entity.Def;

            var storagePools = GetStorageFigureViewPools(entity.Team);
            storagePools.TryGetValue(def, out var pool);

            if (pool == null)
            {
                Debug.LogError($"Can't find pool for figureDef:{def}");
                return default;
            }

            return pool;
        }

        private IDictionary<IFigureDef, IFigureViewPool> GetStorageFigureViewPools(GameTeam team)
        {
            return team == GameTeam.White ? StorageWhiteFigureViewPools : StorageBlackFigureViewPools;
        }

        #endregion

        #region IFigureViewFactory

        public void RegisterFigureViewPool(IFigureDef figureDef, GameTeam team, IFigureViewPool figureViewPool)
        {
            var storagePool = GetStorageFigureViewPools(team);
            RegisterFigureView(figureDef, figureViewPool, storagePool);
        }

        public IFigureView Spawn(IFigureEntity figure)
        {
            var figureView = GetPool(figure).Spawn(figure);
            return figureView;
        }

        public void Despawn(IFigureView figureView)
        {
            GetPool(figureView.Entity).Despawn(figureView);
        }

        #endregion
    }
}