using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl2 : MonoBehaviour
{
    public static int health = 1500;//เลือดบอส 1500
    public GameObject bulletPrefab;//ตัวแปรสำหรับใส่ prefeb กระสุน
    public float bulletSpeed = 10f;//ความเร็วเคลื่อนที่ของกระสุน
    [SerializeField] AudioSource shoot;//ตัวแปรสำหรับใส่เสียง

    void Start()
    {
        StartCoroutine(AttackWithBullets());//เริ่มกระบวนการที่ต้องใช้เวลาในเกมด้วยคำสั่ง AttackWithBullets
    }

    IEnumerator AttackWithBullets()//คำสั่งยิงกระสุน
    {
        yield return new WaitForSeconds(5f);//รอ 5 วินาทีก่อนทำการยิง
        
        while (health > 0)//เมื่อเลือดมากกว่า 0
        {
            FireBullet();//ทำการยิง
            yield return new WaitForSeconds(2f);//รอ 2 วินาที จึงจะทำการยิงอีกครั้ง
        }
    }

    void Update()
    {
        if (health <= 0)//ถ้าเลือดบอสน้อยกว่าหรือเท่ากับ 0
        {
            HP.Score +=500;//ได้รับคะแนน 500
            Destroy(gameObject);//ทำลายวัตถุ
        }
    }

    void FireBullet()//คำสั่งยิงกระสุน
    {
        shoot.Play();//เล่นเสียงยิง
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);//สร้างกระสุนจากตำแหน่งของบอส
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;//กำหนดความเร็วการเคลื่อนที่ของกระสุน
        Destroy(bullet, 5f);//ทำลายกระสุนเมื่อผ่านไป 5 วินาที
    }
}
