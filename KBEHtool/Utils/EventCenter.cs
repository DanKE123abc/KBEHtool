using System;
using System.Collections;
using System.Collections.Generic;

namespace KBEHtool.Utils
{

    public interface IEventInfo
    {
    }

    public class EventInfo<T> : IEventInfo
    {
        public Action<T> Actions;

        public EventInfo(Action<T> action)
        {
            Actions += action;
        }
    }

    public class EventInfo : IEventInfo
    {
        public Action Actions;

        public EventInfo(Action action)
        {
            Actions += action;
        }
    }

    public class EventCenter : Singleton<EventCenter>
    {
        private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

        public void AddEventListener(string name, Action action)
        {
            //判断字典里有没有对应这个事件，有就执行，没有就加进去。
            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo).Actions += action;
            }
            else
            {
                eventDic.Add(name, new EventInfo(action));
            }
        }

        public void AddEventListener<T>(string name, Action<T> action)
        {
            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo<T>).Actions += action;
            }
            else
            {
                eventDic.Add(name, new EventInfo<T>(action));
            }
        }

        public void RemoveEventListener(string name, Action action)
        {
            if (eventDic.ContainsKey(name))
            {
                //移除这个委托
                (eventDic[name] as EventInfo).Actions -= action;
            }
        }

        public void RemoveEventListener<T>(string name, Action<T> action)
        {
            if (eventDic.ContainsKey(name))
            {
                //移除这个委托
                (eventDic[name] as EventInfo<T>).Actions -= action;
            }
        }

        public void EventTrigger(string name)
        {
            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo).Actions?.Invoke();
            }

        }

        public void EventTrigger<T>(string name, T info)
        {
            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo<T>).Actions?.Invoke(info);
            }
        }
        
        public void Clear()
        {
            eventDic.Clear();
        }
    }

}