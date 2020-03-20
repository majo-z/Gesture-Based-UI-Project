using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndiePixel
{   
    //custom editor to override IP_XboxAirplane_Input
    [CustomEditor(typeof(IP_XboxAirplane_Input))]
    public class IP_XboxAirplaneInput_Editor : Editor 
    {
        #region Variables
        private IP_XboxAirplane_Input targetInput;
        #endregion



        #region Bultin Methods
        void OnEnable()
        {
            //the object being inspected
            targetInput = (IP_XboxAirplane_Input)target;
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
            debugInfo += "Sticky Throttle = " + targetInput.StickyThrottle + "\n";
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
