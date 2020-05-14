using UnityEngine;
using System.Collections;
using System;

namespace Game
{
    public class WinEvent
    {
        public delegate void OnWinAction();
    }

    public interface WinEventController
    {
        void AddListener(WinEvent.OnWinAction listener);
        void TriggerEvent();
    }
}