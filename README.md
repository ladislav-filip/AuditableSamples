# AuditableSamples


## EF migration
```dotnet ef migrations add <migration-name> -p ..\Auditable.Persistence\Auditable.Persistence.csproj```

```dotnet ef database update -p ..\Auditable.Persistence\Auditable.Persistence.csproj```