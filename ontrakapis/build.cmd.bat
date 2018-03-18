@echo on

@For /f "tokens=1-3 delims=/ " %%a in ('date /t') do @(set timestamp=%%c-%%a-%%b)
@For /f "tokens=1-2 delims=/ " %%a in ('time /t') do @(set timestamp=%timestamp%_%%a-%%b)

@set _BASEPATH_=%CD%
@set _NGWEB_=%_BASEPATH_%\src\webng2

@CLS

@echo.
@echo.
@echo ~~~~~ (DOTNET ENVIRONMENT) ~~~~~
@echo.
@echo.
@call dotnet --info

@echo.
@echo.
@echo ~~~~~ (NODEJS ENVIRONMENT) ~~~~~
@echo.
@echo.
@call npm config list

@echo.
@echo.

@echo -----------------------------------------------------------------------
@echo.
@echo.
@echo  CLEANING ENVIRONMENT
@echo.
@echo.
@echo -----------------------------------------------------------------------

@>NUL 2>&1 rd %_NGWEB_%\bin /s /q
@>NUL 2>&1 rd %_NGWEB_%\obj /s /q
@>NUL 2>&1 rd %_NGWEB_%\gen /s /q
@>NUL 2>&1 rd %_NGWEB_%\views /s /q
@>NUL 2>&1 rd %_NGWEB_%\wwwroot /s /q

@>NUL 2>&1 rd %_BASEPATH_%\publish /s /q
@>NUL 2>&1 rd %_BASEPATH_%\publish_tmp /s /q
@>NUL 2>&1 del %_BASEPATH_%\publish*.zip

@>NUL 2>&1 del /S project.lock.json

@echo -----------------------------------------------------------------------
@echo.
@echo.
@echo  NPM RESTORE ^& BUILD-PRODUCTION
@echo.
@echo.
@echo -----------------------------------------------------------------------

@cd %_NGWEB_%
@call npm prune
@call npm install
@call npm run build-prod
@cd %_BASEPATH_%

@echo -----------------------------------------------------------------------
@echo.
@echo.
@echo  DOTNET RESTORE ^& PUBLISH
@echo.
@echo.
@echo -----------------------------------------------------------------------

@dotnet restore
@dotnet publish %_NGWEB_% --framework net462 --build-base-path %_BASEPATH_%\publish_tmp --output %_BASEPATH_%\publish --configuration Release 
@rem dotnet publish %_NGWEB_% --framework netcoreapp1.1 --build-base-path %_BASEPATH_%\publish_tmp --output %_BASEPATH_%\publish --configuration Release --runtime win7-x64

@echo -----------------------------------------------------------------------
@echo.
@echo.
@echo  WEB CONFIGURATIONS
@echo.
@echo.
@echo -----------------------------------------------------------------------

@>NUL 2>&1 copy %_NGWEB_%\package.json  %_BASEPATH_%\publish
@>NUL 2>&1 copy %_BASEPATH_%\configs\web.config %_BASEPATH_%\publish
@>NUL 2>&1 copy %_BASEPATH_%\configs\appsettings.json %_BASEPATH_%\publish
@>NUL 2>&1 copy %_BASEPATH_%\configs\run-server.bat %_BASEPATH_%\publish

@echo -----------------------------------------------------------------------
@echo.
@echo.
@echo  NPM PRODUCTION ^& PUBLISH-%timestamp%.ZIP
@echo.
@echo.
@echo -----------------------------------------------------------------------

@cd %_BASEPATH_%\publish
@call npm install --production
@cd %_BASEPATH_%

@zip -r %_BASEPATH_%\publish-%timestamp%.zip publish

@echo -----------------------------------------------------------------------
@echo.
@echo.
@echo  BUILD COMPLETE.
@echo.
@echo.
@echo -----------------------------------------------------------------------
