using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;
    //Unity�������ړ�������R���|�[�l���g������i�ǉ��j
    Rigidbody2D rigid2D;
    // �n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    // �W�����v�̑��x�̌����i�ǉ��j
    private float dump = 0.8f;
    // �W�����v�̑��x�i�ǉ��j�����P�b�Ԃ�����20m
    float jumpVelocity = 20;

    // �Q�[���I�[�o�[�ɂȂ�ʒu�i�ǉ��j
    private float deadLine = -9;

    // Start is called before the first frame updatem
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾���遜��GetComponent�֐����g����Animator�R���|�[�l���g���擾�AAnimator�R���|�[�l���g���g���ă��j�e�B�����̃A�j���[�V�����Đ����X�N���v�g�Ő��䂷��
        this.animator = GetComponent<Animator>();

        // Rigidbody2D�̃R���|�[�l���g���擾����i�ǉ��j�����W�����v���邽�߂�Rigidbody2D�R���|�[�l���g���擾�ARigidbody2D���g���ă��j�e�B�������W�����v��������A�W�����v�̍����𒲐߂����肷��
        //����Rigidbody��velocity���g�����Ƃŕ������v�Z���ꂽ���R�ȃW�����v�ɂȂ�I
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame��������A�j���[�V�������Đ����邽�߂ɁAAnimator�Œ�`���Ă���Horizontal�p�����[�^��isGround�p�����[�^�̑J�ڏ�����ݒ肵�Ă���
    void Update()
    {
        //����Animator�̒���Float�Ƃ������O�̃p�����[�^�̒l���O���傫���Ȃ�����J�ڂ��J�n����Ƃ����Ӗ��A1�������Ă���̂ŏ�ɑJ�ڂ���A"Horizontal"�Ƃ����p�����[�^�[��1�ɂ��Ȃ����Ƃ�������
        this.animator.SetFloat("Horizontal", 1);

        // ���n���Ă��邩�ǂ����𒲂ׂ遜�����j�e�B����񂪒��n���Ă���ꍇ��isGround��true�ɐݒ肵�܂�
        //�����O�����Z�q�G�l��������ϐ� = (������) ? �ϐ�1 : �ϐ�2;�@���������𖞂������ꍇ�ɂ͍��ӂ̕ϐ��Ɂu�ϐ�1�v���������A�������Ȃ������ꍇ�́u�ϐ�2�v����������
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        //����Animator�̒���Bool�Ƃ������O�̃p�����[�^�̒l��isGround=true�ɂȂ�����J�ڂ��J�n����A�Ƃ����Ӗ��B"isGround"�Ƃ����p�����[�^��isGround�����Ȃ����Ƃ�������
        this.animator.SetBool("isGround", isGround);

        // �W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���i�ǉ��j�������j�e�B����񂪃W�����v�����ǂ�����isGround�ϐ��Ŕ��ʁAisGround��true�̏ꍇ�͉��ʂ�1�Afalse�̏ꍇ�͉��ʂ�0�ɂ���B
        // ���������ł́AAudioSource�R���|�[�l���g���擾����Ɠ�����volume�ϐ��։��ʂ̒l�������Ă��܂��BAudioSource�N���X�́uvolume�v�ϐ��́A���ʂ�\���Ă��܂��B
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // ���n��ԂŃN���b�N���ꂽ�ꍇ�i�ǉ��j������ʂ��^�b�v�������Ƀ��j�e�B����񂪒��n��Ԃł���΁A���j�e�B�����̏�����̑��x��^����AGetMouseButtonDown(0)��0�͍��N���b�N�A1���ƉE�N���b�N
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // ������̗͂�������i�ǉ��j�������j�e�B�������Ă�Rigidbody2D��Y����jumpVelocity = 20������B
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // �N���b�N����߂��������ւ̑��x����������i�ǉ��j�����^�b�v�������ꂽ���_���烆�j�e�B�����̏�����ւ̑��x�𗎂Ƃ��Đ��������������邱�ƂŁA�^�b�v���Â����ꍇ�����A�W�����v�̍������Ⴍ�Ȃ�悤�ɂ��Ă��܂��B
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        // �f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���i�ǉ��j
        if (transform.position.x < this.deadLine)
        {
            // UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������i�ǉ��j
            //����UIController��Canvas�I�u�W�F�N�g�ɃA�^�b�`����Ă邽�߁AFind�֐����g����UIController���A�^�b�`����Ă�Canvas�I�u�W�F�N�g�������AGetComponent�֐����g����Canvas�ɃA�^�b�`����Ă���UIContorller�X�N���v�g���擾���Ă�
            //�������̂悤�ɁAFind�ŃI�u�W�F�N�g��T����GetComponent�ł��̃I�u�W�F�N�g�̃X�N���v�g���擾������@�͂悭�g��
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ���j�e�B������j������i�ǉ��j
            Destroy(gameObject);
        }
    }
}