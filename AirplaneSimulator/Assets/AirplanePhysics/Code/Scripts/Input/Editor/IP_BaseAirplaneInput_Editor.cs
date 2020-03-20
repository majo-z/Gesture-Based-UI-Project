using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace IndiePixel
{
    //custom editor to override IP_BaseAirplane_Input
    [CustomEditor(typeof(IP_BaseAirplane_Input))]

    //convert class into editor type
    public class IP_BaseAirplaneInput_Editor : Editor 
    {

        #region Variables

        //the object being inspected
        private IP_BaseAirplane_Input targetInput;
        #endregion



        #region Bultin Methods
        void OnEnable()
        {
            targetInput = (IP_BaseAirplane_Input)target;
        }

        public override void OnInspectorGUI()
        {
            //default GUI
            base.OnInspectorGUI();

            string debugInfo = "";
            debugInfo += "Pitch = " + targetInput.Pitch + "\n";
            debugInfo += "Roll = " + targetInput.Roll + "\n";
            debugInfo += "Yaw = " + targetInput.Yaw + "\n";
            debugInfo += "Throttle = " + targetInput.Throttle + "\n";
            debugInfo += "Brake = " + targetInput.Brake + "\n";
            debugInfo += "Flaps = " + targetInput.Flaps + "\n";

            //Custom Editor Code
            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(100));
            GUILayout.Space(20);

            //Update Inspector
            Repaint();
        }
        #endregion
    }
}
