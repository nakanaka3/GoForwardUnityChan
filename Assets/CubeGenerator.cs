using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    // �L���[�u��Prefab
    public GameObject cubePrefab;

    // �L���[�u�̉�
    public AudioClip block;

    private AudioSource audioSource;

    // ���Ԍv���p�̕ϐ�
    private float delta = 0;

    // �L���[�u�̐����Ԋu
    private float span = 1.0f;

    // �L���[�u�̐����ʒu�FX���W
    private float genPosX = 12;

    // �L���[�u�̐����ʒu�I�t�Z�b�g
    private float offsetY = 0.3f;
    // �L���[�u�̏c�����̊Ԋu
    private float spaceY = 6.9f;

    // �L���[�u�̐����ʒu�I�t�Z�b�g
    private float offsetX = 0.5f;
    // �L���[�u�̉������̊Ԋu
    private float spaceX = 0.4f;

    // �L���[�u�̐������̏��
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�������Ԍo�߂𑪂邽�߁Adelta�ϐ���Time.deltaTime�𑫂��Ă��܂��B���t���[���Ԃ̎��Ԃ����Z���邱�ƂŁAdelta�ϐ��ɂ͌o�ߎ��Ԃ��������܂�
        this.delta += Time.deltaTime;

        // span�b�ȏ�̎��Ԃ��o�߂������𒲂ׂ�B�������̏����ɂ���āA��莞�Ԃ��Ƃɓ�����J��Ԃ��������쐬���Ă��܂��B
        if (this.delta > this.span)
        {
            this.delta = 0;
            // ��������L���[�u���������_���Ɍ��߂�
            int n = Random.Range(1, maxBlockNum + 1);

            // �w�肵���������L���[�u�𐶐�����
            for (int i = 0; i < n; i++)
            {
                // �L���[�u�̐���
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);


            }
            // ���̃L���[�u�܂ł̐������Ԃ����߂�
            this.span = this.offsetX + this.spaceX * n;
        }
    }
    //��������
    void OnCollisionEnter(Collision other)
    {
        //��Q���ɏՓ˂����ꍇ�i�ǉ��j�A�����L���[�u����񂪓����������̃I�u�W�F�N�g�̃^�O���L���[�u���n�ʂ�������c
        if (other.gameObject.tag == "CubeTag" || other.gameObject.tag == "GroundTag")
        {
            // �������n�ʂƐݒu�����Ƃ��ɂ̓{�����[�����P�ɂ���i�ǉ��j
            GetComponent<AudioSource>().volume = 1;
        }
        //�S�[���n�_�ɓ��B�����ꍇ�i�ǉ��j
        if (other.gameObject.tag == "UnityChan2DTag")
        {
            // �������n�ʂƐݒu�����Ƃ��ɂ̓{�����[�����P�ɂ���i�ǉ��j
            GetComponent<AudioSource>().volume = 0;
        }
    }
}