using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UBlockly
{
    [CodeInterpreter(BlockType = "move_robot_forward")]
    public class Move_Forward_Robot_Cmdtor : EnumeratorCmdtor{
        protected override IEnumerator Execute(Block block){
           string distanceStr = block.GetFieldValue("DISTANCE");
            int distance = int.Parse(distanceStr);
            GameObject selectedRobot = GameObject.FindWithTag("SelectedRobot");
        
            yield return selectedRobot.GetComponent<RobotMotionController1>().MoveVerticalRobotInfinite(10.0f, true);
        }
    }
}
