using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class ManagerAsMonobehaviour : MonoBehaviour, ISomeManager {
 		#region ISomeManager implementation
        public void DoManagement() {
       	 	Debug.Log("Manager implemented as MonoBehaviour");
	    }
    	#endregion    
    }
}
