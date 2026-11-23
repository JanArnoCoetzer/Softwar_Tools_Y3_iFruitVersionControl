# escape=`

FROM mcr.microsoft.com/windows/servercore:ltsc2022

WORKDIR C:\app
COPY iBlendit.zip ./iBlendit.zip

SHELL ["powershell", "-Command"]
RUN Expand-Archive -LiteralPath 'C:/app/iBlendit.zip' -DestinationPath 'C:/app'
CMD $p = Start-Process -FilePath .\bin\Release\net10.0-windows\SmoothieTruckApp.exe -ArgumentList '--smoke-test' -Wait -PassThru; if ($p.ExitCode -eq 0) { 'iBlendit smoke test passed' } else { 'iBlendit smoke test failed' }; exit $p.ExitCode
