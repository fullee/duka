
// Msqrdemo.h : PROJECT_NAME Ӧ�ó������ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// CMsqrdemoApp:
// �йش����ʵ�֣������ Msqrdemo.cpp
//

class CMsqrdemoApp : public CWinAppEx
{
public:
	CMsqrdemoApp();

// ��д
	public:
	virtual BOOL InitInstance();

// ʵ��

	DECLARE_MESSAGE_MAP()
};

extern CMsqrdemoApp theApp;