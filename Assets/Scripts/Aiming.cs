using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aiming : MonoBehaviour {

   public Texture2D crossHair;

    

    private void OnGUI()
     {
         float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crossHair.width / 3);
         float yMin = Screen.height + (crossHair.height / 2);
         GUI.DrawTexture(new Rect(xMin, yMin, crossHair.width, crossHair.height), crossHair);


     }

 


}
