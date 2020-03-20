using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace
namespace IndiePixel
{
    public class IP_BaseAirplane_Input : MonoBehaviour 
    {
        #region Variables

        //up and down
        protected float pitch = 0f;

        //roll left and right
        protected float roll = 0f;

        //turn left and right
        protected float yaw = 0f;

        //gas(speed)
        protected float throttle = 0f;

        //how fast the throttle goes up and down
        public float throttleSpeed = 0.1f;

        //current sticky value
        protected float stickyThrottle;
        public float StickyThrottle
        {
            get{return stickyThrottle;}
        }


        [SerializeField]
        //intensity of breaks
        private KeyCode brakeKey = KeyCode.Space;
        protected float brake = 0f;

        [SerializeField]
        protected KeyCode cameraKey = KeyCode.C;
        protected bool cameraSwitch = false;

        //moving the flaps in different angles
        public int maxFlapIncrements = 2;
        protected int flaps = 0;
        #endregion





        #region Properties
        public float Pitch
        {
            get{return pitch;}
        }

        public float Roll
        {
            get{return roll;}
        }

        public float Yaw
        {
            get{return yaw;}
        }

        public float Throttle
        {
            get{return throttle;}
        }

        public int Flaps
        {
            get{return flaps;}
        }
            
        public float NormalizedFlaps
        {
            get
            {
                return (float)flaps / maxFlapIncrements;
            }
        }

        public float Brake
        {
            get{return brake;}
        }

        public bool CameraSwitch
        {
            get{return cameraSwitch;}
            set { cameraSwitch = value; }
        }
        #endregion






        #region Builtin Methods
    	// Use this for initialization
      // Start is called before the first frame update
    	void Start () 
      { 
        //Debug.Log("Inputs Started!"); 
      }
    	
    	// Update is called once per frame
    	void Update () 
        {   
            //Debug.Log("Inputs Updating!");
            HandleInput();
            StickyThrottleControl();
            ClampInputs();
    	}
        #endregion






        #region Custom Methods
        protected virtual void HandleInput()
        {
            //Debug.Log("Handling Input!");

            //Map inputs - Keyboard
            //Process Main Control Input
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            //Debug.Log("Pitch: " + pitch + " - " + "Roll" + roll);
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");


            //Process Brake inputs
            brake = Input.GetKey(brakeKey)? 1f : 0f;

            //Process Flaps Inputs
            if(Input.GetKeyDown(KeyCode.F))
            {
                flaps += 1;
            }

            if(Input.GetKeyDown(KeyCode.G))
            {
                flaps -= 1;
            }

            //Camera Switch Key
            cameraSwitch = Input.GetKeyDown(cameraKey);
        }


        //Create a Throttle Value that gradually grows and shrinks
        protected void StickyThrottleControl()
        {
            stickyThrottle = stickyThrottle + (-throttle * throttleSpeed * Time.deltaTime);

            //Debug.Log(stickyThrottle);
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }

        protected void ClampInputs()
        {
            pitch = Mathf.Clamp(pitch, -1f, 1f);
            roll = Mathf.Clamp(roll, -1f, 1f);
            yaw = Mathf.Clamp(yaw, -1f, 1f);
            throttle = Mathf.Clamp(throttle, -1f, 1f);
            brake = Mathf.Clamp(brake, 0f, 1f);
            //clamp it between 0 and 2
            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
        }
        #endregion
    }
}
