
// MsqrdemoDlg.h : ͷ�ļ�
//

#pragma once
#include "afxwin.h"


// CMsqrdemoDlg �Ի���
class CMsqrdemoDlg : public CDialog
{
// ����
public:
	CMsqrdemoDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_MSQRDEMO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��


// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP() 
public:
	HINSTANCE m_hInstancePrint;

	afx_msg void OnBnClickedButton1();
private:
	int CheckStatus();	//״̬���
	int m_iStatus;
	void FillPorts();
	int m_iInit;
	int m_lcLanguage;
public:
	afx_msg void OnBnClickedButton2(); 
	afx_msg void OnBnClickedGetqrcode4(); 
	afx_msg void OnBnClickedButton28();
	afx_msg void OnBnClickedButton23(); 
	CComboBox m_ctrNV;
	afx_msg void OnBnClickedButton26();
	afx_msg void OnBnClickedButton27();
	afx_msg void OnDestroy();
	CComboBox m_ctrBaudRate;
	CComboBox m_ctrConnWay; 
	afx_msg void OnCbnSelchangeComboConnway(); 
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton5();
	afx_msg void OnBnClickedButton30();
	afx_msg void OnBnClickedButton31();
	afx_msg void OnBnClickedButton6();
	afx_msg void OnBnClickedButton4();
};
