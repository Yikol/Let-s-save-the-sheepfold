using UnityEngine;
using System.Collections;
using Codice.Client.BaseCommands;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;

		public Transform[] targets;

		void ChooseRandomTarget(){
			if(targets != null&&targets.Length > 0){
				Transform selectedTarget = targets[Random.Range(0, targets.Length)];
				Vector3 startPoint = selectedTarget.position - selectedTarget.localScale / 2; // 物体起点
        		Vector3 endPoint = selectedTarget.position + selectedTarget.localScale / 2;   // 物体终点
				// 在物体上随机选择一点
				Vector3 randomPoint = new Vector3(
					Random.Range(startPoint.x, endPoint.x),
					selectedTarget.position.y, // 保持 y 坐标不变
					0 // 在 2D 中 z 坐标通常为 0
				);

				// 创建新的空物体作为目标
				if (target != null) {
					Destroy(target.gameObject); // 如果已存在目标，销毁它
				}
				GameObject targetObject = new GameObject("RandomTarget");
				target = targetObject.transform;
				target.position = randomPoint; // 设置目标位置
    }
		}

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
			ChooseRandomTarget();
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if (target != null && ai != null) ai.destination = target.position;
		}
	}
}