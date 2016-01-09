REM tools\nuget.exe pack Src\JsonLite\JsonLite.csproj -Prop Configuration=Release -BasePath Src\JsonLite\ -OutputDirectory Build\Packages

tools\nuget.exe pack Src\JsonLite\JsonLite.nuspec -Prop Configuration=Release -BasePath Src\JsonLite\ -OutputDirectory Build\Packages