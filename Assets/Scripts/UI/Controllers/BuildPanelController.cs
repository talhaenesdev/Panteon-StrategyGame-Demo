using System.Collections.Generic;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Interfaces;
using PanteonStrategyGame.UI.Views;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class BuildPanelController : MonoBehaviour
    {
        [SerializeField]
        private BuildMenuData buildMenuData;

        [SerializeField]
        private BuildPanelView view;

        [Inject]
        private SignalBus _signalBus;

        [Inject]
        private IUIFactory _uiFactory;

        private readonly List<BuildButtonView> _buttons = new();

        private void Start()
        {
            BuildButtons();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (view.gameObject.activeSelf)
                    view.Hide();
                else
                    view.Show();
            }
        }

        private void BuildButtons()
        {
            ClearButtons();

            foreach (BuildingData building in buildMenuData.Buildings)
            {
                BuildButtonView button =
                    _uiFactory.CreateBuildButton(
                        view.ButtonContainer);

                button.Initialize(
                    building.DisplayName,
                    building.Icon,
                    () =>
                    {
                        _signalBus.Fire(
                            new BuildingPlacementRequestedSignal(building));

                    });

                _buttons.Add(button);
            }
        }

        private void ClearButtons()
        {
            foreach (BuildButtonView button in _buttons)
            {
                _uiFactory.Release(button.gameObject);
            }

            _buttons.Clear();
        }
    }
}