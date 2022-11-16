Param(
    [parameter(Mandatory=$false)][string]$baseUrl = "https://monkeygroup2ca.agreeablemeadow-e0922af6.australiaeast.azurecontainerapps.io/"
)

class Monkey 
{
    [string] $Name
    [string] $Location
    [string] $Details
    [string] $Image
    [int] $Population
    [double] $Latitude
    [double] $Longitude
}

function SimulateRequest {
    Param(
     [int]$sleep = 5000,
     [string]$baseUrl
    )
    
    $feeds = [System.Collections.Generic.List[Monkey]](Get-Content './monkeysmore.json' | Out-String | ConvertFrom-Json)
    
    $feeds | ForEach-Object -ThrottleLimit 20 -Parallel {
        Write-Host "> Requesting feed" $_.Name 

        Invoke-WebRequest -Method POST -Uri $using:baseUrl"api/Monkey" `
                        -Body ($_|ConvertTo-Json) `
                        -ContentType application/json

        [System.Threading.Thread]::Sleep($sleep)
    } 
}


SimulateRequest -baseUrl $baseUrl