using System.Collections.Generic;
using MyChess.Scripts.Utility.Dao.Repository;

namespace MyChess.Scripts.Display.Foundation.Screen.Repository
{
    public sealed class UiScreenRepository : DefRepository<IUiScreen, UiScreenKind>, IUiScreenRepository
    {
        #region UiScreenRepository

        public UiScreenRepository(IEnumerable<IUiScreen> defs) : base(defs)
        {
        }

        protected override void AddDef(IUiScreen def)
        {
            base.AddDef(def);

            def.Hide();
        }

        #endregion
    }
}