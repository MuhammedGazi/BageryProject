# Kullanım: .\generate-feature.ps1 -FeatureName "Category"
param (
    [Parameter(Mandatory=$true)]
    [string]$FeatureName, # Tekil İsim (Entity İsmi): Category
    
    [string]$RootNamespace = "Bagery.Business",
    [string]$BaseFolder = "Features",
    [string]$EntityFolderPath = "..\Bagery.Core\Entities"
)

# --- İSİMLENDİRME STRATEJİSİ ---
# Entity ismi "Category" kalacak ama Namespace ve Klasör "Categories" olacak.
# Böylece Category (Entity) ile Categories (Namespace) çakışmayacak!
if ($FeatureName.EndsWith("y")) {
    $PluralName = $FeatureName.Substring(0, $FeatureName.Length - 1) + "ies" # Category -> Categories
} else {
    $PluralName = $FeatureName + "s" # Product -> Products
}

# 1. Entity Dosyasını Bul (Tekil isme göre ara: Category.cs)
$entityFile = Join-Path $EntityFolderPath "$FeatureName.cs"
$properties = @()

if (Test-Path $entityFile) {
    Write-Host "📄 Entity bulundu: $FeatureName.cs" -ForegroundColor Cyan
    $content = Get-Content $entityFile
    foreach ($line in $content) {
        if ($line -match 'public\s+(?!virtual)(?<Type>[\w\?<>\[\]]+)\s+(?<Name>\w+)\s*\{\s*get;\s*set;\s*\}') {
            $properties += [PSCustomObject]@{ Type = $Matches.Type; Name = $Matches.Name }
        }
    }
}

# Property String Hazırlığı
$allPropsString = ($properties | ForEach-Object { "$($_.Type) $($_.Name)" }) -join ", "
$createPropsString = ($properties | Where-Object { $_.Name -ne "Id" } | ForEach-Object { "$($_.Type) $($_.Name)" }) -join ", "
$idPropString = "int Id"

# 2. Ana Klasör Yolu (ARTIK ÇOĞUL İSİM KULLANILIYOR: Features/Categories)
$FeaturePath = Join-Path $BaseFolder $PluralName

# --- DOSYA OLUŞTURMA FONKSİYONU ---
function Create-ClassFile {
    param ($folderPath, $fileName, $content)
    if (-not (Test-Path $folderPath)) { New-Item -Path $folderPath -ItemType Directory -Force | Out-Null }
    $fullPath = Join-Path $folderPath $fileName
    Set-Content -Path $fullPath -Value $content
    Write-Host "Created: $fileName" -ForegroundColor Green
}

# --- COMMANDS ---
$commands = @("Create", "Update", "Delete")

foreach ($cmd in $commands) {
    $actionName = "$cmd$FeatureName" # CreateCategory (Hala tekil, doğru)
    $folderPath = Join-Path $FeaturePath "Commands\$actionName"
    
    switch ($cmd) {
        "Create" { $recordProps = $createPropsString }
        "Update" { $recordProps = $allPropsString }
        "Delete" { $recordProps = $idPropString }
    }

    # NAMESPACE KISMINA DİKKAT: $PluralName kullanıyoruz!
    $commandContent = @"
using MediatR;
using Bagery.Core.Utilities.Results;

namespace $RootNamespace.$BaseFolder.$PluralName.Commands.$actionName
{
    public record ${actionName}Command($recordProps) : IRequest<IResult>;
}
"@
    Create-ClassFile -folderPath $folderPath -fileName "${actionName}Command.cs" -content $commandContent

    # HANDLER (Namespace: Categories, Entity: Category) -> ÇAKIŞMA YOK!
    $handlerContent = @"
using MediatR;
using Bagery.Core.Utilities.Results;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace $RootNamespace.$BaseFolder.$PluralName.Commands.$actionName
{
    public class ${actionName}CommandHandler(IGenericRepository<$FeatureName> repository) : IRequestHandler<${actionName}Command, IResult>
    {
        public async Task<IResult> Handle(${actionName}Command request, CancellationToken cancellationToken)
        {
            // İşlemler...
            return new SuccessResult();
        }
    }
}
"@
    Create-ClassFile -folderPath $folderPath -fileName "${actionName}CommandHandler.cs" -content $handlerContent
}

# --- QUERIES ---
$queries = @("Get${FeatureName}List", "Get${FeatureName}ById")

foreach ($qName in $queries) {
    $folderPath = Join-Path $FeaturePath "Queries\$qName"
    $resultRecordName = "${qName}QueryResult"

    if ($qName -like "*List") {
        $returnType = "List<$resultRecordName>"
        $queryProps = "" 
    } else {
        $returnType = $resultRecordName
        $queryProps = "int Id" 
    }

    $recordContent = @"
using System;

namespace $RootNamespace.$BaseFolder.$PluralName.Queries.$qName
{
    public record $resultRecordName($allPropsString);
}
"@
    Create-ClassFile -folderPath $folderPath -fileName "${resultRecordName}.cs" -content $recordContent

    $queryContent = @"
using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace $RootNamespace.$BaseFolder.$PluralName.Queries.$qName
{
    public record ${qName}Query($queryProps) : IRequest<IDataResult<$returnType>>;
}
"@
    Create-ClassFile -folderPath $folderPath -fileName "${qName}Query.cs" -content $queryContent

    # HANDLER (Primary Constructor ile Repository kullanımı)
    $handlerContent = @"
using MediatR;
using Bagery.Core.Utilities.Results;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace $RootNamespace.$BaseFolder.$PluralName.Queries.$qName
{
    public class ${qName}QueryHandler(IGenericRepository<$FeatureName> repository) : IRequestHandler<${qName}Query, IDataResult<$returnType>>
    {
        public async Task<IDataResult<$returnType>> Handle(${qName}Query request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<$returnType>(null);
        }
    }
}
"@
    Create-ClassFile -folderPath $folderPath -fileName "${qName}QueryHandler.cs" -content $handlerContent
}

Write-Host "`n✅ $FeatureName için namespace '$PluralName' olarak ayarlandı. Çakışma çözüldü!" -ForegroundColor Cyan