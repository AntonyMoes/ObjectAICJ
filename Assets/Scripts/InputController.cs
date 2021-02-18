 using System;
 using UnityEngine;
 using System.Collections;
 
 public class InputController : MonoBehaviour {
     public enum EInputState {
         MouseKeyboard,
         Controller
     };
     EInputState _state = EInputState.MouseKeyboard;
     public EInputState State => _state;

     void OnGUI() {
         switch(_state) {
             case EInputState.MouseKeyboard:
                 if(IsControllerInput()) {
                     _state = EInputState.Controller;
                 }
                 break;
             case EInputState.Controller:
                 if (IsMouseKeyboard()) {
                     _state = EInputState.MouseKeyboard;
                 }
                 break;
             default:
                 throw new ArgumentOutOfRangeException();
         }
     }
     
     bool IsMouseKeyboard() {
         if (Event.current.isKey ||
             Event.current.isMouse) {
             return true;
         }
         
         if( Input.GetAxis("Mouse X") != 0.0f ||
             Input.GetAxis("Mouse Y") != 0.0f ) {
             return true;
         }
         
         return false;
     }
 
     bool IsControllerInput() {
         if(Input.GetKey(KeyCode.Joystick1Button0)  ||
            Input.GetKey(KeyCode.Joystick1Button1)  ||
            Input.GetKey(KeyCode.Joystick1Button2)  ||
            Input.GetKey(KeyCode.Joystick1Button3)  ||
            Input.GetKey(KeyCode.Joystick1Button4)  ||
            Input.GetKey(KeyCode.Joystick1Button5)  ||
            Input.GetKey(KeyCode.Joystick1Button6)  ||
            Input.GetKey(KeyCode.Joystick1Button7)  ||
            Input.GetKey(KeyCode.Joystick1Button8)  ||
            Input.GetKey(KeyCode.Joystick1Button9)  ||
            Input.GetKey(KeyCode.Joystick1Button10) ||
            Input.GetKey(KeyCode.Joystick1Button11) ||
            Input.GetKey(KeyCode.Joystick1Button12) ||
            Input.GetKey(KeyCode.Joystick1Button13) ||
            Input.GetKey(KeyCode.Joystick1Button14) ||
            Input.GetKey(KeyCode.Joystick1Button15) ||
            Input.GetKey(KeyCode.Joystick1Button16) ||
            Input.GetKey(KeyCode.Joystick1Button17) ||
            Input.GetKey(KeyCode.Joystick1Button18) ||
            Input.GetKey(KeyCode.Joystick1Button19) ) {
             return true;
         }
         
         if(Input.GetAxis("MoveHorizontal") != 0.0f ||
            Input.GetAxis("MoveVertical") != 0.0f ||
            Input.GetAxis("LookHorizontal") != 0.0f ||
            Input.GetAxis("LookVertical") != 0.0f) {
             return true;
         }
         
         return false;
     }
 }