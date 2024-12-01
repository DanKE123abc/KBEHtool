set output=./publish
if exist "%output%" rd /S /Q "%output%"
dotnet build ./KBEHtool/KBEHtool.csproj
xcopy /E /I /Y ".\KBEHtool\lib\" "%output%\KBEHtool\lib\"
copy /Y ".\KBEHtool\KBEHtool.nuspec" "%output%\KBEHtool\KBEHtool.nuspec"
copy /Y ".\KBEHtool\LICENSE" "%output%\KBEHtool\LICENSE"
nuget pack ./publish/KBEHtool/KBEHtool.nuspec -Prop Configuration=Release