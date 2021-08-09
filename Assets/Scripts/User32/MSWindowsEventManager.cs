using System;
using System.Collections;
using System.Collections.Generic;
using Gma.UserActivityMonitor;

namespace LoLRunes.User32
{
    public enum MouseEvent
    {
        MOUSE_DOWN
    }

    public class MSWindowsEventManager
    {
        #region Singleton
        public static MSWindowsEventManager _instance = null;

        public static MSWindowsEventManager instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MSWindowsEventManager();

                return _instance;
            }
        }
        #endregion

        private GlobalEventProvider globalEventProvider;
        private Dictionary<MouseEvent, List<MouseEventExtHandler>> subscribedDelegates;

        private MSWindowsEventManager()
        {
            globalEventProvider = new GlobalEventProvider();

            subscribedDelegates = new Dictionary<MouseEvent, List<MouseEventExtHandler>>();

            foreach (MouseEvent enumValue in Enum.GetValues(typeof(MouseEvent)))
                subscribedDelegates.Add(enumValue, new List<MouseEventExtHandler>());
        }

        public void SubscribeFor_MouseDown(MouseEventExtHandler mouseEventExtHandler)
        {
            subscribedDelegates[MouseEvent.MOUSE_DOWN].Add(mouseEventExtHandler);
            globalEventProvider.MouseDown += mouseEventExtHandler;
        }

        public void UnsubscribeAll(MouseEventExtHandler mouseEventExtHandler)
        {
            foreach (KeyValuePair<MouseEvent, List<MouseEventExtHandler>> pair in subscribedDelegates)
                foreach (MouseEventExtHandler delegateEvent in pair.Value)
                {
                    switch(pair.Key)
                    {
                        case MouseEvent.MOUSE_DOWN:
                            globalEventProvider.MouseDown += delegateEvent;
                            break;
                        default:
                            break;
                    }
                }
        }
    }
}
    