using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UBlockly
{
    [CodeInterpreter(BlockType = "sensor_touch_contact")]
    public class Detection_Sensor_Touch_Contact_Cmdtor : ValueCmdtor{
        protected override DataStruct Execute(Block block){
            //int index = int.Parse(block.GetFieldValue("NUMBER"));
            string sensorPosition = block.GetFieldValue("POSITION");
            GameObject selectedRobot = GameObject.FindWithTag("SelectedRobot");
            bool data = selectedRobot.GetComponent<RobotManager>().GetTouchInfo(sensorPosition);
            Debug.Log("Devuelve "+data.ToString());
            return new DataStruct(data);
        }
    }
}
