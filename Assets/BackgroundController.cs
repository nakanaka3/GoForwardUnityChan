using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    // �X�N���[�����x
    private float scrollSpeed = -1;
    // �w�i�I���ʒu
    private float deadLine = -16;
    // �w�i�J�n�ʒu
    private float startLine = 15.8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �w�i���ړ����遜���t���[�����[�g�ɂ���đ��x���ς��Ȃ��悤��Time.deltaTime���|���Z���Ă���
        transform.Translate(this.scrollSpeed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����A��ʉE�[�Ɉړ����遜���w�i�摜��x���W���t���[�����ƂɃ`�F�b�N�A�w�i�摜�����[�i�w�i��x���W��deadLine�ϐ���菬�����l�j�܂ŃX�N���[���������ʉE�[��startLine�ϐ��̈ʒu�ɖ߂�
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}