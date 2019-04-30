@echo off
set destination="D:\MoneyBin"
robocopy "F:\Users\Nelson\Documents\Visual Studio 2017\Projects\MoneyBin\MoneyBin\bin\Debug" %destination% /XO
pause