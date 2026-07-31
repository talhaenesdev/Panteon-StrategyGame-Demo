using System;
using System.Collections.Generic;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Views;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class BuildPanelController : MonoBehaviour
    {
        [SerializeField]
        private List<BuildingData> buildings;

        [SerializeField]
        private BuildPanelView view;

        [Inject]
        private SignalBus _signalBus;

        private void Start()
        {
            view.Hide();

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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                view.Hide();
            }
        }

        private void BuildButtons()
        {
            foreach (var building in buildings)
            {
                var button = view.CreateButton();

                button.Initialize(
                    building.DisplayName,
                    building.Icon,
                    () =>
                    {
                        _signalBus.Fire(
                            new BuildingPlacementRequestedSignal(building));

                        view.Hide();
                    });
            }
        }
    }
}