reg Query "HKLM\Hardware\Description\System\CentralProcessor\0" | find /i "x86" > NUL && set OS=32BIT || set OS=64BIT

if %OS%==32BIT %windir%\system32\regsvr32.exe "%~pd0Msprintsdk.ocx"
if %OS%==64BIT %windir%\syswow64\regsvr32.exe "%~pd0Msprintsdk.ocx"