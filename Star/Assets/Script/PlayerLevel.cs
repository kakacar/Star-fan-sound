using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public Player player;
    public MineBot robot;
    public NormalCollect nc;
    public RareCollect rc;
    public DisableSoundSkill skill;
    public Gun gun;
    public BulletCount bullet;
    private void Update()
    {
        player.maxHp = 100 + player.playerLevel[0] * 10;//���a�ͩR�ɯ�
        gun.addsound = 30 - player.playerLevel[1] * 3;//���a���ɯ�
        skill.maxCD = 40 - player.playerLevel[1] * 2;
        robot.maxHp = 3 + player.robotLevel[0] * 1;//�����H�ͩR�ɯ�
    }
    public void RobotSoundLess()//�����H���ɯ�
    {
        float j = 20;
        for (int i = 0; i < player.robotLevel[1]; i++)
        {
            j -= j * 0.05f;
        }
        rc.addsound = j;
    }
    public void RobotCollectSpeed()//�����H�Ķ��ɯ�
    {
        float j = 35;
        float k = 60;
        for (int i = 0; i < player.robotLevel[2]; i++)
        {
            j -= j * 0.05f;
        }
        for (int i = 0; i < player.robotLevel[2]; i++)
        {
            k -= k * 0.05f;
        }
        nc.time = j;
        rc.time = k;
    }
}
