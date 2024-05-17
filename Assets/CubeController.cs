using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // �L���[�u�̈ړ����x
    private float speed = -12;

    // ���ňʒu
    private float deadLine = -10;

    // �������L���[�u�Փ˃{�����[���t���O
    private bool ColliderVolumeFlg = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�������ǋL
        GetComponent<AudioSource>().volume = this.ColliderVolumeFlg ? 1 : 0;
        if (ColliderVolumeFlg)
        {
            this.ColliderVolumeFlg = false;
        }

        // �L���[�u���ړ������遜��Transform�N���X��Translate�֐��͈����ɗ^�����l�������݂̈ʒu����ړ�������i�w�肵���l�̍��W�Ɉړ�����킯�ł͂Ȃ��I�j���������珇��X�������AY�������AZ�������̈ړ��������w��
        // ����Time.deltaTime�͑O�t���[������̌o�ߎ��Ԃ�\���܂��B�t���[�����[�g��������Ώ������A�t���[�����[�g���Ⴏ��Α傫���Ȃ�BTime.deltaTime���Ȃ��ꍇ�A�t���[�����[�g�ɂ���đ��x�ɍ���������B
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
    //��������Q���ɏՓ˂����ꍇ�i�ǉ��j�A�{�����[���t���O���g�D���[
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.ColliderVolumeFlg = true;
        Debug.Log(this.ColliderVolumeFlg);

        //���j�e�B�����ƏՓ˂����ꍇ�i�ǉ��j
        if (collision.gameObject.tag == "UnityChan2DTag")
        {
            this.ColliderVolumeFlg = false;
        }
    }
}
