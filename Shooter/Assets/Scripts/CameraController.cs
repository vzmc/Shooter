using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineFreeLook CmFreeLook;
    [SerializeField]
    private Transform follow;
    [SerializeField]
    private Transform lookAt;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform[] enemies;
    [SerializeField]
    private AimMark aimMark;

    private int lockedEnemyIndex;

    private void Start()
    {
        // 给FreeLook虚拟相机设置Follow和LookAt的物体
        CmFreeLook.Follow = follow;
        CmFreeLook.LookAt = lookAt;

        // 设置锁定标记的跟随对象
        aimMark.SetAimTarget(lookAt);
    }

    private void Update()
    {
        // 按下空格时切换锁定的敌人
        if(Input.GetKeyDown(KeyCode.Space))
        {
            lockedEnemyIndex = (lockedEnemyIndex + 1) % enemies.Length;
            aimMark.PlayAimAnimation();
        }

        // 使lookAt的位置和旋转都和锁定的目标保持一致
        lookAt.position = enemies[lockedEnemyIndex].position;
        lookAt.position = enemies[lockedEnemyIndex].position;

        // 使follow的位置和玩家一致
        follow.position = player.position;
        // 使follow的z轴正方向指向lookAt
        follow.LookAt(lookAt);
    }
}
