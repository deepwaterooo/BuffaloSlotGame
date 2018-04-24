using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class ManagerAsNormalClass : ISomeManager {
        #region ISomeManager implementation
        public void DoManagement() {
            Debug.Log("Manager implemented as a normal class");
        }
        #endregion
    }
}
