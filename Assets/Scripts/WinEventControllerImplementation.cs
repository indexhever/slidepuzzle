using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

namespace Game
{
    public class WinEventControllerImplementation : WinEventController
    {
        
        private WinEvent.OnWinAction onWinGame;

        public void AddListener(WinEvent.OnWinAction listener)
        {
            onWinGame += listener;
        }

        public void TriggerEvent()
        {
            onWinGame?.Invoke();
        }
    }
}