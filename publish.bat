@echo off 
rem pack all project 
dotnet pack ./RedGrape.Infra.Transmit/RedGrape.Infra.Transmit.csproj -c Release -o .  
dotnet pack ./RedGrape.Infra.Core/RedGrape.Infra.Core.csproj -c Release -o .

rem Set the NuGet feed URL  
set nuget_feed_url=https://api.nuget.org/v3/index.json  

rem Loop through all .nupkg files in the current directory  
for %%f in (*.nupkg) do (  
    rem Push the NuGet package to the feed  
    dotnet nuget push %%f -k %NUGET_API_KEY% -s %nuget_feed_url%  
    if %ERRORLEVEL% neq 0 (  
        echo Error pushing %%f  
        goto :eof  
    )  
)  

pause