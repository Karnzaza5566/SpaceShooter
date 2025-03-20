using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float rotateSpeed;//ช่องใส่ความเร็วการหมุน
    
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);//การหมุนของวัตถุ
    }

    private void OnTriggerEnter2D(Collider2D collision)//เมื่อวัตถุมีการชน
    {
        if (collision.gameObject.CompareTag("player"))//ถ้ามีการชนกับวัตถุที่มี tag player
        {
        Destroy(gameObject);//ทำลายวัตถุ
        HP.HPShip -= 10;//เลือดผู้เล่นลดลง 10
        }
    }
}
