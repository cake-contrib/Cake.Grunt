#Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -ProxyUseDefaultCredentials -OutFile 'dotnet-install.ps1';

#./dotnet-install.ps1 -InstallDir '~/.dotnet' -Version '7.0.0' -Runtime 'dotnet';

# Run a separate PowerShell process because the script calls exit, so it will end the current PowerShell session.
# &powershell -NoProfile -ExecutionPolicy unrestricted -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; &([scriptblock]::Create((Invoke-WebRequest -UseBasicParsing 'https://dot.net/v1/dotnet-install.ps1'))) -Version '7.0.0' -Runtime 'dotnet'"