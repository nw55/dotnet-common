function exec {
    param(
        [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd
    )

    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $lastexitcode)
    }
}

if(Test-Path .\artifacts) { Remove-Item .\artifacts -Force -Recurse }

$revision = @{ $true = $env:APPVEYOR_BUILD_NUMBER; $false = 1 }[$env:APPVEYOR_BUILD_NUMBER -ne $NULL];

exec { dotnet restore /property:BuildNumber=$revision }

exec { dotnet build -c Release /property:BuildNumber=$revision }

exec { dotnet pack -c Release -o $PSScriptRoot\artifacts --no-build /property:BuildNumber=$revision }
