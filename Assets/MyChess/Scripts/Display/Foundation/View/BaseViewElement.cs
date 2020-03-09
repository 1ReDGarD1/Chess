using UnityEngine;

namespace MyChess.Scripts.Display.Foundation.View
{
    public abstract class BaseViewElement : MonoBehaviour, IViewElement
    {
        #region IViewElement

        public bool IsVisible => gameObject.activeSelf;

        public virtual void Show()
        {
            if (IsVisible)
            {
                return;
            }

            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            if (!IsVisible)
            {
                return;
            }

            gameObject.SetActive(false);
        }

        #endregion
    }
}