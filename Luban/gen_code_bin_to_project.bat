cd /d %~dp0
set WORKSPACE=..

set GEN_CLIENT=%WORKSPACE%\Luban\Luban.ClientServer\Luban.ClientServer.exe
set CONF_ROOT=%WORKSPACE%\Luban\Config
set DATA_OUTPUT=%ROOT_PATH%..\GenerateDatas

%GEN_CLIENT% -j cfg --^
 -d %CONF_ROOT%\Defines\__root__.xml ^
 --input_data_dir %CONF_ROOT%\Datas ^
 --output_code_dir %WORKSPACE%/Assets/GameScripts/HotFix/GameProto/GameConfig ^
 --output_data_dir %WORKSPACE%/Assets/AssetRaw/Configs/bytes/ ^
 --gen_types code_cs_unity_bin,data_bin ^
 -s client

xcopy "%WORKSPACE%\Assets\AssetRaw\Configs\bytes\" "%WORKSPACE%\GenerateDatas\bytes\" /E /I

echo ======== 生成配置文件结束 ========

pause