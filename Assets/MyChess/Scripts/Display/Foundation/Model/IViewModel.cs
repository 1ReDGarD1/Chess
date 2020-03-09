using System.Collections.Generic;

namespace MyChess.Scripts.Display.Foundation.Model
{
    public interface IViewModel<TEntity, TEntityView>
    {
        #region IViewModel

        IDictionary<TEntity, TEntityView> ViewsByEntity { get; }

        void AddView(TEntity entity, TEntityView entityView);
        void RemoveView(TEntity entity);

        TEntityView GetView(TEntity entity);

        void Clear();

        #endregion
    }
}