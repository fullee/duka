#ifndef MSQRCODE_H
#define MSQRCODE_H

void (*SetMSide)(int int_Side);			//�������뵥λ����,ȡֵ��Χ1-2,Ĭ��2
void (*SetLMargin)(int int_Margin);		//������߾�,ȡֵ��Χ0-27,Ĭ��0
void (*SetBaudRate)(int int_BaudRate);	//���ô��ڲ�����
void (*SetComPort)(int int_ComPort);	//���ô���
int (*PrintQRCode)(char* cData);		//��ӡ��ά��

#endif


