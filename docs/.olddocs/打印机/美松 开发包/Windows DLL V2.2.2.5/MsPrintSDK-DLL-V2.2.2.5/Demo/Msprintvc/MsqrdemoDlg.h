
// MsqrdemoDlg.h : 头文件
//

#pragma once
#include "afxwin.h"


// CMsqrdemoDlg 对话框
class CMsqrdemoDlg : public CDialog
{
// 构造
public:
	CMsqrdemoDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_MSQRDEMO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持


// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP() 
public:
	HINSTANCE m_hInstancePrint;

	afx_msg void OnBnClickedButton1();
private:
	int CheckStatus();	//状态检查
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
