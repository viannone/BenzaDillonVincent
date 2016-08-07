using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeMaster : MonoBehaviour {

	List<TimeTravelController> timeTravelEnabledObjects = new List<TimeTravelController>();

	public void AddToList(TimeTravelController t){
		timeTravelEnabledObjects.Add (t);
	}
}
