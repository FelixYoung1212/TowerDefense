set WORKSPACE=..
set LUBAN_DLL=%WORKSPACE%\Tools\Luban\Luban.dll
set CONF_ROOT=.
set OUTPUT_CODE_DIR=%WORKSPACE%\Assets\Plugins\UnityGameFramework\Scripts\Runtime\DataTable\Luban
set OUTPUT_DATA_DIR=%WORKSPACE%\Assets\AddressableResources\DataTables

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d bin ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=%OUTPUT_CODE_DIR% ^
    -x outputDataDir=%OUTPUT_DATA_DIR%
