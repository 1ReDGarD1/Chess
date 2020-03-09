using System.Collections.Generic;
using System.Text;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Core.Game.Observer.Configurator;

namespace MyChess.Scripts.Core.Game.Model
{
    public sealed class GameModel : IGameModel, IGameComponentInitializable, IGameComponentCompleted
    {
        #region GameModel

        private readonly Dictionary<GameTeam, IGameControl> ControlsByTeam = new Dictionary<GameTeam, IGameControl>();

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("GameModel");
            stringBuilder.AppendLine($"gameDef:{GameDef}");
            stringBuilder.AppendLine($"curTeamTurn:{CurTeamTurn}");
            foreach (var controlByTeam in ControlsByTeam)
            {
                var team = controlByTeam.Key;
                var controlKind = controlByTeam.Value.Id;
                stringBuilder.Append($"team:{team}, control:{controlKind}; ");
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region IGameModel

        public IGameDef GameDef { get; private set; }
        public GameTeam CurTeamTurn { get; set; }

        public IGameControl GetControl(GameTeam team)
        {
            ControlsByTeam.TryGetValue(team, out var control);
            return control;
        }

        #endregion

        #region IGameComponentInitializable

        public void GameInitialize(IGameConfigurator configurator)
        {
            GameDef = configurator.GameDef;
            CurTeamTurn = GameTeam.White;

            foreach (var controlByTeam in configurator.ControlsByTeam)
            {
                var team = controlByTeam.Key;
                var control = controlByTeam.Value;
                
                ControlsByTeam.Add(team, control);
            }
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            ControlsByTeam.Clear();
            GameDef = null;
        }

        #endregion
    }
}