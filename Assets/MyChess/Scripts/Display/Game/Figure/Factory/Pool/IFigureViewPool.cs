using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Display.Game.Figure.View;
using Zenject;

namespace MyChess.Scripts.Display.Game.Figure.Factory.Pool
{
    public interface IFigureViewPool : IMemoryPool<IFigureEntity, IFigureView>
    {
        
    }
}