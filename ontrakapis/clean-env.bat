@echo on

rem rd %USERPROFILES%\.nuget\packages /s /q
rem rd %USERPROFILES%\AppData\Roaming\npm-cache /s /q
rem rd src\webng2\node_modules /s /q

rd publish /s /q
rd publish_tmp /s /q
del publish*.zip 

del /S project.lock.json
