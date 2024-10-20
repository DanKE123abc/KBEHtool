using System.Collections.Generic;
using KBEHtool.Utils;

namespace KBEHtool.Base
{
    public class KeyboardState : Singleton<KeyboardState>
    {

        private Dictionary<KeyCode, bool> keyStateTable;

        public KeyboardState()
        {
            keyStateTable = new Dictionary<KeyCode, bool>();
        }
        
        public void SetKeyState(KeyCode keyCode, bool isPressed)
        {
            keyStateTable[keyCode] = isPressed;
        }

        public bool GetKeyState(KeyCode keyCode)
        {
            return keyStateTable.TryGetValue(keyCode, out bool isPressed) ? isPressed : false;
        }

        public bool IsStateTrue()
        {
            return keyStateTable.Values.All(state => state == true);
        }
        
        public void ClearAllKeys()
        {
            keyStateTable.Clear();
        }
    }
}