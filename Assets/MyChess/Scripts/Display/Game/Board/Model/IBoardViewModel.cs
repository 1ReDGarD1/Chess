using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Display.Foundation.Model;
using MyChess.Scripts.Display.Game.Board.Cell;

namespace MyChess.Scripts.Display.Game.Board.Model
{
    public interface IBoardViewModel : IViewModel<IBoardCell, IBoardCellView>
    {
    }
}