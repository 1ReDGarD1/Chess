using System;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.Assertions;

namespace MyChess.Scripts.Display.Game.Board.Cell
{
    [DisallowMultipleComponent]
    public sealed class BoardCellView : MonoBehaviour, IBoardCellView
    {
        #region BoardCellView

        [SerializeField]
        private BoardCellCol _col;

        [SerializeField]
        private BoardCellRow _row;

        [SerializeField]
        private Collider _collider;

        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private Material _materialFocus;

        [SerializeField]
        private Material _materialAvailable;

        private Camera _camera;

        private IBoardCell _cell;

        private void Awake()
        {
            Assert.IsFalse(_col == BoardCellCol.None);
            Assert.IsFalse(_row == BoardCellRow.None);

            _collider.CheckNull();
            _meshRenderer.CheckNull();
            _materialFocus.CheckNull();
            _materialAvailable.CheckNull();

            _camera = Camera.main.CheckNull();
        }

        private void OnDestroy()
        {
            OnClick = null;
        }

        public override string ToString() => $"BoardCellView {_col}, {_row}, cell:{Cell}";
        
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!_collider.Raycast(ray, out _, 100))
            {
                return;
            }

            OnClick?.Invoke(this, Cell);
        }

        private void OnChangeStatusHandler(object sender, BoardCellStatus status)
        {
            Material material = null;
            _meshRenderer.enabled = status != BoardCellStatus.Empty;
            switch (status)
            {
                case BoardCellStatus.HasFocusFigure:
                    material = _materialFocus;
                    break;
                case BoardCellStatus.AvailableForMove:
                    material = _materialAvailable;
                    break;
            }

            _meshRenderer.material = material;
        }

        #endregion

        #region IBoardCellView

        public event EventHandler<IBoardCell> OnClick;

        public IBoardCell Cell
        {
            private get => _cell;
            set
            {
                if (_cell != null)
                {
                    _cell.OnChangeStatus -= OnChangeStatusHandler;
                }

                _cell = value;
                _cell.OnChangeStatus += OnChangeStatusHandler;
                OnChangeStatusHandler(this, _cell.Status);
            }
        }

        public Vector3 Position => transform.position;

        public bool Equals(IBoardCell cell) => cell.Equals(_col, _row);

        #endregion
    }
}