using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingTrigger : MonoBehaviour {
    public int numeris;
    public static bool trigger1, trigger2, trigger3, trigger4, trigger5, trigger6;
    

	void Update () {
        if (gameObject.name == "trigger1")
            numeris = 1;
        else if (gameObject.name == "trigger2")
            numeris = 2;
        else if (gameObject.name == "trigger3")
            numeris = 3;
        else if (gameObject.name == "trigger4")
            numeris = 4;
        else if (gameObject.name == "trigger5")
            numeris = 5;
        else if (gameObject.name == "trigger6")
            numeris = 6;
    }

    void OnTriggerStay(Collider col) {  
                if (numeris == 1)
                    trigger1 = true;
                else if (numeris == 2)
                    trigger2 = true;
                else if (numeris == 3)
                    trigger3 = true;
                else if (numeris == 4)
                    trigger4 = true;
                else if (numeris == 5)
                    trigger5 = true;
                else if (numeris == 6)
                    trigger6 = true;
    }

    void OnTriggerExit(Collider col) {
                if (numeris == 1)
                    trigger1 = false;
                else if (numeris == 2)
                    trigger2 = false;
                else if (numeris == 3)
                    trigger3 = false;
                else if (numeris == 4)
                    trigger4 = false;
                else if (numeris == 5)
                    trigger5 = false;
                else if (numeris == 6)
                    trigger6 = false;
   }
}
