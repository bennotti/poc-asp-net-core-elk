$projectName=$args[0]
$ambiente=$args[1]
write-host "Parametros defaults, Sintaxe customizada: run-elk.ps1 projectName local|dev|tst|hml|prd" 
write-host "Parametros defaults, default: run-elk.ps1 projectName local" 

if ($projectName -eq $null) {
    $projectName = "projectName"
}

if ($ambiente -eq $null) {
    $ambiente = "local"
}

$dockerProjectName=$projectName + '_elk_' + $ambiente
$dockerFileName='docker-comp-elk-' + $ambiente + '.yml'

docker-compose -p $dockerProjectName -f ./devops/elk/$dockerFileName down
docker-compose -p $dockerProjectName -f ./devops/elk/$dockerFileName up --build -d