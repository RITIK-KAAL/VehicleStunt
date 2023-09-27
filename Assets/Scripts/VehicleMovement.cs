using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class VehicleMovement : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        [SerializeField]
        private Joystick joystick;
        private float VerticalInput;
        public float HorizontalInput;
        private float VerticalConvertor;
        private float HorizontalConvertor; 
        private float NegativeSpeed = -40f; 

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            float HorizontalInput = Input.GetAxis("Horizontal");
            float VerticalInput = Input.GetAxis("Vertical");

            // Mobile Joystick Input
            /*            HorizontalInput = joystick.Horizontal;
                        VerticalInput = joystick.Vertical;*/

            // Mobile Steering Wheel Input
            /*            VerticalInput = VerticalConvertor; */
            m_Car.Move(HorizontalInput, VerticalInput, VerticalInput, 0f);
        } 

        public void VerticalClick(float verticalInput)
        {
            VerticalConvertor = verticalInput * NegativeSpeed;
        }
        public void HorizontalClick(float horizontalInput)
        {
            HorizontalConvertor = horizontalInput;
        }
    }
}
