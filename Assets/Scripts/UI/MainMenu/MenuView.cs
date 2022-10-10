using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Outworld.UI.Views
{
    public class MenuView : MonoBehaviour
    {
        public Action OnButtonStartCliced;
        public Action OnButtonSettingsCliced;
        public Action OnButtonExitCliced;

        [SerializeField] private Button BtnStart;
        [SerializeField] private Button BtnSettings;
        [SerializeField] private Button BtnExit;

        private void Awake()
        {
            BtnStart.onClick.AddListener(() => { OnButtonStartCliced?.Invoke(); });
            BtnSettings.onClick.AddListener(() => { OnButtonSettingsCliced?.Invoke(); });
            BtnExit.onClick.AddListener(() => { OnButtonExitCliced?.Invoke(); });
        }
    }
}

