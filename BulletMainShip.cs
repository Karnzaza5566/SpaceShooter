using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMainShip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//เมื่อวัตถุมีการชน
    {
        if (collision.gameObject.CompareTag("enermy"))//ถ้ามีการชนกับวัตถุที่มี tag enermy
        {
            BossControl2.health -=5;//เลือดบอสลดลง 10
            Destroy(gameObject);//ทำลายวัตถุ
        }
    }
}
